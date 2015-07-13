using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum TicketPriority
    {
        Low = 1,
        Medium = 2,
        High = 3
    }

    public enum TicketStatus
    {
        Open = 1,
        Closed = 2
    }

    public class Ticket
    {        
        public Ticket(string title, string content, int categoryId, int creatorId, TicketPriority priority)
        {
            this.Title = title;
            this.Content = content;
            this.CategoryId = categoryId;
            this.CreatorId = creatorId;
            this.Priority = priority;
            this.Status = TicketStatus.Open;
            this.DateCreated = DateTime.Now;
            this.LastEdited = DateTime.Now;
            this.Updates = new List<TicketUpdate>();
        }

        public Ticket() { }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public int CategoryId { get; private set; }
        public virtual TicketCategory Category { get; private set; }
        public int CreatorId { get; private set; }
        public virtual User Creator { get; private set; }
        public TicketPriority Priority { get; private set; }
        public TicketStatus Status { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime LastEdited { get; private set; }
        public virtual ICollection<TicketUpdate> Updates { get; private set; }

        public TicketUpdate CreateNewTicketUpdate(string content, int creatorId)
        {
            return (new TicketUpdate(content, this.Id, creatorId));
        }

        public Ticket UpdateTicket(string title, int categoryId, TicketPriority priority, TicketStatus status)
        {
            this.Title = title;
            this.CategoryId = categoryId;
            this.Priority = priority;
            this.Status = status;
            this.LastEdited = DateTime.Now;
            return this;
        }
    }
}
