using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dmn = Domain;
using Dto = Service.Dto;

namespace Service.Converters
{
    public static class TicketCategoryConverter
    {
        public static Dto.TicketCategory ToDto(Dmn.TicketCategory domain)
        {
            return new Dto.TicketCategory()
            {
                Id = domain.Id,
                Name = domain.Name,
                BusinessId = domain.BusinessId,
                NumberOfTickets = domain.NumberOfTickets,
                DateCreated = domain.DateCreated
            };
        }
    }
}
