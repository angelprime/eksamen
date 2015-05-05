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
            IStregsystem stregsystem = new Stregsystem();
            StregsystemCLI cli = new StregsystemCLI(stregsystem);
            StregsystemCommandParser parser = new StregsystemCommandParser(cli, stregsystem);
            cli.Start(parser);
        }
    }
}
