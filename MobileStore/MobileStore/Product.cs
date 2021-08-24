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

        public struct kMumbai
        {
            public int P_Id { get; set; }
            public string C_Name { get; set; }
            public string M_Name { get; set; }
            //public List<int> Ram { get; set; }
            public int Ram { get; set; }
            public int Storage { get; set; }
            public String Color { get; set; }
            public string Store { get; set; }
            public int Price { get; set; }
            public string Store_Count { get; set; }
        }
        public struct oMumbai
        {
            public int P_Id { get; set; }
            public string C_Name { get; set; }
            public string M_Name { get; set; }
            //public List<int> Ram { get; set; }
            public int Ram { get; set; }
            public int Storage { get; set; }
            public String Color { get; set; }
            public string Store { get; set; }
            public int Price { get; set; }

            public string Cust { get; set; }
            public bool Buy { get; set; }
        }
    }
}
