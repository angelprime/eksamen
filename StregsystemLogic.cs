using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eksamen.exceptions;

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
            //User ass = new User(13, "Max", "Maxi", "Millian", "my@mail.any", 3000);//TEST
            //_userList.Add(ass);                                                    //TEST
        }


        public void BuyProduct(string username, int productID)
        {
            User user = GetUser(username);
            Product product = GetProduct(productID);
            BuyTransaction transaction = new BuyTransaction(_nextTransactionNumber, user, product);
            ExecuteTransaction(transaction);
        }

        public void AddCreditToAccount(string username, long amount)
        {
            User user = GetUser(username);
            InsertCashTransaction transaction = new InsertCashTransaction(_nextTransactionNumber, user, amount);
            ExecuteTransaction(transaction);
        }

        public void ExecuteTransaction(Transaction transaction)
        {
            try
            {
                transaction.Execute();
                _nextTransactionNumber++;
                _transactionList.Add(transaction);

            }
            catch (Exception)
            {
                Console.WriteLine("Transaction failed.");
                SaveLoadTools.SaveTransactions(_transactionList);  //This is a really bad idea, but it's in the documentation
                throw;
            }
        }

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

        public User GetUser(String UserName)
        {
            User result = new User();
            result = _userList.Find(x => x.Username == UserName);
            if (result != null)
            {
                return result;
            }
            throw new UserNotFoundException("User: " + UserName + " not found.");
        }

        public List<Transaction> GetUserTransactions(string username, int amountOfTransactionsToGet)
        {
            List<Transaction> userTransactions = _transactionList.FindAll(y => y.User.Username == username);
            List<Transaction> result = new List<Transaction>();
            userTransactions.Sort((x, y) => DateTime.Compare(x.Timestamp, y.Timestamp));
            int length = userTransactions.Count();
            for (int i = 0; i < length && i < amountOfTransactionsToGet; i++)
            {
                result.Add(userTransactions.ElementAt(i));
            }
            return result;
        }

        public List<Product> GetActiveProducts()
        {
            List<Product> result = _productList.FindAll(x => x.IsActive);
            return result;
        }
    }
}
