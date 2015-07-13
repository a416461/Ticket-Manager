using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dmn = Domain;
using Dto = Service.Dto;

namespace Service.Converters
{
    public static class BusinessConverter
    {
        public static Dto.Business ToDto(Dmn.Business domain)
        {
            return new Dto.Business()
            {
                Id = domain.Id,
                Name = domain.Name,
                ActiveAccount = domain.ActiveAccount,
                AccountType = "business"
            };
        }
    }
}
