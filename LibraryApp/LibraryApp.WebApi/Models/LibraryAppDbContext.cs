using Microsoft.EntityFrameworkCore;

namespace LibraryApp.WebApi.Models
{
    public class LibraryAppDbContext : DbContext
    {
        public LibraryAppDbContext(DbContextOptions<LibraryAppDbContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<LibraryItem> Items { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //modelBuilder.Entity<Book>().ToTable("LibraryAppBooks");
        //modelBuilder.Entity<LibraryItem>().ToTable("LibraryItem");
        //}

    }
}
