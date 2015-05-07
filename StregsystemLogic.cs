using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen
{
    public class StregsystemLogic : IStregsystemLogic
    {

        public StregsystemLogic()
        {
            List<Transaction> _transactionList = new List<Transaction>();
            List<Product> _productList = SaveLoadTools.LoadProducts();
            
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

        public Product GetProduct()
        {
            throw new NotImplementedException();
        }

        public User GetUser()
        {
            throw new NotImplementedException();
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
