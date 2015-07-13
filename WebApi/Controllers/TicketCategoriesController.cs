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
    [RoutePrefix("categories")]
    public class TicketCategoriesController : WebApi.Controllers.BaseController
    {
        [Route]
        public IHttpActionResult Get()
        {
            return this.Ok(this.Context.TicketCategories.ToList().Select(i => TicketCategoryConverter.ToDto(i)));
        }

        [Route("{categoryId:int}")]
        public IHttpActionResult Get(int categoryId)
        {
            TicketCategory existingCategory = this.Context.TicketCategories.ToList().FirstOrDefault(i => i.Id == categoryId);
            if (existingCategory == null)
            {
                return this.NotFound();
            }
            else
            {
                return this.Ok(TicketCategoryConverter.ToDto(existingCategory));
            }
        }

        [Route("{name}")]
        public IHttpActionResult Get(string name)
        {
            if (name == null)
            {
                return this.BadRequest();
            }
            else
            {
                TicketCategory existingCategory = this.Context.TicketCategories.ToList().FirstOrDefault(i => i.Name.ToLower() == name.ToLower());
                if (existingCategory == null)
                {
                    return this.NotFound();
                }
                else
                {
                    return this.Ok(TicketCategoryConverter.ToDto(existingCategory));
                }
            }
        }

        [Route]
        public IHttpActionResult Post(Dto.TicketCategory category)
        {
            if (category == null)
            {
                return this.BadRequest();
            }
            else
            {
                Business existingBusiness = this.Context.Businesses.ToList().FirstOrDefault(i => i.Id == category.BusinessId);

                if (existingBusiness == null)
                {
                    return this.BadRequest();
                }
                else
                {
                    TicketCategory newTicketCategory = existingBusiness.CreateNewTicketCategory(category.Name);
                    this.Context.TicketCategories.Add(newTicketCategory);
                    this.Context.SaveChanges();

                    return this.Created(this.Request.RequestUri.AbsolutePath + "/" + newTicketCategory.Id, TicketCategoryConverter.ToDto(newTicketCategory));
                }
            }
        }

        [Route("{categoryId:int}")]
        public IHttpActionResult Put(int categoryId, Dto.TicketCategory category)
        {
            if (category == null)
            {
                return this.BadRequest();
            }
            else
            {
                TicketCategory existingTicketCategory = this.Context.TicketCategories.ToList().FirstOrDefault(i => i.Id == categoryId);
                if (existingTicketCategory == null)
                {
                    return this.NotFound();
                }
                else
                {
                    existingTicketCategory.UpdateTicketCategory(category.Name);
                    this.Context.SaveChanges();
                    return this.Ok(TicketCategoryConverter.ToDto(existingTicketCategory));
                }
            }
        }

        [Route("{categoryId:int}")]
        public IHttpActionResult Delete(int categoryId)
        {
            TicketCategory existingTicketCategory = this.Context.TicketCategories.ToList().FirstOrDefault(i => i.Id == categoryId);

            if (existingTicketCategory == null)
            {
                return this.NotFound();
            }
            else
            {
                this.Context.TicketCategories.Remove(existingTicketCategory);
                this.Context.SaveChanges();
                return this.StatusCode(HttpStatusCode.NoContent);
            }
        }
    }
}
