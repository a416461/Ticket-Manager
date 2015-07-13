using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class TicketCategory
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public int NumberOfTickets { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
