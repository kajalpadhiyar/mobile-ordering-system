using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore
{
    public class Home
    {
        //Read data from json
       // static List<Customer.kCustomer> LCustomer = JsonConvert.DeserializeObject<List<Customer.kCustomer>>(File.ReadAllText(@"customer.json"));
        //static List<Product.kMumbai> LProduct = JsonConvert.DeserializeObject<List<Product.kMumbai>>(File.ReadAllText(@"Product.json"));
        //static List<Product.oMumbai> LHistory = JsonConvert.DeserializeObject<List<Product.oMumbai>>(File.ReadAllText(@"History.json"));

        public static void Signup()
        {
            Authentication.SignUp();
        }

        public static void Login()
        {

            Console.WriteLine("<----- Login Page ----->\n");
            AuthenticateLogin.AuthenticateUsernamePassword();
        }
    }
}
