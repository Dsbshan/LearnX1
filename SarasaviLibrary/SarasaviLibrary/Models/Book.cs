using SarasaviLibrary.Models;
using System.ComponentModel.DataAnnotations;

public class Book
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Book Number")]
    [RegularExpression(@"^X\d{4}$", ErrorMessage = "Book number must be in format X9999")]
    public string BookNumber { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Author { get; set; }

    public string Publisher { get; set; }

    [Display(Name = "ISBN")]
    public string ISBN { get; set; }

    [Display(Name = "Classification")]
    public string Classification { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; }

    public virtual ICollection<BookCopy> Copies { get; set; }
}