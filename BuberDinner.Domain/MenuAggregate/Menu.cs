using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.MenuAggregate.Entities;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        public Menu(MenuId menuId,
                    string name,
                    string description,
                    HostId hostId,
                    AverageRating rating,
                    List<MenuSection>? menuSections,
                    DateTime createdDateTime,
                    DateTime updatedDateTime) : base(menuId)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
            _sections = menuSections;
        }

        public HostId HostId { get; }
        public string Name { get; }
        public string Description { get; }
        public AverageRating AverageRating { get;   }

        private readonly List<MenuSection> _sections = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();
        private readonly List<DinnerId> _dinnerIds = new();
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }
        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public static Menu Create(string name,
                                  string description,
                                  HostId hostId,
                                  List<MenuSection>? menuSections)
        {
            return new Menu(MenuId.CreateUnique(),
                            name,
                            description,
                            hostId,
                            AverageRating.CreateNew(5,1),
                            menuSections,
                            DateTime.Now,
                            DateTime.Now);
        }
    }
}
