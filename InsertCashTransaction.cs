using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen
{
    class InsertCashTransaction :Transaction
    {

        public InsertCashTransaction(long ID, User user, long creditChange)
            : base(ID, user, creditChange)
        {
            if (_creditChange < 1)
            {
                _hasExecuted = true;
                throw new ArgumentException("Cannot deposit negative credits");
            }
        }

        public override User Execute()
        {
            return base.Execute();
        }

        public override string ToString()
        {
            string result = "Deposit  Transaction ID: " + _transactionID + " User ID: " + _user.ID + " Amount: " + _creditChange + " timestamp: " + _time.ToString();
            return result;
        }
    }
}
