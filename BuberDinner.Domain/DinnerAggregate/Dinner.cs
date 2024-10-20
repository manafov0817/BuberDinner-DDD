using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.Entities;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.Dinner
{
    public sealed class Dinner : AggregateRoot<DinnerId>
    {
        public Dinner(DinnerId id, HostId hostId,  MenuId menuId) : base(id)
        {
            HostId = hostId;    
            MenuId = menuId;
        }
        public HostId HostId { get; set; }
        public MenuId MenuId { get; set; }

        private readonly List<Reservation> _reservations = new();
        public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();
    }
}
