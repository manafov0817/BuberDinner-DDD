using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.UserAggregate
{
    public sealed class User : AggregateRoot<UserId>
    {
        public User(UserId id, HostId hostId, GuestId guestId) : base(id)
        {
            GuestId = guestId;
            HostId = hostId;
        }
        public HostId HostId { get; set; }
        public GuestId GuestId { get; set; }
    }
}
