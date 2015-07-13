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
    [RoutePrefix("users")]
    public class UsersController : WebApi.Controllers.BaseController
    {
        [Route]
        public IHttpActionResult Get()
        {
            return this.Ok(this.Context.Users.ToList().Select(i => UserConverter.ToDto(i)));
        }

        [Route("{userId:int}")]
        public IHttpActionResult Get(int userId)
        {
            User existingUser = this.Context.Users.ToList().FirstOrDefault(i => i.Id == userId);
            if (existingUser == null)
            {
                return this.NotFound();
            }
            else
            {
                return this.Ok(UserConverter.ToDto(existingUser));
            }
        }

        [Route]
        public IHttpActionResult Get(string email, string password)
        {
            User existingUser = this.Context.Users.ToList().FirstOrDefault(i => (i.Email == email) && (i.Password == password));
            if (existingUser == null)
            {
                return this.NotFound();
            }
            else
            {
                return this.Ok(UserConverter.ToDto(existingUser));
            }
        }

        [Route]
        public IHttpActionResult Post(Dto.User user)
        {
            if (user == null)
            {
                return this.BadRequest();
            }
            else
            {
                Business existingBusiness = this.Context.Businesses.ToList().FirstOrDefault(i => i.Id == user.BusinessId);
                if (existingBusiness == null)
                {
                    return this.BadRequest();
                }
                else
                {
                    User newUser = existingBusiness.CreateNewUserAccount(user.FirstName, user.LastName, user.Email, user.Password);
                    this.Context.Users.Add(newUser);
                    this.Context.SaveChanges();
                    return this.Created(this.Request.RequestUri.AbsolutePath + "/" + newUser.Id, UserConverter.ToDto(newUser));
                }
            }
        }

        [Route("{userId:int}")]
        public IHttpActionResult Put(int userId, Dto.User user)
        {
            if (user == null)
            {
                return this.BadRequest();
            }
            else
            {
                User existingUser = this.Context.Users.ToList().FirstOrDefault(i => i.Id == userId);
                if (existingUser == null)
                {
                    return this.NotFound();
                }
                else
                {
                    existingUser.UpdateUser(user.FirstName, user.LastName, user.Email, user.Password);
                    this.Context.SaveChanges();
                    return this.Ok(UserConverter.ToDto(existingUser));
                }
            }
        }

        [Route("{userId:int}")]
        public IHttpActionResult Delete(int userId)
        {
            User existingUser = this.Context.Users.ToList().FirstOrDefault(i => i.Id == userId);
            if (existingUser == null)
            {
                return this.NotFound();
            }
            else
            {
                this.Context.Users.Remove(existingUser);
                this.Context.SaveChanges();
                return this.StatusCode(HttpStatusCode.NoContent);
            }
        }
    }
}
