using TicketsApp.Data.Base;
using TicketsApp.Models;

namespace TicketsApp.Data.Services
{
    public class ProducersService : EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService(AppDbContext context) : base(context)
        {

        }
    }
}
