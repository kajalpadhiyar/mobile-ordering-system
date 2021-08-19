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
    public class Book_Order
    {
        static List<Product.oMumbai> LOrder = JsonConvert.DeserializeObject<List<Product.oMumbai>>(File.ReadAllText(@"Order.json"));
        static List<Product.kMumbai> LProduct = JsonConvert.DeserializeObject<List<Product.kMumbai>>(File.ReadAllText(@"Product.json"));
        
        public static bool Search_Product(string c_Name)
        {
            int sflag = 0;
            string c_name = c_Name;
            foreach (var o in LProduct)
            {
                if (o.C_Name.ToString() == c_name)
                {
                    Console.WriteLine($"Product Id : {o.P_Id}\tCompany Name : {c_name}\tMobile Name : {o.M_Name}\tRAM : {o.Ram}\tROM : {o.Storage}\tStore : {o.Store}\n");
                    sflag = 1;
                }
            }
            if (sflag == 0)
            {
                Console.WriteLine("No such product exist");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static void Product_Book(string firstname)
        {
            string name = firstname;
            int sflag = 0;
            int id;


            //Book_Order.Search_Product();

            Console.WriteLine("Enter the Product Id Which You Want to Buy From Above List : ");
            id = int.Parse(Console.ReadLine());
            for(int o=0;o<LProduct.Count;o++)
            {
                if (LProduct[o].P_Id == id)

                {
                    Console.WriteLine(LProduct[o].P_Id + " " + id);
                    Product.oMumbai dproducts = new Product.oMumbai()
                    {
                        P_Id = id,
                        C_Name = LProduct[o].C_Name,
                        M_Name = LProduct[o].M_Name,
                        Ram = LProduct[o].Ram,
                        Storage = LProduct[o].Storage,
                        Color = LProduct[o].Color,
                        Store = LProduct[o].Store,
                        Price = LProduct[o].Price,
                        Cust = firstname
                    };
                    LOrder.Add(dproducts);
                    var jsonString = JsonConvert.SerializeObject(LOrder, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(@"Order.json", jsonString);
                    Console.WriteLine("Successfully Added");


                    var list = File.ReadAllText(@"Product.json");
                    dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(list);
                    
                    foreach (var i in jsonObj)
                    {
                        if (i["P_Id"] == id)
                        {
                            i.Remove();
                            break;    
                        }
                    }

                    var jsonfile2 = jsonObj.ToString();
                    File.WriteAllText(@"Product.json", jsonfile2);
                    sflag = 1;
                    break;
                }
            }

            if (sflag == 0)
            {
                Console.WriteLine("No such product exist");

            }

        }
    }
}
