using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen
{
    public interface IStregsystemLogic
    {

        void BuyProduct(string username, int productID);
        void AddCreditToAccount(string username, long amount);
        void ExecuteTransaction(Transaction transaction);
        Product GetProduct(int ID);
        User GetUser(String UserName);
        List<Transaction> GetUserTransactions(string username, int amountOfTransactionsToGet);
        List<Product> GetActiveProducts();

    }
}
