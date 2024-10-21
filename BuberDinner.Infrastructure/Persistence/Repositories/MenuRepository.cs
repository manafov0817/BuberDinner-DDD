using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.MenuAggregate;

namespace BuberDinner.Infrastructure.Persistence.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly BubberDinnerDbContext _dbContext;

        public MenuRepository(BubberDinnerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Menu menu)
        {
            _dbContext.Menus.Add(menu);
            _dbContext.SaveChanges();
        }
    }
}
