using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen
{
    public class Transaction
    {
        protected long _transactionID, _creditChange;
        protected User _user;
        protected DateTime _time;
        protected bool _hasExecuted;
        protected String _priceAsString;
        public Transaction(long ID, User user, long creditChange)
        {
            _transactionID = ID;
            _user = user;
            _creditChange = creditChange;
            _time = DateTime.Now;
            _hasExecuted = false;
            if (_user == null || _transactionID < 1 || _creditChange == 0)
            {
                _hasExecuted = true;
                throw new ArgumentException("Must specify a user, a positive ID and a non-zero credit change");
            }
            _priceAsString = _creditChange.ToString();
            int _priceLen = _priceAsString.Length;
            _priceAsString = _creditChange.ToString();
            _priceLen = _priceAsString.Length;
            if (_creditChange != 0)
            {
                if (!(_priceAsString.EndsWith("00")))
                {
                    _priceAsString = _priceAsString.Insert(_priceAsString.Length - 2, ",");
                }
                else
                {
                    _priceAsString = _priceAsString.Remove(_priceLen - 2);
                    _priceAsString = _priceAsString + ";";
                }
            }
        }

        public User User
        {
            get { return _user; }
        }

        public DateTime Timestamp
        {
            get { return _time; }
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

        public override string ToString()
        {
            string result = "Admin    Transaction ID: " + _transactionID + " Amount: " + _priceAsString + " timestamp: " + _time.ToString();
            return result;
        }
    }
}
