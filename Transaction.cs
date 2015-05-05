using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen
{
    class Transaction
    {
        protected long _transactionID, _creditChange;
        protected User _user;
        protected DateTime _time;
        protected bool _hasExecuted;
        public Transaction(long ID, User user, long creditChange)
        {
            _transactionID = ID;
            _user = user;
            _creditChange = creditChange;
            _time = DateTime.Now;
            _hasExecuted = false;
            if (_user == null || _transactionID < 1 || _creditChange == 0 || _creditChange == null)
            {
                _hasExecuted = true;
                throw new ArgumentException("Must specify a user, a positive ID and a non-zero credit change");
            }
        }

        public virtual User Execute()
        {
            if (_hasExecuted)
            {
                throw new FieldAccessException("Transaction has already been executed");
            }
            _user.Balance += _creditChange;
            _hasExecuted = true;
            return _user;
        }

        public virtual override string ToString()
        {
            string result = "ID: " + _transactionID + " Amount: " + _creditChange + " timestamp: " + _time.ToString();
            return result;
        }
    }
}
