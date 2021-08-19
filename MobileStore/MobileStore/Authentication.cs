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
    public class Authentication
    {
        static Customer.kCustomer customerData = new Customer.kCustomer();
        static List<Customer.kCustomer> LCustomer = JsonConvert.DeserializeObject<List<Customer.kCustomer>>(File.ReadAllText(@"customer.json"));

        //ID
        public static void AuthenticateID()
        {
            int id = LCustomer.Count + 1;
            customerData.Id = id;

        }

        //Username
        public static void AuthenticateUsername()
        {
            Console.WriteLine("\nEnter UserName:");
            string username = Console.ReadLine().ToLower();
            
            bool found = false;
            foreach(var o in LCustomer)
            {
                if (o.Username == username)
                   found = true;
            }

            if (username.Length < 3 || username.Length > 10)
            { 
                Console.WriteLine("\nUsername length must be greater than 3 or less than 10");
                AuthenticateUsername();
            }
            else if(found){
                Console.WriteLine("\nUsername must be unique, try another username.");
                AuthenticateUsername();
            }
            else
            {
                customerData.Username = username;
            }
        }

        //Password
        public static void AuthenticatePassword()
        {
            Console.WriteLine("\nEnter Password: (After Entering Password press 'Enter')");
            string password = null;

            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)    // this loop breaks when user presses enter
                    break;
                password += key.KeyChar;   //KeyChar is a property that stores the character pressed from the Keyboard
                Console.CursorVisible = false;  //hides the cursor while typing
            }
            Console.CursorVisible = true;

            if (password.Length < 6 || password.Length > 12)
            { 
                Console.WriteLine("\nPassword length must be greater than 3 or less than 10");
                AuthenticatePassword();
            }
            else
            {
                customerData.Password = password;
            }
            Console.WriteLine("");
        }

        //Mobile Number
        public static void AuthenticateMobile()
        {
            Console.WriteLine("\nEnter Mobile Number: ");
            string number = Console.ReadLine();

            if (!int.TryParse(number, out var i))
            {
                Console.WriteLine("\nEnter a valid number");
                AuthenticateMobile();
            }
            else if (number.Length > 10 || number.Length < 10)
            {
                Console.WriteLine("\nNumber should be of 10 digits");
                AuthenticateMobile();
            }
            else
            {
                customerData.Mobile = number;
            }

        }

        //Date of Birth
        public static void AuthenticateDOB()
        {
            Console.WriteLine("\nPlease enter birth date (yyyy/mm/dd): ");
            try
            {
                DateTime dob = DateTime.Parse(Console.ReadLine());
                customerData.Dob = dob;
            }
            catch (Exception)
            {
                Console.WriteLine("Enter your DOB properly (yyyy/mm/dd)");
                AuthenticateDOB();
            }
        }

        //Firstname, Lastname, Location
        public static void AuthenticateRest(string firstname,string lastname,string location)
        {
            customerData.FirstName = firstname;
            customerData.Lastname = lastname;
            customerData.Location = location;
        }

        //Adds the new account to the JSON file
        public static void Register()
        {
            LCustomer.Add(customerData);
            var jsonstring = JsonConvert.SerializeObject(LCustomer, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(@"customer.json", jsonstring);
            Console.WriteLine("Successfully created account...Please do the login");
            Program.Firstpg();
        }
        
    }

}

