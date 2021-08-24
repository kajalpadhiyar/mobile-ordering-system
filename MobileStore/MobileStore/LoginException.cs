using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore
{
    class LoginException : Exception
    {
        public LoginException() : base("Invalid Username or Password")
        { }
        public LoginException(int choice) : base("Enter a valid option")
        { }
    }
}
