using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.Host
{
    public sealed class Host : AggregateRoot<HostId>
    {
        public Host(HostId id, UserId userId) : base(id)
        {
            UserId = userId;
        }
        private readonly List<MenuId> _menuIds = new();
        private readonly List<DinnerId> _dinnerIds = new();
        public IReadOnlyList<MenuId> Sections => _menuIds.AsReadOnly();
        public IReadOnlyList<DinnerId> MenuReviewIds => _dinnerIds.AsReadOnly();
        public UserId UserId { get; }
    }
}
