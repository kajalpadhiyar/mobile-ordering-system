using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore
{
    class Customer
    {
        public struct kCustomer
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Location { get; set; }
            public DateTime Dob
            {
                get;
                set;
            }
        }

        public static List<kCustomer> CustomerList()
        {
            return JsonConvert.DeserializeObject<List<kCustomer>>(File.ReadAllText(@"customer.json"));
        }
    }

}
