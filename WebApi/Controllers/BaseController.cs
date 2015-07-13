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
    public class BaseController : ApiController
    {
        protected EarlyBirdsContext Context = new EarlyBirdsContext();
    }
}