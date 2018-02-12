using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using LibraryAutomationSystem.Models.Mapping;

namespace LibraryAutomationSystem.Models
{
    public partial class LibraryDbContext : DbContext
    {
        static LibraryDbContext()
        {
            Database.SetInitializer<LibraryDbContext>(null);
        }

        public LibraryDbContext()
            : base("Name=LibraryDbContext")
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> Book_Author { get; set; }
        public DbSet<Book_Publisher> Book_Publisher { get; set; }
        public DbSet<BookOperation> BookOperations { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PasswordRecovery> PasswordRecoveries { get; set; }
        public DbSet<Penalty> Penalties { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BookView> BookViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuthorMap());
            modelBuilder.Configurations.Add(new Book_AuthorMap());
            modelBuilder.Configurations.Add(new Book_PublisherMap());
            modelBuilder.Configurations.Add(new BookOperationMap());
            modelBuilder.Configurations.Add(new BookMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new PasswordRecoveryMap());
            modelBuilder.Configurations.Add(new PenaltyMap());
            modelBuilder.Configurations.Add(new PublisherMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new BookViewMap());
        }
    }
}
