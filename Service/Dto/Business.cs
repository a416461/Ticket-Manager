using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class Business : Account
    {
        public string Name { get; set; }
        public bool ActiveAccount { get; set; }
    }
}
