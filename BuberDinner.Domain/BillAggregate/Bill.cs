using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.BillAggregate
{
    public sealed class Bill : AggregateRoot<BillId>
    {
        public Bill(BillId id, DinnerId dinnerId, GuestId guestId, HostId hostId) : base(id)
        {
            DinnerId = dinnerId;
            GuestId = guestId;
            HostId = hostId;
        }   

        public DinnerId DinnerId { get; }
        public HostId HostId { get; }
        public GuestId GuestId { get; }
    }
}
