using System.ComponentModel.DataAnnotations;

public class Reservation
{
    public int Id { get; set; }

    public int BookId { get; set; }
    public virtual Book Book { get; set; }

    public int UserId { get; set; }
    public virtual User User { get; set; }

    [Display(Name = "Reservation Date")]
    public DateTime ReservationDate { get; set; } = DateTime.Now;

    [Display(Name = "Status")]
    public ReservationStatus Status { get; set; } = ReservationStatus.Pending;

    [Display(Name = "Notification Sent")]
    public bool NotificationSent { get; set; } = false;
}

public enum ReservationStatus
{
    Pending,
    Fulfilled,
    Cancelled
}