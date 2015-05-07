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
        public StregsystemCLI(IStregsystemLogic stregsystem)
        {
            _ss = stregsystem;
        }


        public void DisplayUserNotFound()
        {
            throw new NotImplementedException();
        }

        public void DisplayProductNotFound()
        {
            throw new NotImplementedException();
        }

        public void DisplayUserInfo()
        {
            throw new NotImplementedException();
        }

        public void DisplayTooManyArgumentsError()
        {
            throw new NotImplementedException();
        }

        public void DisplayAdminCommandNotFoundMessage()
        {
            throw new NotImplementedException();
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public void DisplayUserBuysProduct(int count)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void DisplayInsufficientCash()
        {
            throw new NotImplementedException();
        }

        public void DisplayGeneralError(string errorString)
        {
            throw new NotImplementedException();
        }


        public void Start(StregsystemCommandParser parser)
        {
            throw new NotImplementedException();
        }
    }
}
