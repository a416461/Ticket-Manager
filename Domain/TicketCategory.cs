using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TicketCategory
    {
        public TicketCategory(string name, int businessId)
        {
            this.Name = name;
            this.BusinessId = businessId;
            this.DateCreated = DateTime.Now;
            this.Tickets = new List<Ticket>();
        }

        public TicketCategory() { }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int BusinessId { get; private set; }
        public virtual Business Business { get; private set; }
        public virtual ICollection<Ticket> Tickets { get; private set; }
        public int NumberOfTickets
        {
            get
            {
                return this.Tickets.Count();
            }
        }
        public DateTime DateCreated { get; private set; }

        public TicketCategory UpdateTicketCategory(string name)
        {
            this.Name = name;
            return this;
        }
    }
}
