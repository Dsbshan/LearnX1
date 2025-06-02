// Models/User.cs
using SarasaviLibrary.Models;
using System.ComponentModel.DataAnnotations;

public class User
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "User Number")]
    public string UserNumber { get; set; }

    [Required]
    public string Name { get; set; }

    public string Sex { get; set; }

    [Display(Name = "NIC Number")]
    public string NicNumber { get; set; }

    public string Address { get; set; }

    [Display(Name = "Is Member")]
    public bool IsMember { get; set; } = true;

    public DateTime RegistrationDate { get; set; } = DateTime.Now;

    public virtual ICollection<Loan> Loans { get; set; }
    public virtual ICollection<Reservation> Reservations { get; set; }
}