using ASP.NET_Core_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_MVC.Data
{
    public class AppContext : DbContext
    {
        #region Private properties
        private DbSet<Item> _items { get; set; }
        private DbSet<SerialNumber> _serialNumbers { get; set; }
        private DbSet<Category> _categories { get; set; }
        #endregion

        #region Constructor
        public AppContext(DbContextOptions<AppContext> options) : base(options) { }
        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData
                (
                new Item { Id = 4, Name="Laptop", Price=1000, SerialNumberId=10 }
                );
            modelBuilder.Entity<SerialNumber>().HasData
                (
                new SerialNumber { Id = 10, Name = "1234Laptop56", ItemId = 4 }
                );
            modelBuilder.Entity<Category>().HasData
                (
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Clothing" }
                );
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region Getters and Setters
        public DbSet<Item> Items
        {
            get => _items;
            set => _items = value;
        }

        public DbSet<SerialNumber> SerialNumbers
        {
            get => _serialNumbers;
            set => _serialNumbers = value;
        }

        public DbSet<Category> Categories
        {
            get => _categories;
            set => _categories = value;
        }
        #endregion
    }
}
