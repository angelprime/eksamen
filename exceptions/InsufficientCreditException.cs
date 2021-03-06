﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen
{
    public class InsufficientCreditException : Exception
    {
        User _user;
        Product _product;
        public InsufficientCreditException(string message, User user, Product product)
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
