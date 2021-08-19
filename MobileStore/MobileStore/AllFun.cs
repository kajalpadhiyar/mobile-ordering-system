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
        public static bool Search_Customer(string sUsername, string sLocation)
        {
            int sflag = 0;
            string sUserName = sUsername;
            string slocation = sLocation;
            string sdob = "";
            foreach (var o in LCustomer)
            {
                if (o.Username.ToString() == sUserName && o.Location.ToString() == slocation)
                {
                    slocation = o.Location.ToString();
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
                Console.WriteLine($"Customer's Username Name : {sUserName}\n Location : {slocation}\n Dob : {sdob}");
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

    }
}
