using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore
{
    class Home
    {
        //Read data from json
        static List<Customer.kCustomer> LCustomer = JsonConvert.DeserializeObject<List<Customer.kCustomer>>(File.ReadAllText(@"customer.json"));
        static List<Product.kMumbai> LProduct = JsonConvert.DeserializeObject<List<Product.kMumbai>>(File.ReadAllText(@"Product.json"));
        public static void Signup()
        {
            Console.WriteLine("<----- SignUp Page ----->\n");

            Authentication.AuthenticateID();

            Authentication.AuthenticateUsername();

            Authentication.AuthenticatePassword();

            Console.WriteLine("\nEnter FirstName: ");
            string firstname = Console.ReadLine();

            Console.WriteLine("\nEnter LastName: ");
            string lastname = Console.ReadLine();

            Console.WriteLine("\nEnter Location: ");
            string location = Console.ReadLine();

            Authentication.AuthenticateRest(firstname, lastname, location);

            Authentication.AuthenticateMobile();

            Authentication.AuthenticateDOB();

            Authentication.Register();
        }

        public static void Login()
        {
            Console.WriteLine("<----- Login Page ----->\n");
            Console.Write("Enter User Name: ");
            string userName = Console.ReadLine();
            Console.Write("Enter Password Name: ");
            //string password = Console.ReadLine();
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


            int flag = 0;
            foreach (var o in LCustomer)
            {
                if (o.Username.ToString() == userName && o.Password.ToString() == password)
                {
                    flag = 1;
                }
            }
            if (flag == 0)
            {
                Console.WriteLine("Incorrect Username or password");
                Program.Firstpg();
            }
            else if (userName == "Admin" && password == "Admin")
            {
                Console.WriteLine("<----- Menu ----->\n");
                Console.WriteLine("Click 1: Search Customer by Username and Location\nClick 2: View all customers\nClick 3: Add a Product\nClick 4: View all Products\nClick 5: Exit");
                int choice = int.Parse(Console.ReadLine());
                while (choice != 5)
                {
                    switch (choice)
                    {
                        case 1:
                            //search customer
                            Console.Write("Enter Customer's User Name: ");
                            string sUserName = Console.ReadLine();
                            Console.Write("Enter Customer's Location: ");
                            string slocation = Console.ReadLine();
                            AllFun.Search_Customer(sUserName,slocation);
                            Console.WriteLine("Click 1: Search Customer by Username and Location\nClick 2: View all customers\nClick 3: Add a Product\nClick 4: View all Products\nClick 5: Exit");
                            choice = int.Parse(Console.ReadLine());
                            break;

                        case 2:
                            //view all customers
                            foreach (var o in LCustomer)
                            {
                                if (o.Username.ToString() != "Admin" && o.Password.ToString() != "Admin")
                                {
                                    Console.WriteLine($"Id : {o.Id}\tUser Name : {o.Username.ToString()}\tLocation : {o.Location.ToString()}\tDob : {o.Dob.ToShortDateString()}\n");
                                }
                            }
                            Console.WriteLine("Click 1: Search Customer by Username and Location\nClick 2: View all customers\nClick 3: Add a Product\nClick 4: View all Products\nClick 5: Exit");
                            choice = int.Parse(Console.ReadLine());
                            break;

                        case 3:
                            //add product into json
                            Console.Write("Enter Mobile Company: ");
                            string c_name = Console.ReadLine();
                            Console.Write("Enter Mobile Name: ");
                            string m_name = Console.ReadLine();
                            Console.Write("Enter RAM: ");
                            string ram = Console.ReadLine();
                            int i;
                            bool success = int.TryParse(ram, out i);
                            if (!success)
                            {
                                Console.WriteLine("Please enter integer value");
                                Console.Write("Enter RAM: ");
                                ram = Console.ReadLine();
                                success = int.TryParse(ram, out i);
                            }
                            Console.Write("Enter ROM: ");
                            string rom = Console.ReadLine();
                            int j;
                            bool r_success = int.TryParse(rom, out j);
                            if (!r_success)
                            {
                                Console.WriteLine("Please enter integer value");
                                Console.Write("Enter ROM: ");
                                rom = Console.ReadLine();
                                r_success = int.TryParse(rom, out j);
                            }

                            Console.Write("Enter color: ");
                            string color = Console.ReadLine();
                            Console.Write("Enter store: ");
                            string store = Console.ReadLine();
                            Console.Write("Enter Price: ");
                            string price = Console.ReadLine();
                            int k;
                            bool p_success = int.TryParse(price, out k);
                            if (!success)
                            {
                                Console.WriteLine("Please enter integer value");
                                Console.Write("Enter Price: ");
                                price = Console.ReadLine();
                                p_success = int.TryParse(price, out k);
                            }
                            AllFun.Add_Products(c_name,m_name,i,j,color,store,k);
                            Console.WriteLine("Click 1: Search Customer by Username and Location\nClick 2: View all customers\nClick 3: Add a Product\nClick 4: View all Products\nClick 5: Exit");
                            choice = int.Parse(Console.ReadLine());
                            break;
                        case 4:
                            //iterate list to display all products
                            foreach (var o in LProduct)
                            {
                                    Console.WriteLine($"Product Id : {o.P_Id}\tCompany Name : {o.C_Name}\tMobile Name : {o.M_Name}\tRAM : {o.Ram}\tROM : {o.Storage}\tColors : {o.Color}\tStore Location : {o.Store}\tPrice : {o.Price}\n");
                            }
                            Console.WriteLine("Click 1: Search Customer by Username and Location\nClick 2: View all customers\nClick 3: Add a Product\nClick 4: View all Products\nClick 5: Exit");
                            choice = int.Parse(Console.ReadLine());
                            break;
                        case 5:
                            Console.WriteLine("Please click either 1 2 3 4");
                            break;

                    }
                }
            }
            else
            {
                Console.WriteLine("<----- Menu ----->\n");
                Console.WriteLine("Click 1: View own details\nClick 2 : View All Products\nClick 3 : Search Product By Name\nClick 4 : Book an Order\nClick 5 : Exit");
                int choice = int.Parse(Console.ReadLine());
                while (choice != 5)
                {
                    switch (choice)
                    {
                        case 1:
                            //view own details
                            foreach (var o in LCustomer)
                            {
                                if (o.Username.ToString() == userName && o.Password.ToString() == password)
                                {
                                    Console.WriteLine($"User Name : {userName}\nPassword : {password}\n Location : {o.Location.ToString()}\n Dob : {o.Dob.ToShortDateString()}");
                                }
                            }
                            Console.WriteLine("Click 1: View own details\nClick 2 : View All Products\nClick 3 : Search Product By Name\nClick 4 : Book an Order\nClick 5 : Exit");
                            choice = int.Parse(Console.ReadLine());
                            break;
                        case 2:
                            //iterate list to display all products
                            foreach (var o in LProduct)
                            {
                                Console.WriteLine($"Product Id : {o.P_Id}\tCompany Name : {o.C_Name}\tMobile Name : {o.M_Name}\tRAM : {o.Ram}\tROM : {o.Storage}\tColors : {o.Color}\tStore Location : {o.Store}\tPrice : {o.Price}\n");
                            }
                            Console.WriteLine("Click 1: View own details\nClick 2 : View All Products\nClick 3 : Search Product By Name\nClick 4 : Book an Order\nClick 5 : Exit");
                            choice = int.Parse(Console.ReadLine());
                            break;
                        case 3:
                            //Search Product
                            Console.Write("Enter Customer's Company Name: ");
                            string c_name = Console.ReadLine();
                            Book_Order.Search_Product(c_name);
                            Console.WriteLine("Click 1: View own details\nClick 2 : View All Products\nClick 3 : Search Product By Name\nClick 4 : Book an Order\nClick 5 : Exit");
                            choice = int.Parse(Console.ReadLine());
                            break;

                        case 4:
                            //Book product
                            Book_Order.Product_Book(userName);
                            Console.WriteLine("Click 1: View own details\nClick 2 : View All Products\nClick 3 : Search Product By Name\nClick 4 : Book an Order\nClick 5 : Exit");
                            choice = int.Parse(Console.ReadLine());
                            break;
                        case 5:
                            Console.WriteLine("Please click 1 2 3 4");
                            break;
                    }
                }
            }
        }
    }
}
