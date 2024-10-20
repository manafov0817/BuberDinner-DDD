using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate.Entities
{
    public class MenuItem : Entity<MenuItemId>
    {
        public MenuItem(MenuItemId id, string name, string description) : base(id)
        {
            Name = name;
            Description = description;
        }
        public string Name { get; }
        public string Description { get;  }
        public static MenuItem Create(string name, string description) => new(MenuItemId.CreateUnique(), name, description);
    }
}
