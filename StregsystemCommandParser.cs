using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace eksamen
{
    public class StregsystemCommandParser
    {
        IStregsystemUI _UI;
        IStregsystemLogic _ss;
        User _user;
        int _param1, _param2;
        Product _product;
        long _totalPrice;
        List<Transaction> transactions;
        public StregsystemCommandParser(IStregsystemUI UI, IStregsystemLogic stregsystem)
        {
            _UI = UI;
            _ss = stregsystem;
        }

        public void ParseCommand(string command)
        {
            string[] input = Regex.Split(command, " ");
            int len = input.Length;
            if (command.StartsWith(":"))
            {
                AdminCommand(command);
            }
            else if (len > 3)
            {
                _UI.DisplayTooManyArgumentsError();
            }
            else
            {
                try
                {
                    _user = _ss.GetUser(input[0]);
                    switch (len)
                    {
                        case 1:
                            _UI.DisplayUserInfo(_user);
                            transactions = _ss.GetUserTransactions(_user.Username, 10);
                            foreach (BuyTransaction item in transactions)
                            {
                                _UI.DisplayTransaction(item);
                            }
                            break;
                        case 2:
                            _param1 = Convert.ToInt32(input[1]);
                            _product = _ss.GetProduct(_param1);
                            if (_user.Balance < 5000)
                            {
                                _UI.DisplayGeneralError("WARNING: Funds low!");
                            }
                            _ss.BuyProduct(_user.Username, _param1);
                            _UI.DisplayUserBuysProduct(_product);
                            break;
                        case 3:
                            _param1 = Convert.ToInt32(input[1]);
                            _param2 = Convert.ToInt32(input[2]);
                            _product = _ss.GetProduct(_param1);
                            _totalPrice = _product.Price * (long)_param2;
                            if (_totalPrice > _user.Balance)
                            {
                                _UI.DisplayInsufficientFundsError();
                            }
                            else
                            {
                                for (int i = 0; i < _param2; i++)
                                {
                                    _ss.BuyProduct(_user.Username, _product.ID);
                                }
                                _UI.DisplayUserBuysProduct(_product, _param2);
                            }
                            break;
                        default:
                            _UI.DisplayGeneralError("Something went wrong with the command (ref. switch)"); //Should be unreachable
                            break;
                    }
                }
                catch (UserNotFoundException e) { _UI.DisplayUserNotFound(e.Message); }
                catch (FormatException) { _UI.DisplayGeneralError("Please input user name (space) product ID, and optionally (space) amount to buy."); }
                catch (ProductNotFoundException e) { _UI.DisplayGeneralError(e.Message); }
                catch (InsufficientCreditException) { _UI.DisplayInsufficientFundsError(); }
                catch (ProductInactiveException e) { _UI.DisplayGeneralError(e.Message); }
            }


            
        }

        private void AdminCommand(string command)
        {

        }
    }
}
