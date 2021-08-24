using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore
{
    public static class Authentication
    {
        private static Customer.kCustomer customerData = new Customer.kCustomer();
        private static List<Customer.kCustomer> LCustomer = JsonConvert.DeserializeObject<List<Customer.kCustomer>>(File.ReadAllText(@"customer.json"));


        public static void SignUp()
        {
            Console.WriteLine("<----- SignUp Page ----->\n");
            AuthenticateID();
            AuthenticateUsername();
            AuthenticatePassword();
            AuthenticateRest();
            AuthenticateMobile();
            AuthenticateDOB();
            Register();
        }

        //ID
        private static void AuthenticateID()
        {
            int id = LCustomer.Count + 1;
            customerData.Id = id;
        }

        //Username
        private static void AuthenticateUsername()
        {
            Console.WriteLine("\nEnter UserName:");
            string username = Console.ReadLine().ToLower();

            try
            {
                foreach (var o in LCustomer)
                {
                    if (o.Username == username)
                        throw new AuthenticationException(username);
                }
                if (username.Length < 3 || username.Length > 10)
                {
                    throw new AuthenticationException(username, username.Length);
                }
                customerData.Username = username;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                AuthenticateUsername();
            }

        }

        //Password
        private static void AuthenticatePassword()
        {
            Console.WriteLine("\nEnter Password: (After Entering Password press 'Enter')");
            string password = null;

            while (true)  //hides the typed characters while typing password
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)    // this loop breaks when user presses enter
                    break;
                password += key.KeyChar;   //KeyChar is a property that stores the character pressed from the Keyboard
                Console.CursorVisible = false;  //hides the cursor while typing
            }
            Console.CursorVisible = true;

            try
            {
                if (password.Length < 6 || password.Length > 12)
                {
                    throw new AuthenticationException(password.Length);
                }
                customerData.Password = password;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                AuthenticatePassword();
            }

            Console.WriteLine("");
        }

        //Mobile Number
        private static void AuthenticateMobile()
        {
            Console.WriteLine("\nEnter Mobile Number: ");
            string number = Console.ReadLine();

            try
            {
                if (!int.TryParse(number, out var i))
                {
                    throw new MobileException(number);
                }
                if (number.Length > 10 || number.Length < 10)
                {
                    throw new MobileException(number.Length);
                }
                customerData.Mobile = number;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                AuthenticateMobile();
            }
        }

        //Date of Birth
        private static void AuthenticateDOB()
        {
            Console.WriteLine("\nPlease enter birth date (yyyy/mm/dd): ");
            try
            {
                DateTime dob = DateTime.Parse(Console.ReadLine());
                customerData.Dob = dob;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                AuthenticateDOB();
            }
        }

        //Firstname, Lastname, Location
        private static void AuthenticateRest()
        {
            Console.WriteLine("\nEnter FirstName: ");
            string firstname = Console.ReadLine();

            Console.WriteLine("\nEnter LastName: ");
            string lastname = Console.ReadLine();

            Console.WriteLine("\nEnter Location: ");
            string location = Console.ReadLine();

            customerData.FirstName = firstname;
            customerData.Lastname = lastname;
            customerData.Location = location;
        }

        //Adds the new account to the JSON file
        private static void Register()
        {
            LCustomer.Add(customerData);
            var jsonstring = JsonConvert.SerializeObject(LCustomer, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(@"customer.json", jsonstring);
            Console.WriteLine("Successfully created account...Please do the login\n");
        }

    }


}

