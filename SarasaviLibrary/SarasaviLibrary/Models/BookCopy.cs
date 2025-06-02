using SarasaviLibrary.Models;
using System.ComponentModel.DataAnnotations;

public class BookCopy
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Copy Number")]
    [RegularExpression(@"^X\d{4}-\d+$", ErrorMessage = "Copy number must be in format X9999-1")]
    public string CopyNumber { get; set; }

    [Display(Name = "Is Reference Only")]
    public bool IsReferenceOnly { get; set; }

    [Display(Name = "Status")]
    public BookCopyStatus Status { get; set; } = BookCopyStatus.Available;

    public int BookId { get; set; }
    public virtual Book Book { get; set; }

    public virtual ICollection<Loan> Loans { get; set; }
    public virtual ICollection<Reservation> Reservations { get; set; }
}