using Microsoft.EntityFrameworkCore;
using GTSErpSystem.Helper;

namespace GTSErpSystem
{
    public class GTSdbEntities : DbContext
    {
        public DbSet<Account_AccountType> Account_AccountType { get; set; }
        public DbSet<Account_CostCenters> Account_CostCenters { get; set; }
        public DbSet<Contract_Bounce> Contract_Bounce { get; set; }
        public DbSet<User_SellPrice> User_SellPrice { get; set; }
        public DbSet<Item_Items> Item_Items { get; set; }
        public DbSet<Item_Groups> Item_Groups { get; set; }
        public DbSet<Printer> Printers { get; set; }
        public DbSet<Item_ItemComponent> Item_ItemComponent { get; set; }
        public DbSet<ItemQuantity> ItemQuantities { get; set; }
        public DbSet<Order_Orders> Order_Orders { get; set; }
        public DbSet<Order_OrdersDetails> Order_OrdersDetails { get; set; }
        public DbSet<Item_Unit> Item_Unit { get; set; }
        public DbSet<Account_Stores> Account_Stores { get; set; }
        public DbSet<TblSetting> TblSettings { get; set; }
        public DbSet<Restaurant_Room> Restaurant_Room { get; set; }
        public DbSet<Restaurant_Table> Restaurant_Table { get; set; }
        public DbSet<Restaurant_Delivery> Restaurant_Delivery { get; set; }
        public DbSet<Tran_Tran> Tran_Tran { get; set; }
        public DbSet<Tran_TranDetails> Tran_TranDetails { get; set; }
        public DbSet<Order_Reservations> Order_Reservations { get; set; }
        public DbSet<Order_Extension> Order_Extension { get; set; }
        public DbSet<Order_OrdersDraft> Order_OrdersDraft { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer($"Data Source={LoginDetails.nameServer};Initial Catalog={LoginDetails.databaseServer};Persist Security Info=True;User ID={LoginDetails.userNameServer};Password={LoginDetails.passServer};");
            }
        }

        public IEnumerable<Select_SearchAccountCostCenter_Result> Select_SearchAccountCostCenter(int branchId)
            => new List<Select_SearchAccountCostCenter_Result>();

        public IEnumerable<Select_Order_Orders_Result> Select_Order_Orders(int branchId)
            => new List<Select_Order_Orders_Result>();

        public IEnumerable<Select_Order_OrdersDraft_Result> Select_Order_OrdersDraft(int branchId)
            => new List<Select_Order_OrdersDraft_Result>();

        public IEnumerable<Get_Item_ByCodeALL_Result> Get_Item_ByCodeALL(string code, int branchId)
            => new List<Get_Item_ByCodeALL_Result>();

        public IEnumerable<GetAllitems_Alternatives_Result> GetAllitems_Alternatives(int itemId, int storeId, int unitType)
            => new List<GetAllitems_Alternatives_Result>();

        public IEnumerable<GetLastOrderDetailsByItemID_Result> GetLastOrderDetailsByItemID(int itemId)
            => new List<GetLastOrderDetailsByItemID_Result>();

        public IEnumerable<string> GetUnitNameByID(int id)
            => new List<string>();
    }
}
