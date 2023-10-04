using Microsoft.EntityFrameworkCore;

namespace LibraryApp.WebApi.Models
{
    public class LibraryAppDbContext : DbContext
    {
        public LibraryAppDbContext(DbContextOptions<LibraryAppDbContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
              .HasMany(u => u.Books)
              .WithOne(b => b.User)

            //modelBuilder.Entity<Book>()
             //.HasMany(u => u.Books)
             //.WithOne(b => b.User)

          .OnDelete(DeleteBehavior.Cascade);

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //modelBuilder.Entity<Book>().ToTable("LibraryAppBooks");
        //modelBuilder.Entity<LibraryItem>().ToTable("LibraryItem");
        //}

    }
}
