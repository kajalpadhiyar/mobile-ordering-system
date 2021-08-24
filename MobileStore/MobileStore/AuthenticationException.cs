using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore
{
    class AuthenticationException : Exception
    {
        public AuthenticationException(string name)
            : base(string.Format("{0}: Same username already exists", name))
        {
        }

        public AuthenticationException(string name, int len)
            : base(string.Format("{0} length is {1}: Username must be greater than 3 or less than 10", name, len))
        {
        }
        public AuthenticationException(int len)
            : base(string.Format("Length {0}: Password length must be greater than 5 or less than 12", len))
        {
        }

    }

    public class MobileException : Exception
    {
        public MobileException(string name)
            : base(string.Format("{0}: Same username already exists", name))
        {
        }

        public MobileException(int len)
            : base(string.Format("You have enterd {0} digits, Mobile number should have 10 digits", len))
        {
        }
    }
}
