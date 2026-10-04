using System;
using System.Collections.Generic;
using System.Linq;
using GTSErpSystem.Data;
using GTSErpSystem.Models;

namespace GTSErpSystem.BLL
{
    public class Class_Orders
    {
        private readonly GTSdbContext _db;

        public Class_Orders(GTSdbContext db)
        {
            _db = db;
        }

        public List<Account_AccountType> GetAccountType()
        {
            return _db.Account_AccountType.ToList();
        }

        public string GetAccountNameById(int id)
        {
            return _db.Account_AccountType.FirstOrDefault(x => x.ID == id)?.Name ?? string.Empty;
        }

        public string GetCostCenterByID(int id)
        {
            return _db.Account_CostCenters.FirstOrDefault(x => x.CostCentersID == id)?.CostCentersName ?? string.Empty;
        }

        public List<Order_Orders> GetPurchases()
        {
            return _db.Order_Orders.ToList();
        }

        public Item_Items GetItems(int itemId)
        {
            return _db.Item_Items.FirstOrDefault(x => x.ItemId == itemId);
        }

        public Item_Items GetItemsByCode(string code)
        {
            return _db.Item_Items.FirstOrDefault(x => x.Item_code == code || x.item_Name == code);
        }

        public decimal GetQuantityForItem(int itemId, int storeId)
        {
            var itemQty = _db.ItemQuantities.FirstOrDefault(x => x.ItemID == itemId && x.StoreID == storeId);
            return itemQty?.CurrentBalance ?? 0m;
        }

        public int InsertOrder(Order_Orders order)
        {
            _db.Order_Orders.Add(order);
            _db.SaveChanges();
            return order.ID;
        }

        public int AddOrderDetail(Order_OrdersDetails detail)
        {
            _db.Order_OrdersDetails.Add(detail);
            _db.SaveChanges();
            return detail.ID;
        }

        public int UpdateItemStock(int itemId, int storeId, decimal quantity)
        {
            var itemQty = _db.ItemQuantities.FirstOrDefault(x => x.ItemID == itemId && x.StoreID == storeId);
            if (itemQty == null)
            {
                itemQty = new ItemQuantity
                {
                    ItemID = itemId,
                    StoreID = storeId,
                    CurrentBalance = quantity,
                    OpeningBalance = 0m,
                    BeginningInventory = 0m,
                    BeginningInventoryPrice = 0m
                };
                _db.ItemQuantities.Add(itemQty);
            }
            else
            {
                itemQty.CurrentBalance = (itemQty.CurrentBalance ?? 0m) + quantity;
            }

            return _db.SaveChanges();
        }

        public int DeleteOrder(int orderId)
        {
            var order = _db.Order_Orders.FirstOrDefault(x => x.ID == orderId);
            if (order == null) return 0;

            _db.Order_Orders.Remove(order);
            return _db.SaveChanges();
        }
    }
}
