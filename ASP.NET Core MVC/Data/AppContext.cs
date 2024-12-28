using ASP.NET_Core_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_MVC.Data
{
    public class AppContext : DbContext
    {
        #region Private properties
        private DbSet<Item> _items { get; set; }
        #endregion

        #region Constructor
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }
        #endregion

        #region Getters and Setters
        public DbSet<Item> Items
        {
            get => _items;
            set => _items = value;
        }
        #endregion
    }
}
