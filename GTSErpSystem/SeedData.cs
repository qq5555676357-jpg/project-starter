using GTSErpSystem.Data;
using GTSErpSystem.Models;
using System.Linq;

namespace GTSErpSystem
{
    public static class SeedData
    {
        public static void Initialize(GTSdbContext db)
        {
            // Create database if not exists
            db.Database.EnsureCreated();

            if (!db.Item_Items.Any())
            {
                db.Item_Items.Add(new Item_Items { ItemId = 1, Item_code = "ITM001", item_Name = "Sample Item 1", QuantityInStock = 100 });
                db.Item_Items.Add(new Item_Items { ItemId = 2, Item_code = "ITM002", item_Name = "Sample Item 2", QuantityInStock = 50 });
            }

            if (!db.Account_CostCenters.Any())
            {
                db.Account_CostCenters.Add(new Models.Account_CostCenters { CostCentersID = 1, CostCentersName = "Default" });
            }

            if (!db.Account_Stores.Any())
            {
                db.Account_Stores.Add(new Models.Account_Stores { ID = 1, Store_Name = "Main Store" });
            }

            if (!db.Order_Orders.Any())
            {
                db.Order_Orders.Add(new Order_Orders
                {
                    ID = 1,
                    PurBranchID = 1,
                    BranchID = 1,
                    SupplierID = 1,
                    SupplierName = "Supplier A",
                    Purchases_Date = System.DateTime.Now,
                    UserID_Add = GTSErpSystem.Helper.LoginDetails.UserID,
                    UserBranch_Add = GTSErpSystem.Helper.LoginDetails.BranchID,
                    UserMacAddress_Add = GTSErpSystem.Helper.LoginDetails.macAddress,
                    UserDate_Add = System.DateTime.Now,
                    TotalPrices = 100m,
                    CostOrder = 80m,
                    Net = 100m
                });
            }

            db.SaveChanges();
        }
    }
}
