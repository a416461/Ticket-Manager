using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dmn = Domain;
using Dto = Service.Dto;

namespace Service.Converters
{
    public static class UserConverter
    {
        public static Dto.User ToDto(Dmn.User domain)
        {
            return new Dto.User()
            {
                Id = domain.Id,
                FirstName = domain.FirstName,
                LastName = domain.LastName,
                BusinessId = domain.BusinessId,
                AccountType = "user"
            };
        }
    }
}
