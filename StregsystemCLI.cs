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

        //displays error
        public void DisplayUserNotFound(string username)
        {
            Console.WriteLine("User '" + username + "' not found.");
        }

        //displays error
        public void DisplayProductNotFound(int productID)
        {
            Console.WriteLine("Product '" + productID + "' not found.");
        }

        //displays info about a user
        public void DisplayUserInfo(User user)
        {
            Console.WriteLine(user.ToString());
            if (user.Balance < 5000)
            {
                Console.WriteLine("Balance low!");
            }
        }

        //displays error
        public void DisplayTooManyArgumentsError()
        {
            Console.WriteLine("Error: Too many arguments!");
        }

        //displays error
        public void DisplayAdminCommandNotFoundError()
        {
            Console.WriteLine("Error: Admin command not found.");
        }

        //displays buy
        public void DisplayUserBuysProduct(Product product)
        {
            Console.WriteLine("Bought product: " + product.Name);
        }

        //displays multibuy
        public void DisplayUserBuysProduct(Product product, int amount)
        {
            Console.WriteLine("Bought " + amount + " of product: " + product.Name);
        }

        //displays the given transaction
        public void DisplayTransaction(Transaction transaction)
        {
            Console.WriteLine(transaction.ToString());
        }

        //Tells the user input loop to stop looping
        public void Close()
        {
            quit = true;
        }

        //Displays error
        public void DisplayInsufficientFundsError()
        {
            Console.WriteLine("Error: Insufficient funds. Transaction cancelled.");
        }

        //displays text, normally of the error variety, though it doesn't actually check
        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine(errorString);
        }

        //enters the user input loop
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

        //displays a list of all inactive products, instead of the usual list of active ones
        public void DisplayInactiveProducts()
        {
            Console.Clear();
            List<Product> list = _ss.GetInactiveProducts();
            foreach (Product item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
