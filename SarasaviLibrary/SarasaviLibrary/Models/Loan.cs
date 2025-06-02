// Models/Loan.cs
using System.ComponentModel.DataAnnotations;

public class Loan
{
    public int Id { get; set; }

    public int BookCopyId { get; set; }
    public virtual BookCopy BookCopy { get; set; }

    public int UserId { get; set; }
    public virtual User User { get; set; }

    [Display(Name = "Loan Date")]
    public DateTime LoanDate { get; set; } = DateTime.Now;

    [Display(Name = "Due Date")]
    public DateTime DueDate { get; set; } = DateTime.Now.AddDays(14);

    [Display(Name = "Return Date")]
    public DateTime? ReturnDate { get; set; }

    [Display(Name = "Status")]
    public LoanStatus Status { get; set; } = LoanStatus.Active;
}

public enum LoanStatus
{
    Active,
    Returned,
    Overdue
}

// Models/Reservation.cs
