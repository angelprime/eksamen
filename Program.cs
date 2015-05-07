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
            //TEST
            List<Product> liste = new List<Product>();
            liste = SaveLoadTools.LoadProducts();
            foreach (Product item in liste)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
            //TEST

            IStregsystemLogic stregsystem = new StregsystemLogic();
            IStregsystemUI cli = new StregsystemCLI(stregsystem);
            StregsystemCommandParser parser = new StregsystemCommandParser(cli, stregsystem);
            cli.Start(parser);
        }
    }
}
