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
        Dictionary<String, Func<object, bool>> _adminTable = new Dictionary<string, Func<object, bool>>();
        public StregsystemCommandParser(IStregsystemUI UI, IStregsystemLogic stregsystem)
        {
            _UI = UI;
            _ss = stregsystem;
            _adminTable.Add(":q", AQuit);
            _adminTable.Add(":quit", AQuit);
            _adminTable.Add(":activate", AActivate);
            _adminTable.Add(":deactivate", ADeactivate);
            _adminTable.Add(":crediton", AAllowCredit);
            _adminTable.Add(":creditoff", ADenyCredit);
            _adminTable.Add(":addcredits", AAddCredits);

        }

        //Parses and executes non-admin commands. Admin commands are passed to AdminCommand
        public void ParseCommand(string command)
        {
            string[] input = Regex.Split(command, " ");
            int len = input.Length;
            if (command.StartsWith(":"))
            {
                AdminCommand(input);
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

        //handler for admin commands
        private void AdminCommand(string[] input)
        {
            try
            {
                Func<object, bool> commandFunc = _adminTable[input[0]];
                commandFunc(input);
            }
            catch (KeyNotFoundException)
            {
                _UI.DisplayGeneralError("Error: Invalid admin command");
            }
            
            
        }

        //Command to close program
        private bool AQuit(object input)
        {
            _UI.Close();
            return true;
        }

        //Command to activate a product
        private bool AActivate(Object rawInput) 
        {
            string[] input = rawInput as string[];
            if(input.Length == 1)
            {
                _UI.DisplayInactiveProducts();
                _UI.DisplayGeneralError(":activate must be followed by the number of one of the above inactive products");
            }
            else if(input.Length == 2)
            {
                try
                {
                    int i = Convert.ToInt32(input[1]);
                    _ss.ActivateProduct(i);
                }
                catch (ProductNotFoundException e)
                {
                    _UI.DisplayGeneralError(e.Message);
                }
                catch (FormatException)
                {
                    _UI.DisplayGeneralError("Error: :activate must be followed by a single, positive integer");
                }

            }
            else
            {
                _UI.DisplayGeneralError("Error: Wrong number of parameters for this action");
                return false;
            }
            return true;
        }

        //Command to deactivate a product
        private bool ADeactivate(Object rawInput)
        {
            string[] input = rawInput as string[];
            if (input.Length == 2)
            {
                try
                {
                    int i = Convert.ToInt32(input[1]);
                    _ss.DeactivateProduct(i);
                }
                catch (ProductNotFoundException e)
                {
                    _UI.DisplayGeneralError(e.Message);
                }
                catch (FormatException)
                {
                    _UI.DisplayGeneralError("Error: :deactivate must be followed by a single, positive integer");
                }

            }
            else
            {
                _UI.DisplayGeneralError("Error: Wrong number of parameters for this action");
                return false;
            }
            return true;
        }

        //command to allow a product to be bought on credit
        private bool AAllowCredit(Object rawInput)
        {
            string[] input = rawInput as string[];
            if (input.Length == 2)
            {
                try
                {
                    int i = Convert.ToInt32(input[1]);
                    _ss.SetCBBOCtoTrue(i);
                }
                catch (ProductNotFoundException e)
                {
                    _UI.DisplayGeneralError(e.Message);
                }
                catch (FormatException)
                {
                    _UI.DisplayGeneralError("Error: :crediton must be followed by a single, positive integer");
                }

            }
            else
            {
                _UI.DisplayGeneralError("Error: Wrong number of parameters for this action");
                return false;
            }
            return true;
        }

        //command to disallow a product from being bought on credit
        private bool ADenyCredit(Object rawInput)
        {
            string[] input = rawInput as string[];
            if (input.Length == 2)
            {
                try
                {
                    int i = Convert.ToInt32(input[1]);
                    _ss.SetCBBOCtoFalse(i);
                }
                catch (ProductNotFoundException e)
                {
                    _UI.DisplayGeneralError(e.Message);
                }
                catch (FormatException)
                {
                    _UI.DisplayGeneralError("Error: :creditoff must be followed by a single, positive integer");
                }

            }
            else
            {
                _UI.DisplayGeneralError("Error: Wrong number of parameters for this action");
                return false;
            }
            return true;
        }

        //command to add credits to account
        private bool AAddCredits(object rawInput)
        {
            string[] input = rawInput as string[];
            if (input.Length == 3)
            {
                try
                {
                    long i = Convert.ToInt64(input[2]);
                    _ss.AddCreditToAccount(input[1], i);
                }
                catch (ProductNotFoundException e)
                {
                    _UI.DisplayGeneralError(e.Message);
                }
                catch (FormatException)
                {
                    _UI.DisplayGeneralError("Error: :addcredits must be followed by a username and an integer");
                }

            }
            else
            {
                _UI.DisplayGeneralError("Error: Wrong number of parameters for this action");
                return false;
            }
            return true;
        }
    }
}
