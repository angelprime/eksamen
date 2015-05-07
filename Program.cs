using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen
{
    class Program
    {
        static void Main(string[] args)
        {

            IStregsystemLogic stregsystem = new StregsystemLogic();
            IStregsystemUI cli = new StregsystemCLI(stregsystem);
            StregsystemCommandParser parser = new StregsystemCommandParser(cli, stregsystem);
            

            //TEST
            List<Product> liste = new List<Product>();
            liste = SaveLoadTools.LoadProducts();
            foreach (Product item in liste)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine(stregsystem.GetUser("Max").ToString());
            Console.ReadKey();
            //TEST

            cli.Start(parser);
        }
    }
}
