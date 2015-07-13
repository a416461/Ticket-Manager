using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class Account
    {
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public int Id { get; protected set; }

        public string FormatName(string name)
        {
            if (name == null)
            {
                return null;
            }
            else
            {
                return char.ToUpper(name[0], CultureInfo.CurrentCulture) + name.Substring(1).ToLower();
            }
        }
    }
}
