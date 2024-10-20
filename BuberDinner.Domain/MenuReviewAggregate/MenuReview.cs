using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.MenuReview
{
    public sealed class MenuReview : AggregateRoot<MenuReviewId>
    {
        public MenuReview(MenuReviewId id, MenuId menuId, HostId hostId, GuestId guestId) : base(id)
        {
            MenuId = menuId;
            HostId = hostId;
            GuestId = guestId;
        }
        public MenuId MenuId { get; }
        public HostId HostId { get; }
        public GuestId GuestId { get; set; }
    }
}
