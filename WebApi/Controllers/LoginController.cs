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
    [RoutePrefix("login")]
    public class LoginController : WebApi.Controllers.BaseController
    {
        [Route]
        public IHttpActionResult Get(string email, string password)
        {
            User existingUser = this.Context.Users.ToList().FirstOrDefault(i => (i.Email == email) && (i.Password == password));
            if (existingUser == null)
            {
                Business existingBusiness = this.Context.Businesses.ToList().FirstOrDefault(i => (i.Email == email) && (i.Password == password));
                if (existingBusiness == null || existingBusiness.ActiveAccount == false)
                {
                    return this.NotFound();
                }
                else
                {
                    return this.Ok(BusinessConverter.ToDto(existingBusiness));
                }
            }
            else
            {
                Business existingUsersBusiness = this.Context.Businesses.ToList().FirstOrDefault(i => i.Id == existingUser.BusinessId);
                if (existingUsersBusiness.ActiveAccount)
                {
                    return this.Ok(UserConverter.ToDto(existingUser));
                }
                else
                {
                    return this.NotFound();
                }
            }
        }
    }
}
