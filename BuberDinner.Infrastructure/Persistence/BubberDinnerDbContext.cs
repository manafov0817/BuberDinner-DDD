using BuberDinner.Domain.MenuAggregate;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence
{
    public class BubberDinnerDbContext : DbContext
    {
        public BubberDinnerDbContext(DbContextOptions<BubberDinnerDbContext> options) : base(options) { }

        public DbSet<Menu> Menus { get; set; }

    }
}
