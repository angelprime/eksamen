using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen
{
    public class BuyTransaction : Transaction
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
            if (!_product.IsActive)
            {
                throw new ProductInactiveException("The product is not currently available. User: " + _user.ID + " product: " + _product.ID, _user, _product);
            }
            if (_product.CanBeBoughtWithCredit || (_user.Balance + _creditChange) > 0)
            {
                return base.Execute();
            }
            throw new InsufficientCreditException("Not enough funds to make purchase. User: " + _user.ID + " product: " + _product.ID + " price: " + _product.PriceAsString, _user, _product);

        }

        public override string ToString()
        {
            string result = "Purchase Transaction ID: " + _transactionID + " User ID: " + _user.ID + " Amount: " + _product.PriceAsString + " timestamp: " + _time.ToString();
            return result;
        }
    }
}
