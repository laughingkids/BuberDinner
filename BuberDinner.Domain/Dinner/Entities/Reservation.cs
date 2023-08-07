using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.Enums;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Domain.Dinner.Entities;

public class Reservation : Entity<ReservationId>
{
    public DinnerId DinnerId { get; }
    public int GuestCount { get; }
    public GuestId GuestId { get; }
    public BillId? BillId { get; }
    public ReservationStatus ReservationStatus { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    public DateTime? ArrivalDateTime { get; }


    public Reservation(
        DinnerId dinnerId,
        GuestId guestId,
        int guestCount,
        DateTime? arrivalDateTime,
        BillId? billId,
        ReservationStatus  status) 
        : base(ReservationId.Create(dinnerId,guestId))
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        GuestCount = guestCount;
        ArrivalDateTime = arrivalDateTime;
        BillId = billId;
        ReservationStatus = status;
    }
    
    public static Reservation Create(
            DinnerId dinnerId,
            GuestId guestId,
            int guestCount,
            ReservationStatus  status,
            DateTime? arrivalDateTime = null,
            BillId? billId = null
            )
    {
        return new Reservation(
            dinnerId,
            guestId,
            guestCount,
            arrivalDateTime,
            billId,
            status);
    }
}