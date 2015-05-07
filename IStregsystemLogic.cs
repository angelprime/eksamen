using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen
{
    public interface IStregsystemLogic
    {

        void BuyProduct(User user, Product product);
        void AddCreditToAccount(User user, long amount);
        void ExecuteTransaction(Transaction transaction);
        Product GetProduct();
        User GetUser();
        List<Transaction> GetUserTransactions(User user, int amountOfTransactionsToGet);
        List<Product> GetActiveProducts();

    }
}
