using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen
{
    class Product
    {
        int _productID;
        long _price;
        string _name;
        bool _active, _canBeBoughtOnCredit;
        public Product(int ID, String name, long price, bool active, bool credit)
        {
            _productID = ID;
            _name = name;
            _price = price;
            _active = active;
            _canBeBoughtOnCredit = credit;
        }

        public int ID
        {
            get { return _productID; }
        }

        public long Price
        {
            get { return _price; }
        }

        public bool CanBeBoughtWithCredit
        {
            get { return _canBeBoughtOnCredit; }
        }
    }
}
