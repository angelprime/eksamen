using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen
{
    public class Product
    {
        int _productID, _priceLen;
        long _price;
        string _name, _priceAsString;
        bool _active, _canBeBoughtOnCredit;
        public Product()
        {
            _productID = 0;
            _name = "";
            _price = 0;
            _active = false;
            _canBeBoughtOnCredit = false;
        }
        public Product(int ID, String name, long price, bool active, bool credit)
        {
            _productID = ID;
            _name = name;
            _price = price;
            _active = active;
            _canBeBoughtOnCredit = credit;
            _priceAsString = _price.ToString();
            _priceLen = _priceAsString.Length;
            if (_price != 0)
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

        public int ID
        {
            get { return _productID; }
        }

        public string Name
        {
            get { return _name; }
        }

        public long Price
        {
            get { return _price; }
        }

        public string PriceAsString
        {
            get { return _priceAsString; }
        }

        public bool CanBeBoughtWithCredit
        {
            get { return _canBeBoughtOnCredit; }
        }

        public bool IsActive
        {
            get { return _active; }
        }

        public override string ToString()
        {
            return "Product ID: " + _productID + "  Name: " + _name + "  Price: " + _priceAsString + "  Buy with credit: " + _canBeBoughtOnCredit;
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
