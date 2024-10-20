using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate.Entities
{
    public class MenuSection : Entity<MenuSectionId>
    {
        public MenuSection(MenuSectionId id, string name, string description, List<MenuItem> menuItems) : base(id)
        {
            Name = name;
            Description = description;
            _items = menuItems;
        }

        private readonly List<MenuItem> _items = new();
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();
        public static MenuSection Create(string name, string description, List<MenuItem> menuItems) => new(MenuSectionId.CreateUnique(), name, description, menuItems);
    }
}
