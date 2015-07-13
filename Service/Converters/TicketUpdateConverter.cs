using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dmn = Domain;
using Dto = Service.Dto;

namespace Service.Converters
{
    public static class TicketUpdateConverter
    {
        public static Dto.TicketUpdate ToDto(Dmn.TicketUpdate domain)
        {
            return new Dto.TicketUpdate()
            {
                Id = domain.Id,
                Content = domain.Content,
                CreatorId = domain.CreatorId,
                Creator = domain.Creator.FirstName + ' ' + domain.Creator.LastName,
                TicketId = domain.TicketId,
                DateCreated = domain.DateCreated,
            };
        }
    }
}
