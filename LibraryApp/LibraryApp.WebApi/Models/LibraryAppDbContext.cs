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

            //modelBuilder.Entity<User>()
            //  .HasMany(u => u.Books)
            //  .WithOne(b => b.User).IsRequired(false).OnDelete(DeleteBehavior.Cascade);


            //modelBuilder.Entity<Book>()
            // .HasOne(u => u.User)
            // .WithMany(b => b.Books)
            // .HasForeignKey(b => b.UserId).IsRequired (false);
           


        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //modelBuilder.Entity<Book>().ToTable("LibraryAppBooks");
        //modelBuilder.Entity<LibraryItem>().ToTable("LibraryItem");
        //}

    }
}
