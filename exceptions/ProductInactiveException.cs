using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen
{
    public class ProductInactiveException : Exception
    {
        User _user;
        Product _product;
        public ProductInactiveException() { }
        public ProductInactiveException(string message, User user, Product product)
            : base (message)
        {
            _user = user;
            _product = product;
        }

        public User User
        {
            get { return _user; }
        }

        public Product Product
        {
            get { return _product; }
        }
    }
}
