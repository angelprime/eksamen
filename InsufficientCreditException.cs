using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen
{
    class InsufficientCreditException : Exception //Thanks MSDN!
    {
        public InsufficientCreditException()
        {

        }

        public InsufficientCreditException(string message)
            : base(message)
        {

        }

        public InsufficientCreditException(String message, Exception inner)
            : base(message, inner)
        {

        }

    }
}
