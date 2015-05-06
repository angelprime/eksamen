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

        public bool IsActive
        {
            get { return _active; }
        }

        public override bool Equals(object obj)
        {
            Product u = obj as Product;               //allows this instance of Equals to work on child objects as well. Thanks MSDN!
            if (u != null)
            {
                return this._productID == u._productID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return _productID;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Product u = obj as Product;               //again with the child objects. Thanks MSDN!
            if (u != null)
                return this._productID.CompareTo(u._productID);
            else
                throw new ArgumentException("Object is not a Product");
        }
    }
}
