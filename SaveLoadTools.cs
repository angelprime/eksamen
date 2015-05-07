using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace eksamen
{
    public static class SaveLoadTools
    {
        

        public static List<Product> LoadProducts()
        {
            if (File.Exists("products.csv")) 
            {
                String[] tempArr = File.ReadAllLines("products.csv");
                int len = tempArr.Length;
                for (int i = 1; i < len; i++)
                {
                    
                }
                return null;
            }
            return null;
        }
    }
}
