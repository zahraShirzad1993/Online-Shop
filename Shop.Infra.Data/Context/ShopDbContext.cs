using Microsoft.EntityFrameworkCore;
using Shop.Domain.Models.Account;
using Shop.Domain.Models.Order;
using Shop.Domain.Models.OrderEntity;
using Shop.Domain.Models.ProductEntity;

namespace Shop.Infra.Data.Context
{
    public class ShopDbContext : DbContext
    {
        #region Construtor
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {

        }
        #endregion

        #region User
        public DbSet<User> Users { get; set; }
        #endregion

        #region Product
        public DbSet<Prodcut> prodcuts { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        #endregion

        #region OrderFactor
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        #endregion


    }
}
