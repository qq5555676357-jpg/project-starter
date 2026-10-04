using GTSErpSystem.Helper;
using Microsoft.EntityFrameworkCore;

namespace GTSErpSystem.Data
{
    public class GTSdbContext : DbContext
    {
        public DbSet<Account_AccountType> Account_AccountType { get; set; }
        public DbSet<Account_CostCenters> Account_CostCenters { get; set; }
        public DbSet<Item_Items> Item_Items { get; set; }
        public DbSet<ItemQuantity> ItemQuantities { get; set; }
        public DbSet<Order_Orders> Order_Orders { get; set; }
        public DbSet<Order_OrdersDetails> Order_OrdersDetails { get; set; }
        public DbSet<Account_Stores> Account_Stores { get; set; }
        public DbSet<Printer> Printers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer($"Data Source={LoginDetails.nameServer};Initial Catalog={LoginDetails.databaseServer};Persist Security Info=True;User ID={LoginDetails.userNameServer};Password={LoginDetails.passServer};");
            }
        }
    }
}
