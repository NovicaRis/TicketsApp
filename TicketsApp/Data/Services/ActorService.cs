using Microsoft.EntityFrameworkCore;
using TicketsApp.Data.Base;
using TicketsApp.Models;

namespace TicketsApp.Data.Services
{
    public class ActorService : EntityBaseRepository<Actor>,IActorsService
    {
        
        public ActorService(AppDbContext context) : base(context) { }
       

    }
}
