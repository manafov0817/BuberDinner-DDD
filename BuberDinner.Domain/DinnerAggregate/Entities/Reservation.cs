using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate.Entities
{
    public class Reservation : Entity<ReservationId>
    {
        public Reservation(ReservationId id, GuestId guestId, BillId billId) : base(id)
        {
            GuestId = guestId;
            BillId = billId;
        }

        public GuestId GuestId { get; set; }
        public BillId BillId { get; set; }
    }
}
