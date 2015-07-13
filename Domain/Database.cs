using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class Database
    {
        private static readonly SqlDatabase db = new SqlDatabase(ConfigurationManager.ConnectionStrings["EarlyBirds"].ConnectionString);

        public static List<Business> Businesses
        {
            get
            {
                DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM Businesses");
                DataSet ds = db.ExecuteDataSet(cmd);

                List<Business> businesses = new List<Business>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    int Id = (int)dr["Id"];
                    string Name = (string)dr["Name"];
                    string Email = (string)dr["Email"];
                    string Password = (string)dr["Password"];

                    Business business = null;// new Business(Id, Name, Email, Password);
                    businesses.Add(business);
                }

                return businesses;
            }
        }
        public static List<TicketCategory> TicketCategories
        {
            get
            {
                DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM TicketCategories");
                DataSet ds = db.ExecuteDataSet(cmd);

                List<TicketCategory> ticketCategories = new List<TicketCategory>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    int Id = (int)dr["Id"];
                    string Name = (string)dr["Name"];
                    int BusinessId = (int)dr["BusinessId"];
                    DateTime DateCreated = (DateTime)dr["DateCreated"];

                    TicketCategory ticketCategory = new TicketCategory(Id, Name, BusinessId, DateCreated);
                    ticketCategories.Add(ticketCategory);
                }

                return ticketCategories;
            }
        }
        public static List<Ticket> Tickets
        {
            get
            {
                DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM Tickets");
                DataSet ds = db.ExecuteDataSet(cmd);

                List<Ticket> tickets = new List<Ticket>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    int Id = (int)dr["Id"];
                    string Title = (string)dr["Title"];
                    string Content = (string)dr["Content"];
                    int CategoryId = (int)dr["CategoryId"];
                    int CreatorId = (int)dr["CreatorId"];
                    TicketPriority Priority = (TicketPriority)dr["TicketPriorityId"];
                    TicketStatus Status = (TicketStatus)dr["TicketStatusId"];
                    DateTime DateCreated = (DateTime)dr["DateCreated"];
                    DateTime LastEdited = (DateTime)dr["LastEdited"];

                    Ticket ticket = new Ticket(Id, Title, Content, CategoryId, CreatorId, Priority, Status, DateCreated, LastEdited);
                    tickets.Add(ticket);
                }

                return tickets;
            }
        }
        public static List<TicketUpdate> TicketUpdates
        {
            get
            {
                DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM TicketUpdates");
                DataSet ds = db.ExecuteDataSet(cmd);

                List<TicketUpdate> ticketUpdates = new List<TicketUpdate>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    int Id = (int)dr["Id"];
                    string Content = (string)dr["Content"];
                    int TicketId = (int)dr["TicketId"];
                    int CreatorId = (int)dr["CreatorId"];
                    DateTime DateCreated = (DateTime)dr["DateCreated"];

                    TicketUpdate ticketUpdate = new TicketUpdate(Id, Content, TicketId, CreatorId, DateCreated);
                    ticketUpdates.Add(ticketUpdate);
                }

                return ticketUpdates;
            }
        }
        public static List<User> Users
        {
            get
            {
                DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM Users");
                DataSet ds = db.ExecuteDataSet(cmd);

                List<User> users = new List<User>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    int Id = (int)dr["Id"];
                    string FirstName = (string)dr["FirstName"];
                    string LastName = (string)dr["LastName"];
                    string Email = (string)dr["Email"];
                    string Password = (string)dr["Password"];
                    int BusinessId = (int)dr["BusinessId"];

                    User user = new User(Id, FirstName, LastName, Email, Password, BusinessId);
                    users.Add(user);
                }

                return users;
            }
        }

        public static void Insert(Business Business)
        {
            DbCommand cmd = db.GetSqlStringCommand(String.Format("INSERT INTO Businesses (Email, Password, Name) VALUES ('{0}', '{1}', '{2}');", Business.Email, Business.Password, Business.Name));
            db.ExecuteNonQuery(cmd);


        }
        public static void Insert(TicketCategory TicketCategory)
        {
            //DbCommand cmd = db.GetSqlStringCommand(String.Format("INSERT INTO TicketCategories (Name, BusinessId, DateCreated) VALUES ('{0}', {1}, '{2}');", TicketCategory.Name, TicketCategory.BusinessId, TicketCategory.DateCreated));
            //db.ExecuteNonQuery(cmd);

            //DbCommand cmd = db.GetStoredProcCommand("dbo.InsertTicketCategory");
            //db.AddInParameter(cmd, "@Name", DbType.String, TicketCategory.Name);
            //db.AddInParameter(cmd, "@Email", DbType.String, TicketCategory.Email);
            //db.AddInParameter(cmd, "@Password", DbType.String, TicketCategory.Password);
            //db.AddInParameter(cmd, "@BusinessId", DbType.Int32, TicketCategory.Id);
            //db.ExecuteNonQuery(cmd);
        }
        public static void Insert(Ticket Ticket)
        {
            DbCommand cmd = db.GetSqlStringCommand(String.Format("INSERT INTO Tickets (Title, Content, CategoryId, CreatorId, TicketPriorityId, TicketStatusId, DateCreated, LastEdited) VALUES ('{0}', '{1}', {2}, {3}, {4}, {5}, '{6}', '{7}');", Ticket.Title, Ticket.Content, Ticket.CategoryId, Ticket.CreatorId, (int)Ticket.Priority, (int)Ticket.Status, Ticket.DateCreated, Ticket.LastEdited));
            db.ExecuteNonQuery(cmd);
        }
        public static void Insert(TicketUpdate TicketUpdate)
        {
            DbCommand cmd = db.GetSqlStringCommand(String.Format("INSERT INTO TicketUpdates (Content, CreatorId, TicketId, DateCreated, SystemGeneratedNote) VALUES ('{0}', {1}, {2}, '{3}', {4});", TicketUpdate.Content, TicketUpdate.CreatorId, TicketUpdate.TicketId, TicketUpdate.DateCreated));
            db.ExecuteNonQuery(cmd);
        }
        public static void Insert(User User)
        {
            DbCommand cmd = db.GetSqlStringCommand(String.Format("INSERT INTO Users (Email, Password, FirstName, LastName, BusinessId) VALUES ('{0}', '{1}', '{2}', '{3}', {4});", User.Email, User.Password, User.FirstName, User.LastName, User.BusinessId));
            db.ExecuteNonQuery(cmd);
        }

        public static void Update(Business Business)
        {
            DbCommand cmd = db.GetStoredProcCommand("dbo.UpdateBusiness");
            db.AddInParameter(cmd, "@Name", DbType.String, Business.Name);
            db.AddInParameter(cmd, "@Email", DbType.String, Business.Email);
            db.AddInParameter(cmd, "@Password", DbType.String, Business.Password);
            db.AddInParameter(cmd, "@BusinessId", DbType.Int32, Business.Id);
            db.ExecuteNonQuery(cmd);
        }
        public static void Update(TicketCategory TicketCategory)
        {
            DbCommand cmd = db.GetStoredProcCommand("dbo.UpdateTicketCategory");
            db.AddInParameter(cmd, "@Name", DbType.String, TicketCategory.Name);
            db.AddInParameter(cmd, "@TicketCategoryId", DbType.Int32, TicketCategory.Id);
            db.ExecuteNonQuery(cmd);
        }
        public static void Update(Ticket Ticket)
        {
            DbCommand cmd = db.GetStoredProcCommand("dbo.UpdateTicketCategory");
            db.AddInParameter(cmd, "@Title", DbType.String, Ticket.Title);
            db.AddInParameter(cmd, "@CategoryId", DbType.Int32, Ticket.CategoryId);
            db.AddInParameter(cmd, "@TicketPriorityId", DbType.Int32, Ticket.Priority);
            db.AddInParameter(cmd, "@TicketStatusId", DbType.Int32, Ticket.Status);
            db.AddInParameter(cmd, "@LastEdited", DbType.DateTime2, Ticket.LastEdited);
            db.AddInParameter(cmd, "@TicketId", DbType.Int32, Ticket.Id);
            db.ExecuteNonQuery(cmd);
        }
        public static void Update(User User)
        {
            DbCommand cmd = db.GetStoredProcCommand("dbo.UpdateUser");
            db.AddInParameter(cmd, "@FirstName", DbType.String, User.FirstName);
            db.AddInParameter(cmd, "@LastName", DbType.String, User.LastName);
            db.AddInParameter(cmd, "@Email", DbType.String, User.Email);
            db.AddInParameter(cmd, "@Password", DbType.String, User.Password);
            db.AddInParameter(cmd, "@UserId", DbType.Int32, User.Id);
            db.ExecuteNonQuery(cmd);
        }

        public static void Delete(Business Business)
        {
            DbCommand cmd = db.GetStoredProcCommand("dbo.DeleteBusiness");
            db.AddInParameter(cmd, "@BusinessId", DbType.Int32, Business.Id);
        }
        public static void Delete(TicketCategory TicketCategory)
        {
            DbCommand cmd = db.GetStoredProcCommand("dbo.DeleteTicketCategory");
            db.AddInParameter(cmd, "@TicketCategoryId", DbType.Int32, TicketCategory.Id);
        }
        public static void Delete(User User)
        {
            DbCommand cmd = db.GetStoredProcCommand("dbo.DeleteUser");
            db.AddInParameter(cmd, "@UserId", DbType.Int32, User.Id);
        }
    }
}
