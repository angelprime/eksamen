﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen
{
    class BuyTransaction : Transaction
    {
        Product _product;
        long _price;
        public BuyTransaction(long ID, User user, Product product)
            : base(ID, user, -product.Price)
        {
            _product = product;
            _price = product.Price;
        }

        public override User Execute()
        {
            //TODO
            return base.Execute();
        }

        public override string ToString()
        {
            string result = "Purchase ID: " + _transactionID + " User ID: " + _user.ID + " Amount: " + _price + " timestamp: " + _time.ToString();
            return result;
        }
    }
}