using Domain;
using Service.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using Dto = Service.Dto;

namespace WebApi.Controllers
{
    [RoutePrefix("tickets")]
    public class TicketsController : WebApi.Controllers.BaseController
    {
        [Route]
        public IHttpActionResult Get()
        {
            return this.Ok(this.Context.Tickets.ToList().Select(i => TicketConverter.ToDto(i)));
        }

        [Route("{ticketId:int}")]
        public IHttpActionResult Get(int ticketId)
        {
            Ticket existingTicket = this.Context.Tickets.ToList().FirstOrDefault(i => i.Id == ticketId);
            if (existingTicket == null)
            {
                return this.NotFound();
            }
            else
            {
                return this.Ok(TicketConverter.ToDto(existingTicket));
            }
        }

        [Route("{ticketId:int}/updates")]
        public IHttpActionResult GetUpdates(int ticketId)
        {
            Ticket existingTicket = this.Context.Tickets.ToList().FirstOrDefault(i => i.Id == ticketId);
            if (existingTicket == null)
            {
                return this.NotFound();
            }
            else
            {
                return this.Ok(this.Context.TicketUpdates.ToList().Where(i => i.TicketId == existingTicket.Id).Select(j => TicketUpdateConverter.ToDto(j)));
            }
        }

        [Route("search/{pattern}")]
        public IHttpActionResult Get(string pattern)
        {
            if (pattern == null)
            {
                return this.BadRequest();
            }
            else
            {
                return this.Ok(this.Context.Tickets.ToList().Where(i => Regex.IsMatch(i.Title, pattern, RegexOptions.IgnoreCase)).Select(i => TicketConverter.ToDto(i)));
            }
        }

        [Route]
        public IHttpActionResult Post(Dto.Ticket ticket)
        {
            if (ticket == null)
            {
                return this.BadRequest();
            }
            else
            {
                TicketCategory existingTicketCategory = this.Context.TicketCategories.ToList().FirstOrDefault(i => i.Id == ticket.CategoryId);
                Business existingBusiness = this.Context.Businesses.ToList().FirstOrDefault(i => i.Id == existingTicketCategory.BusinessId);
                User existingUser = this.Context.Users.ToList().FirstOrDefault(i => i.Id == ticket.CreatorId);
                if (existingTicketCategory == null || existingBusiness == null || existingUser == null)
                {
                    return this.BadRequest();
                }
                else
                {
                    Ticket newTicket = existingBusiness.CreateNewTicket(ticket.Title, ticket.Content, existingTicketCategory.Id, ticket.Priority, ticket.CreatorId);
                    this.Context.Tickets.Add(newTicket);
                    this.Context.SaveChanges();
                    return this.Created(this.Request.RequestUri.AbsolutePath + "/" + newTicket.Id, TicketConverter.ToDto(newTicket));
                }
            }
        }

        [Route("{ticketId:int}/updates")]
        public IHttpActionResult Post(int ticketId, Dto.TicketUpdate update)
        {
            Ticket existingTicket = this.Context.Tickets.ToList().FirstOrDefault(i => i.Id == ticketId);
            TicketCategory existingCategory = this.Context.TicketCategories.ToList().FirstOrDefault(i => i.Id == existingTicket.CategoryId);
            User existingUser = this.Context.Users.ToList().FirstOrDefault(i => i.Id == update.CreatorId);

            if (existingTicket == null || existingCategory == null)
            {
                return this.NotFound();
            }
            else if (existingUser == null)
            {
                return this.Unauthorized();
            }
            else if ((existingCategory.BusinessId != existingUser.BusinessId) || (existingTicket.Status == TicketStatus.Closed))
            {
                return this.BadRequest();
            }
            else
            {
                TicketUpdate newTicketUpdate = existingTicket.CreateNewTicketUpdate(update.Content, update.CreatorId);
                this.Context.TicketUpdates.Add(newTicketUpdate);
                this.Context.SaveChanges();
                return this.Created(this.Request.RequestUri.AbsolutePath + "/" + newTicketUpdate.Id, TicketUpdateConverter.ToDto(newTicketUpdate));
            }
        }

        [Route("{ticketId:int}")]
        public IHttpActionResult Put(int ticketId, Dto.Ticket ticket)
        {
            if (ticket == null)
            {
                return this.BadRequest();
            }
            else
            {
                Ticket existingTicket = this.Context.Tickets.ToList().FirstOrDefault(i => i.Id == ticketId);
                if (existingTicket == null)
                {
                    return this.NotFound();
                }
                else
                {
                    existingTicket.UpdateTicket(ticket.Title, ticket.CategoryId, ticket.Priority, ticket.Status);
                    this.Context.SaveChanges();
                    return this.Ok(TicketConverter.ToDto(existingTicket));
                }
            }
        }

        [Route("{ticketId:int}")]
        public IHttpActionResult Delete(int ticketId)
        {
            Ticket existingTicket = this.Context.Tickets.ToList().FirstOrDefault(i => i.Id == ticketId);
            if (existingTicket == null)
            {
                return this.BadRequest();
            }
            else
            {
                existingTicket.UpdateTicket(existingTicket.Title, existingTicket.CategoryId, existingTicket.Priority, TicketStatus.Closed);
                this.Context.SaveChanges();
                return this.StatusCode(HttpStatusCode.NoContent);
            }
        }
    }
}
