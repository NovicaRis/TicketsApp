using TicketsApp.Data.Base;
using TicketsApp.Models;

namespace TicketsApp.Data.Services
{
    public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(AppDbContext context) : base(context)
        {

        }
    }
}
