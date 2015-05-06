﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen
{
    class User : IComparable
    {
        String _username, _firstname, _lastname, _email;
        int _userID;
        long _balance;
        public User(int userID, String username, String firstname, String lastname, String email, long balance)
        {
            _userID = userID;
            _username = username;
            _firstname = firstname;
            _lastname = lastname;
            _email = email;
            _balance = balance;
        }

        public long Balance
        {
            get { return _balance; }
            set{_balance = value;}
        }

        public int ID
        {
            get { return _userID; }
            set { Balance = value; }
        }

        public override string ToString()
        {
            String result = _firstname + " " + _lastname + " " + _email;
            return result;
        }

        public override bool Equals(object obj)
        {
            User u = obj as User;               //allows this instance of Equals to work on child objects as well. Thanks MSDN!
            if (u != null)
            {
                return this._userID == u._userID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return _userID;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            User u = obj as User;               //again with the child objects. Thanks MSDN!
            if (u != null)
                return this._userID.CompareTo(u._userID);
            else
                throw new ArgumentException("Object is not a User");
        }
    }
}