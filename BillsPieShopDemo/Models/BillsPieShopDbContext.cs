using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BillsPieShopDemo.Models
{
    public class BillsPieShopDbContext: IdentityDbContext
    {
        // Constructor
        public BillsPieShopDbContext(DbContextOptions<BillsPieShopDbContext> options) : base(options)
        {
        }

        // DbSets
        public DbSet<Pie> Pies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
