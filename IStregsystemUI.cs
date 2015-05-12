using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen
{
    public interface IStregsystemUI
    {
        void DisplayUserNotFound(string username);
        void DisplayProductNotFound(int productID);
        void DisplayUserInfo(User user);
        void DisplayTooManyArgumentsError();
        void DisplayAdminCommandNotFoundError();
        void DisplayUserBuysProduct(Product product);
        void DisplayUserBuysProduct(Product product, int amount);
        void DisplayTransaction(Transaction transaction);
        void Close();
        void DisplayInsufficientFundsError();
        void DisplayGeneralError(string errorString);
        void Start(StregsystemCommandParser parser);
        void DisplayInactiveProducts();
    }
}
