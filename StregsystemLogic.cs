using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen
{
    public class StregsystemLogic : IStregsystemLogic
    {
        List<User> _userList = new List<User>();
        List<Transaction> _transactionList = new List<Transaction>();
        List<Product> _productList = new List<Product>();
        long _nextTransactionNumber = new long();
        public StregsystemLogic()
        {
            _productList = SaveLoadTools.LoadProducts();
            _nextTransactionNumber = 1;
            User any = new User(13, "Max", "Maxi", "Millian", "my@mail.any", 10000);//TEST
            _userList.Add(any);                                                     //TEST
        }

        //lets 'username' buy one instance of product 'productID'
        public void BuyProduct(string username, int productID)
        {
            User user = GetUser(username);
            Product product = GetProduct(productID);
            BuyTransaction transaction = new BuyTransaction(_nextTransactionNumber, user, product);
            ExecuteTransaction(transaction);
        }

        //adds 'amount' credits to user 'username'
        public void AddCreditToAccount(string username, long amount)
        {
            User user = GetUser(username);
            InsertCashTransaction transaction = new InsertCashTransaction(_nextTransactionNumber, user, amount);
            ExecuteTransaction(transaction);
        }

        //executes and stores the given transaction<
        public void ExecuteTransaction(Transaction transaction)
        {
            transaction.Execute();
            _nextTransactionNumber++;
            _transactionList.Add(transaction);
        }

        //returns a product specified by ID
        public Product GetProduct(int ID)
        {
            Product result = new Product();
            result = _productList.Find(x => x.ID == ID);
            if (result != null)
            {
                return result;
            }
            throw new ProductNotFoundException("Product: " + ID + " not found.");
        }

        //returns a user specified by username
        public User GetUser(String UserName)
        {
            User result = new User();
            result = _userList.Find(x => x.Username == UserName);
            if (result != null)
            {
                return result;
            }
            throw new UserNotFoundException(UserName);
        }

        /// <summary>
        /// Returns a list of transactions containing the specified amount of purchases, taken fro the most recent
        /// </summary>
        /// <param name="username"></param>
        /// <param name="amountOfTransactionsToGet"></param>
        /// <returns></returns>
        public List<Transaction> GetUserTransactions(string username, int amountOfTransactionsToGet)
        {
            List<Transaction> userTransactions = _transactionList.FindAll(y => y.User.Username == username && y.GetType() == typeof(BuyTransaction));
            List<Transaction> result = new List<Transaction>();
            userTransactions.Sort((x, y) => DateTime.Compare(y.Timestamp, x.Timestamp));
            int length = userTransactions.Count();
            for (int i = 0; i < length && i < amountOfTransactionsToGet; i++)
            {
                result.Add(userTransactions.ElementAt(i));
            }
            return result;
        }

        //returns a list of all active products
        public List<Product> GetActiveProducts()
        {
            List<Product> result = _productList.FindAll(x => x.IsActive);
            return result;
        }

        //returns a list of all inactive products
        public List<Product> GetInactiveProducts()
        {
            List<Product> result = _productList.FindAll(x => !x.IsActive);
            return result;
        }

        //method that sets a products _active state to TRUE
        public void ActivateProduct(int ID)
        {
            Product temp = _productList.Find(x => x.ID == ID);
            if (temp != null)
            {
                temp.Activate();
            }
            else
            {
                throw new ProductNotFoundException("Product: " + ID + " not found.");
            }
        }

        //method that sets a products _active state to FALSE, implemented with method calls
        public void DeactivateProduct(int ID)
        {
            Product temp = _productList.Find(x => x.ID == ID);
            if (temp != null)
            {
                temp.Deactivate();
            }
            else
            {
                throw new ProductNotFoundException("Product: " + ID + " not found.");
            }
        }

        //method that allows a product to be bought on credit, implemented with get/set
        public void SetCBBOCtoTrue(int ID)
        {
            Product temp = _productList.Find(x => x.ID == ID);
            if (temp != null)
            {
                temp.CanBeBoughtWithCredit = true;
            }
            else
            {
                throw new ProductNotFoundException("Product: " + ID + " not found.");
            }
        }

        //method that disallows a product to be bought on credit
        public void SetCBBOCtoFalse(int ID)
        {
            Product temp = _productList.Find(x => x.ID == ID);
            if (temp != null)
            {
                temp.CanBeBoughtWithCredit = false;
            }
            else
            {
                throw new ProductNotFoundException("Product: " + ID + " not found.");
            }
        }

        //sends list for saving
        public void SaveTransactionsToFile()
        {
            SaveLoadTools.SaveTransactions(_transactionList);
        }
    }
}
