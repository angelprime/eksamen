using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen
{
    class IStregsystemLogic
    {

        public void BuyProduct(User user, Product product);
        public void AddCreditToAccount(User user, long amount);
        public void ExecuteTransaction(Transaction transaction);
        public Product GetProduct();
        public User GetUser();
        public List<Transaction> GetUserTransactions(User user, int amountOfTransactionsToGet);
        public List<Product> GetActiveProducts();

    }
}
