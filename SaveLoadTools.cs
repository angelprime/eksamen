using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace eksamen
{
    public static class SaveLoadTools
    {
        

        public static List<Product> LoadProducts()
        {
            if (File.Exists("products.csv")) 
            {
                List<Product> _productList = new List<Product>();
                String[] tempArr = File.ReadAllLines("products.csv", Encoding.UTF7);
                int len = tempArr.Length;
                for (int i = 1; i < len; i++)
                {
                    String _stringToSplit = tempArr.ElementAt(i);
                    String _splitPattern = ";";
                    String[] _splitString = Regex.Split(_stringToSplit, _splitPattern);
                    int _id = Convert.ToInt32(_splitString.ElementAt(0));
                    string _name = Regex.Replace(_splitString.ElementAt(1), "\"|<[^>]*>", "");
                    long _price = Convert.ToInt64(_splitString.ElementAt(2));
                    bool _active = Convert.ToBoolean(Convert.ToInt32(_splitString.ElementAt(3)));
                    Product _readProduct = new Product(_id, _name, _price, _active, false);
                    _productList.Add(_readProduct);
                }
                return _productList;
            }
            throw new FileNotFoundException("products.csv blev ikke fundet. Ligger filen i samme mappe som programmet?");
        }

        public static void SaveTransactions(List<Transaction> transactionList)
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");
            int i = files.Length + 1;
            int len = transactionList.Count();
            String[] linesToWrite = new String[len];
            for (int x = 0; x < len; x++)
            {
                linesToWrite[x] = transactionList.ElementAt(x).ToString();
            }
            System.IO.File.WriteAllLines("transaction log " + i + ".txt", linesToWrite);
        }

        public static List<User> LoadUsers()
        {
            throw new NotImplementedException();
        }
    }
}
