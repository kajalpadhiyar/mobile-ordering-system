using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore
{
    class Product
    {

        public struct kProduct
        {
            public int P_Id { get; set; }
            public string C_Name { get; set; }
            public string M_Name { get; set; }
            public List<int> Ram { get; set; }
            public List<int> Storage { get; set; }
            public List<String> Color { get; set; }
            public string Store { get; set; }
        }

            public static List<kProduct> ProductList()
            {
                return JsonConvert.DeserializeObject<List<kProduct>>(File.ReadAllText(@"Product.json"));
            }
        }
    }
