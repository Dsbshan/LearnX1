// Models/LibraryContext.cs
using System.Data.Entity;

public class LibraryContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<BookCopy> BookCopies { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // Configure relationships and constraints
        modelBuilder.Entity<Book>()
            .HasMany(b => b.Copies)
            .WithRequired(c => c.Book)
            .HasForeignKey(c => c.BookId);

        modelBuilder.Entity<BookCopy>()
            .HasMany(c => c.Loans)
            .WithRequired(l => l.BookCopy)
            .HasForeignKey(l => l.BookCopyId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Loans)
            .WithRequired(l => l.User)
            .HasForeignKey(l => l.UserId);

        modelBuilder.Entity<Book>()
            .HasMany(b => b.Reservations)
            .WithRequired(r => r.Book)
            .HasForeignKey(r => r.BookId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Reservations)
            .WithRequired(r => r.User)
            .HasForeignKey(r => r.UserId);

        base.OnModelCreating(modelBuilder);
    }
}