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
    [RoutePrefix("businesses")]
    public class BusinessesController : WebApi.Controllers.BaseController
    {
        [Route]
        public IHttpActionResult Get()
        {
            return this.Ok(this.Context.Businesses.ToList().Select(i => BusinessConverter.ToDto(i)));
        }

        [Route("{businessId:int}")]
        public IHttpActionResult Get(int businessId)
        {
            Business existingBusiness = this.Context.Businesses.ToList().FirstOrDefault(i => i.Id == businessId);
            if (existingBusiness == null)
            {
                return this.NotFound();
            }
            else
            {
                return this.Ok(BusinessConverter.ToDto(existingBusiness));
            }
        }

        [Route]
        public IHttpActionResult Get(string email, string password)
        {
            Business existingBusiness = this.Context.Businesses.ToList().FirstOrDefault(i => (i.Email == email) && (i.Password == password));
            if (existingBusiness == null)
            {
                return this.NotFound();
            }
            else
            {
                return this.Ok(BusinessConverter.ToDto(existingBusiness));
            }
        }

        [Route("{businessId:int}/categories")]
        public IHttpActionResult GetCategories(int businessId)
        {
            Business existingBusiness = this.Context.Businesses.ToList().FirstOrDefault(i => i.Id == businessId);
            if (existingBusiness == null)
            {
                return this.NotFound();
            }
            else
            {
                return this.Ok(this.Context.TicketCategories.ToList().Where(i => i.BusinessId == existingBusiness.Id).Select(j => TicketCategoryConverter.ToDto(j)));
            }
        }

        [Route("{businessId:int}/tickets")]
        public IHttpActionResult GetTickets(int businessId)
        {
            Business existingBusiness = this.Context.Businesses.ToList().FirstOrDefault(i => i.Id == businessId);
            List<TicketCategory> existingBusinessTicketCategories = existingBusiness.Categories.ToList();
            if (existingBusiness == null || existingBusinessTicketCategories == null)
            {
                return this.NotFound();
            }
            else
            {
                return this.Ok(existingBusinessTicketCategories.SelectMany(i => i.Tickets.Select(j => TicketConverter.ToDto(j))));
            }
        }

        [Route]
        public IHttpActionResult Post(Dto.Business business)
        {
            if (business == null)
            {
                return this.BadRequest();
            }
            else
            {
                Business newBusiness = new Business(business.Name, business.Email, business.Password);
                this.Context.Businesses.Add(newBusiness);
                this.Context.SaveChanges();
                return this.Created(this.Request.RequestUri.AbsolutePath + "/" + newBusiness.Id, BusinessConverter.ToDto(newBusiness));
            }
        }

        [Route("{businessId:int}")]
        public IHttpActionResult Put(int businessId, Dto.Business business)
        {
            if (business == null)
            {
                return this.BadRequest();
            }
            else
            {
                Business existingBusiness = this.Context.Businesses.ToList().FirstOrDefault(i => i.Id == businessId);

                if (existingBusiness == null)
                {
                    return this.NotFound();
                }
                else
                {
                    existingBusiness.UpdateBusiness(business.Name, business.Email, business.Password);
                    this.Context.SaveChanges();
                    return this.Ok(BusinessConverter.ToDto(existingBusiness));
                }
            }
        }

        [Route("{businessId:int}")]
        public IHttpActionResult Delete(int businessId)
        {
            Business existingBusiness = this.Context.Businesses.ToList().FirstOrDefault(i => i.Id == businessId);
            if (existingBusiness == null)
            {
                return this.NotFound();
            }
            else
            {
                this.Context.Businesses.Remove(existingBusiness);
                this.Context.SaveChanges();
                return this.StatusCode(HttpStatusCode.NoContent);
            }
        }
    }
}
