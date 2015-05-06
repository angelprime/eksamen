using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen
{
    class SeasonalProduct : Product
    {
        DateTime _startTime, _endTime;
        public SeasonalProduct(int ID, String name, long price, bool active, bool credit, DateTime start, DateTime end)
            : base(ID, name, price, active, credit)
        {
            _startTime = start;
            _endTime = end;
        }
    }
}
