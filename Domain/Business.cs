using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Business : Account
    {
        public Business(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.ActiveAccount = true;
            this.Users = new List<User>();
            this.Categories = new List<TicketCategory>();
            this.Tickets = new List<Ticket>();
        }
        
        public Business() { }

        public string Name { get; private set; }
        public bool ActiveAccount { get; private set; }

        public virtual ICollection<User> Users { get; private set; }
        public virtual ICollection<TicketCategory> Categories { get; private set; }
        public virtual ICollection<Ticket> Tickets { get; private set; }

        public User CreateNewUserAccount(string firstName, string lastName, string email, string password)
        {
            return new User(firstName, lastName, email, password, this.Id);
        }

        public TicketCategory CreateNewTicketCategory(string name)
        {
            return new TicketCategory(name, this.Id);
        }

        public Ticket CreateNewTicket(string title, string content, int categoryId, TicketPriority priority, int creatorId)
        {
            return new Ticket(title, content, categoryId, creatorId, priority);
        }

        public Business UpdateBusiness(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            return this;
        }
    }
}
