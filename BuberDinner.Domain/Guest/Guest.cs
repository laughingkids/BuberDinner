using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.Entities;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using ErrorOr;

namespace BuberDinner.Domain.Guest;

public class Guest : AggregateRoot<GuestId>
{
    private readonly List<DinnerId> _upcomingDinnerIds = new();
    private readonly List<DinnerId> _pastDinnerIds = new();
    private readonly List<DinnerId> _pendingDinnerIds = new();
    private readonly List<BillId> _billIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    private readonly List<GuestRating> _ratings = new();

    public string FirstName { get; }
    public string LastName { get; }
    public UserId UserId { get; }
    public Uri ProfileImage { get; }
    public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds;
    public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds;
    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds;
    public IReadOnlyList<BillId> BillIds => _billIds;
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds;
    public IReadOnlyList<GuestRating> Ratings => _ratings;
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Guest(
        string firstName, 
        string lastName, 
        Uri profileImage,
        UserId userId,
        GuestRating? guestRating = null,
        GuestId? guestId = null) : base(guestId ?? GuestId.Create(userId))
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        UserId = userId;
    }
    
    public static Guest Create(
        string firstName, 
        string lastName, 
        Uri profileImage, 
        UserId userId)
    {
        return new Guest(firstName, lastName, profileImage, userId);
    }
}