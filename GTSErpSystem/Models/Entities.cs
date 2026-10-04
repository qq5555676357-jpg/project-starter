using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTSErpSystem.Models
{
    public class Account_AccountType
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class Account_CostCenters
    {
        [Key]
        public int CostCentersID { get; set; }
        public string CostCentersName { get; set; }
    }

    public class Account_Stores
    {
        [Key]
        public int ID { get; set; }
        public string Store_Name { get; set; }
    }

    public class Item_Items
    {
        [Key]
        public int ItemId { get; set; }
        public string Item_code { get; set; }
        public string item_Name { get; set; }
        public string item_Name_English { get; set; }
        public int Category_ID { get; set; }
        public int item_Type { get; set; }
        public string SmallBarCode1 { get; set; }
        public string SmallBarCode2 { get; set; }
        public string SmallBarCode3 { get; set; }
        public string MediumBarCode1 { get; set; }
        public string MediumBarCode2 { get; set; }
        public string MediumBarCode3 { get; set; }
        public string BigBarCode1 { get; set; }
        public string BigBarCode2 { get; set; }
        public string BigBarCode3 { get; set; }
        public decimal Average_cost { get; set; }
        public decimal SellPriceSmall { get; set; }
        public decimal SellPriceSmall2 { get; set; }
        public decimal SellPriceSmall3 { get; set; }
        public decimal SellPriceMedium { get; set; }
        public decimal SellPriceMedium2 { get; set; }
        public decimal SellPriceMedium3 { get; set; }
        public decimal SellpriceLarge { get; set; }
        public decimal SellpriceLarge2 { get; set; }
        public decimal SellpriceLarge3 { get; set; }
        public decimal LastCost { get; set; }
        public decimal LastCost2 { get; set; }
        public decimal LastCost3 { get; set; }
        public decimal ConvertMediumUnit { get; set; } = 1m;
        public decimal ConvertBigUnit { get; set; } = 1m;
        public decimal QuantityInStock { get; set; }
    }

    public class ItemQuantity
    {
        [Key]
        public int ItemQuantityID { get; set; }
        public int ItemID { get; set; }
        public int StoreID { get; set; }
        public decimal? OpeningBalance { get; set; }
        public decimal? BeginningInventory { get; set; }
        public decimal? BeginningInventoryPrice { get; set; }
        public decimal? CurrentBalance { get; set; }
    }

    public class Printer
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class Order_Orders
    {
        [Key]
        public int ID { get; set; }
        public int PurBranchID { get; set; }
        public int BranchID { get; set; }
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string SupplierPhone { get; set; }
        public string SupplierVatNum { get; set; }
        public DateTime Purchases_Date { get; set; }
        public int Order_Paymant_Type { get; set; }
        public int CostCentersID { get; set; }
        public string Note { get; set; }
        public string NoteNum { get; set; }
        public bool IsWaiting { get; set; }
        public decimal CostOrder { get; set; }
        public decimal TotalPrices { get; set; }
        public decimal Tax { get; set; }
        public decimal Safy { get; set; }
        public decimal DiscountNum { get; set; }
        public decimal DiscountPerantage { get; set; }
        public decimal Tax_Discount { get; set; }
        public decimal TotalPrices_Discount { get; set; }
        public decimal Net { get; set; }
        public decimal CashMoney { get; set; }
        public decimal CashBank { get; set; }
        public bool OrderCashierType { get; set; }
        public int RoomNum { get; set; }
        public int TableNum { get; set; }
        public int UserID_Add { get; set; }
        public int UserBranch_Add { get; set; }
        public string UserMacAddress_Add { get; set; }
        public DateTime UserDate_Add { get; set; }
    }

    public class Order_OrdersDetails
    {
        [Key]
        public int ID { get; set; }
        public int Purchese_ID { get; set; }
        public int ItemID { get; set; }
        public int BranchID { get; set; }
        public int StoreID { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public string ItemUnitType { get; set; }
        public bool IsPrint { get; set; }
        public bool IsPrintCook { get; set; }
    }
}
