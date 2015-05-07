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
        public StregsystemLogic()
        {
            _productList = SaveLoadTools.LoadProducts();
            //User ass = new User(13, "Max", "Maxi", "Millian", "my@mail.any", 3000);//TEST
            //_userList.Add(ass);                                                    //TEST
        }


        public void BuyProduct(User user, Product product)
        {
            throw new NotImplementedException();
        }

        public void AddCreditToAccount(User user, long amount)
        {
            throw new NotImplementedException();
        }

        public void ExecuteTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
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

        public List<Transaction> GetUserTransactions(User user, int amountOfTransactionsToGet)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetActiveProducts()
        {
            throw new NotImplementedException();
        }
    }
}
