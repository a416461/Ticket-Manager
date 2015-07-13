using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TicketUpdate
    {
        public TicketUpdate(string content, int ticketId, int creatorId)
        {
            this.Content = content;
            this.TicketId = ticketId;
            this.CreatorId = creatorId;
            this.DateCreated = DateTime.Now;
        }

        public TicketUpdate() { }

        public int Id { get; private set; }
        public string Content { get; private set; }
        public int CreatorId { get; private set; }
        public virtual User Creator { get; protected set; }
        public int TicketId { get; private set; }
        public virtual Ticket Ticket { get; protected set; }
        public DateTime DateCreated { get; private set; }
    }
}
