using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class User : Account
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BusinessId { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}
