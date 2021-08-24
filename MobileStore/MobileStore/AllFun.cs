using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore
{
    public class AllFun
    {
        static List<Product.kMumbai> LProduct = JsonConvert.DeserializeObject<List<Product.kMumbai>>(File.ReadAllText(@"Product.json"));
        static List<Customer.kCustomer> LCustomer = JsonConvert.DeserializeObject<List<Customer.kCustomer>>(File.ReadAllText(@"customer.json"));
        static List<Product.oMumbai> LHistory = JsonConvert.DeserializeObject<List<Product.oMumbai>>(File.ReadAllText(@"History.json"));

        public static bool Search_Customer(string sUsername, string sLocation)
        {
            int sflag = 0;
            string sUserName = sUsername;
            string slocation = sLocation;
            string sdob = "",smob="",sfirstname="",slastname="";
            foreach (var o in LCustomer)
            {
                if (o.Username.ToString() == sUserName && o.Location.ToString() == slocation)
                {
                    slocation = o.Location.ToString();
                    sfirstname = o.FirstName.ToString();
                    slastname = o.Lastname.ToString();
                    smob = o.Mobile.ToString();
                    sdob = o.Dob.ToShortDateString();
                    sflag = 1;
                }
            }
            if (sflag == 0)
            {
                Console.WriteLine("No such customer exist");
                return false;
            }
            else
            {
                Console.WriteLine($"User Name : {sUsername}\tFirst Name : {sfirstname}\tLast Name : {slastname}\tMobile No : {smob}\tDob : {sdob}\n");
                return true;
            }
        }
        public static bool  Add_Products(string c_Name,string m_Name, int I, int J, string ccolor, string sstore, int K)
        {
            string c_name = c_Name;
            string m_name = m_Name;
            int i = I;
            int j = J;
            string color = ccolor;
            string store = sstore;
            int k = K;
            if (String.IsNullOrEmpty(c_name) || String.IsNullOrEmpty(m_name) || String.IsNullOrEmpty(color) || i == 0 || j == 0 || k == 0 || String.IsNullOrEmpty(store))
            {
                Console.WriteLine("All fields are required");
                return false;
            }
            else 
            { 

            int id = LProduct.Count() + 1;
            //assigning values to the keys
            Product.kMumbai dproduct = new Product.kMumbai()
            {
                P_Id = id,
                C_Name = c_name,
                M_Name = m_name,
                Ram = i,
                Storage = j,
                Color = color,
                Store = store,
                Price = k,
                Store_Count = (c_name + "_" + m_name + "_" + i + "_" + j + "_" + color + "_" + store).ToUpper()
            };
            LProduct.Add(dproduct);
            var jsonString = JsonConvert.SerializeObject(LProduct, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(@"Product.json", jsonString);
            Console.WriteLine("Successfully Added");
                return true;
        }

        }

        public static void User(string userName, string password)
        {
            login:
            Console.WriteLine("\n<----- Menu ----->\n");
            Console.WriteLine("Click 1: View own details\nClick 2 : View All Products\nClick 3 : Search Product By Name\nClick 4 : Book an Order\nClick 5 : View Order History\nClick 6 : Exit\n");
            int choice = int.Parse(Console.ReadLine());
            string firstname = "";
            foreach (var o in LCustomer)
            {
                if (o.Username.ToString() == userName && o.Password.ToString() == password)
                {
                    firstname = o.FirstName.ToString();
                }
            }
            try
            {
                while (choice != 6)
                {
                    switch (choice)
                    {
                        case 1:
                            //view own details
                            foreach (var o in LCustomer)
                            {
                                if (o.Username.ToString() == userName && o.Password.ToString() == password)
                                {
                                    Console.WriteLine($"Id : {o.Id}\tUser Name : {o.Username.ToString()}\tFirst Name : {o.FirstName.ToString()}\tLast Name : {o.Lastname.ToString()}\tMobile No : {o.Mobile.ToString()}\tLocation : {o.Location.ToString()}\tDob : {o.Dob.ToShortDateString()}\n");
                                }
                            }
                            Console.WriteLine("Click 1: View own details\nClick 2 : View All Products\nClick 3 : Search Product By Name\nClick 4 : Book an Order\nClick 5 : View Order History\nClick 6 : Exit\n");
                            choice = int.Parse(Console.ReadLine());
                            break;
                        case 2:
                            //iterate list to display all products
                            foreach (var o in LProduct)
                            {
                                Console.WriteLine($"Product Id : {o.P_Id}\tCompany Name : {o.C_Name}\tMobile Name : {o.M_Name}\tRAM : {o.Ram}\tROM : {o.Storage}\tColors : {o.Color}\tStore : {o.Store}\tPrice : {o.Price}\n");
                            }
                            Console.WriteLine("Click 1: View own details\nClick 2 : View All Products\nClick 3 : Search Product By Name\nClick 4 : Book an Order\nClick 5 : View Order History\nClick 6 : Exit\n");
                            choice = int.Parse(Console.ReadLine());
                            break;
                        case 3:
                            //Search Product
                            Console.Write("Enter Mobile company name to search: ");
                            string c_name = Console.ReadLine();
                            Book_Order.Search_Product(c_name);
                            Console.WriteLine("Click 1: View own details\nClick 2 : View All Products\nClick 3 : Search Product By Name\nClick 4 : Book an Order\nClick 5 : View Order History\nClick 6 : Exit\n");
                            choice = int.Parse(Console.ReadLine());
                            break;

                        case 4:
                            //Book product
                            Book_Order.Product_Book(firstname, userName, password);
                            Console.WriteLine("Click 1: View own details\nClick 2 : View All Products\nClick 3 : Search Product By Name\nClick 4 : Book an Order\nClick 5 : View Order History\nClick 6 : Exit\n");
                            choice = int.Parse(Console.ReadLine());
                            break;
                        case 5:
                            foreach (var o in LHistory)
                            {
                                if (o.Cust.ToString() == firstname)
                                {
                                    Console.WriteLine($"Company Name : {o.C_Name}\tMobile Name : {o.M_Name}\tRAM : {o.Ram}\tROM : {o.Storage}\tColor : {o.Color}\tStore : {o.Store}\tPrice : {o.Price}\n");
                                }
                            }
                            Console.WriteLine("Click 1: View own details\nClick 2 : View All Products\nClick 3 : Search Product By Name\nClick 4 : Book an Order\nClick 5 : View Order History\nClick 6 : Exit\n");
                            choice = int.Parse(Console.ReadLine());
                            break;
                        default:
                            throw new LoginException(choice);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto login;
            }
        }
        public static bool SearchStoreHistory(string storeLocation)
        {
            int status = 0;
            foreach (var o in LHistory)
            {
                if (o.Store.ToString() == storeLocation)
                {
                    Console.WriteLine($"Company Name : {o.C_Name}\tCustomer : {o.Cust}\tMobile Name : {o.M_Name}\tRAM : {o.Ram}\tROM : {o.Storage}\tColor : {o.Color}\tPrice : {o.Price}\n");
                    status = 1;
                }
            }
            if(status == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
