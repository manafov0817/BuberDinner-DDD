using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.GuestAggregate.Entities
{
    public class GuestRating : Entity<GuestRatingId>
    {
        public GuestRating(GuestRatingId id, DinnerId dinnerId, HostId hostId) : base(id)
        {
            DinnerId = dinnerId;
            HostId = hostId;
        }
        public DinnerId DinnerId { get; }
        public HostId HostId { get; }
    }
}
