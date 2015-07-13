using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class TicketUpdate
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int CreatorId { get; set; }
        public string Creator { get; set; }
        public int TicketId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
