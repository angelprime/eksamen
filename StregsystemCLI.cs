using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen
{
    public class StregsystemCLI : IStregsystemUI
    {
        IStregsystemLogic _ss;
        List<Product> _productList;
        bool quit;
        public StregsystemCLI(IStregsystemLogic stregsystem)
        {
            _ss = stregsystem;
        }


        public void DisplayUserNotFound(string username)
        {
            Console.WriteLine("User '" + username + "' not found.");
        }

        public void DisplayProductNotFound(int productID)
        {
            Console.WriteLine("Product '" + productID + "' not found.");
        }

        public void DisplayUserInfo(User user)
        {
            Console.WriteLine(user.ToString());
            if (user.Balance < 5000)
            {
                Console.WriteLine("Balance low!");
            }
        }

        public void DisplayTooManyArgumentsError()
        {
            Console.WriteLine("Error: Too many arguments!");
        }

        public void DisplayAdminCommandNotFoundError()
        {
            Console.WriteLine("Error: Admin command not found.");
        }

        public void DisplayUserBuysProduct(Product product)
        {
            Console.WriteLine("Bought product: " + product.Name);
        }

        public void DisplayUserBuysProduct(Product product, int amount)
        {
            Console.WriteLine("Bought " + amount + " of product: " + product.Name);
        }

        public void DisplayTransaction(Transaction transaction)
        {
            Console.WriteLine(transaction.ToString());
        }

        public void Close()
        {
            quit = true;
        }

        public void DisplayInsufficientFundsError()
        {
            Console.WriteLine("Error: Insufficient funds. Transaction cancelled.");
        }

        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine(errorString);
        }


        public void Start(StregsystemCommandParser parser)
        {
            quit = false;
            do
            {
                Console.Clear();
                _productList = _ss.GetActiveProducts();
                foreach (Product item in _productList)
                {
                    Console.WriteLine(item.ToString());
                }
                parser.ParseCommand(Console.ReadLine());
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            } while (!quit);
        }
    }
}
