using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using GTSErpSystem.Helper;

namespace GTSErpSystem.BLL.Orders;

internal class Class_Orders
{
	private int CachCode = 0;

	private DataTable dtCurrentTable = new DataTable();

	private GTSdbEntities db = new GTSdbEntities();

	private int DecimalNum = LoginDetails.DecimalNum;

	private SqlConnection con = new SqlConnection("Data Source=" + LoginDetails.nameServer + ";Initial Catalog=" + LoginDetails.databaseServer + ";Persist Security Info=True;User ID=" + LoginDetails.userNameServer + ";Password=" + LoginDetails.passServer);

	public List<Account_AccountType> GetAccountType()
	{
		return ((IEnumerable<Account_AccountType>)db.Account_AccountType).ToList();
	}

	public string GetAccountNameById(int id)
	{
		return (from a in (IQueryable<Account_AccountType>)db.Account_AccountType
			where a.ID == id
			select a.Name).FirstOrDefault();
	}

	public string GetCostCenterByID(int id)
	{
		return (from x in (IQueryable<Account_CostCenters>)db.Account_CostCenters
			where x.CostCentersID == (int?)id
			select x.CostCentersName).FirstOrDefault();
	}

	public string GetBonuceByID(int id)
	{
		return (from x in (IQueryable<Contract_Bounce>)db.Contract_Bounce
			where x.ID == (int?)id
			select x.Name).FirstOrDefault();
	}

	public List<User_SellPrice> GetUser_SellPrice()
	{
		return ((IQueryable<User_SellPrice>)db.User_SellPrice).Where((User_SellPrice x) => x.ID <= 3).ToList();
	}

	public List<Select_SearchAccountCostCenter_Result> GetCostCenters()
	{
		return ((IEnumerable<Select_SearchAccountCostCenter_Result>)db.Select_SearchAccountCostCenter(Convert.ToInt32(LoginDetails.BranchID))).ToList();
	}

	public List<Order_Orders> GetPurchases()
	{
		GTSdbEntities gTSdbEntities = new GTSdbEntities();
		return ((IQueryable<Order_Orders>)gTSdbEntities.Order_Orders).Where((Order_Orders x) => x.BranchID == (int?)LoginDetails.BranchID).ToList();
	}

	public List<Order_Orders> GetPurchases(int Code)
	{
		GTSdbEntities gTSdbEntities = new GTSdbEntities();
		return ((IQueryable<Order_Orders>)gTSdbEntities.Order_Orders).Where((Order_Orders x) => x.PurBranchID == (int?)Code && x.BranchID == (int?)LoginDetails.BranchID).ToList();
	}

	public Item_Items GetItems(int itemid)
	{
		GTSdbEntities gTSdbEntities = new GTSdbEntities();
		try
		{
			return ((IQueryable<Item_Items>)gTSdbEntities.Item_Items).FirstOrDefault((Item_Items x) => x.ItemId == itemid);
		}
		finally
		{
			((IDisposable)gTSdbEntities)?.Dispose();
		}
	}

	public Printer GetPrinter(int itemid)
	{
		int PrintID = 0;
		int CatID = Convert.ToInt32(((IQueryable<Item_Items>)db.Item_Items).Where((Item_Items x) => x.ItemId == itemid).FirstOrDefault().Category_ID);
		bool flag = true;
		PrintID = Convert.ToInt32(((IQueryable<Item_Groups>)db.Item_Groups).Where((Item_Groups x) => x.ID == CatID).FirstOrDefault().PrinterID);
		return ((IQueryable<Printer>)db.Printers).Where((Printer x) => x.ID == PrintID).FirstOrDefault();
	}

	public Item_Items GetItemsMizan(string BarcodeMizan)
	{
		GTSdbEntities gTSdbEntities = new GTSdbEntities();
		return ((IQueryable<Item_Items>)gTSdbEntities.Item_Items).Where((Item_Items x) => x.SmallBarCode1 == BarcodeMizan || x.SmallBarCode2 == BarcodeMizan || x.SmallBarCode3 == BarcodeMizan || x.MediumBarCode1 == BarcodeMizan || x.MediumBarCode2 == BarcodeMizan || x.MediumBarCode3 == BarcodeMizan || x.BigBarCode1 == BarcodeMizan || x.BigBarCode2 == BarcodeMizan || x.BigBarCode3 == BarcodeMizan).FirstOrDefault();
	}

	public ItemMatchResult GetItemsOnly(string Code)
	{
		GTSdbEntities gTSdbEntities = new GTSdbEntities();
		try
		{
			Item_Items item_Items = ((IQueryable<Item_Items>)gTSdbEntities.Item_Items).FirstOrDefault((Item_Items x) => x.Item_code == Code);
			if (item_Items != null)
			{
				return new ItemMatchResult
				{
					Item = item_Items,
					MatchedField = "Item_code"
				};
			}
			item_Items = ((IQueryable<Item_Items>)gTSdbEntities.Item_Items).FirstOrDefault((Item_Items x) => x.SmallBarCode1 == Code);
			if (item_Items != null)
			{
				return new ItemMatchResult
				{
					Item = item_Items,
					MatchedField = "SmallBarCode1"
				};
			}
			item_Items = ((IQueryable<Item_Items>)gTSdbEntities.Item_Items).FirstOrDefault((Item_Items x) => x.SmallBarCode2 == Code);
			if (item_Items != null)
			{
				return new ItemMatchResult
				{
					Item = item_Items,
					MatchedField = "SmallBarCode2"
				};
			}
			item_Items = ((IQueryable<Item_Items>)gTSdbEntities.Item_Items).FirstOrDefault((Item_Items x) => x.SmallBarCode3 == Code);
			if (item_Items != null)
			{
				return new ItemMatchResult
				{
					Item = item_Items,
					MatchedField = "SmallBarCode3"
				};
			}
			item_Items = ((IQueryable<Item_Items>)gTSdbEntities.Item_Items).FirstOrDefault((Item_Items x) => x.MediumBarCode1 == Code);
			if (item_Items != null)
			{
				return new ItemMatchResult
				{
					Item = item_Items,
					MatchedField = "MediumBarCode1"
				};
			}
			item_Items = ((IQueryable<Item_Items>)gTSdbEntities.Item_Items).FirstOrDefault((Item_Items x) => x.MediumBarCode2 == Code);
			if (item_Items != null)
			{
				return new ItemMatchResult
				{
					Item = item_Items,
					MatchedField = "MediumBarCode2"
				};
			}
			item_Items = ((IQueryable<Item_Items>)gTSdbEntities.Item_Items).FirstOrDefault((Item_Items x) => x.MediumBarCode3 == Code);
			if (item_Items != null)
			{
				return new ItemMatchResult
				{
					Item = item_Items,
					MatchedField = "MediumBarCode3"
				};
			}
			item_Items = ((IQueryable<Item_Items>)gTSdbEntities.Item_Items).FirstOrDefault((Item_Items x) => x.BigBarCode1 == Code);
			if (item_Items != null)
			{
				return new ItemMatchResult
				{
					Item = item_Items,
					MatchedField = "BigBarCode1"
				};
			}
			item_Items = ((IQueryable<Item_Items>)gTSdbEntities.Item_Items).FirstOrDefault((Item_Items x) => x.BigBarCode2 == Code);
			if (item_Items != null)
			{
				return new ItemMatchResult
				{
					Item = item_Items,
					MatchedField = "BigBarCode2"
				};
			}
			item_Items = ((IQueryable<Item_Items>)gTSdbEntities.Item_Items).FirstOrDefault((Item_Items x) => x.BigBarCode3 == Code);
			if (item_Items != null)
			{
				return new ItemMatchResult
				{
					Item = item_Items,
					MatchedField = "BigBarCode3"
				};
			}
			return null;
		}
		finally
		{
			((IDisposable)gTSdbEntities)?.Dispose();
		}
	}

	public int InsertItems_Complant(DataTable Items, string ItemCode)
	{
		int result = 0;
		foreach (DataRow row in Items.Rows)
		{
			if (row["كود_الصنف"].ToString() != "")
			{
				Item_ItemComponent item_ItemComponent = new Item_ItemComponent();
				string Itemcod = row["كود_الصنف"].ToString();
				string value = Convert.ToString(((IQueryable<Item_Items>)db.Item_Items).Where((Item_Items x) => x.Item_code == ItemCode).FirstOrDefault().ItemId);
				string value2 = Convert.ToString(((IQueryable<Item_Items>)db.Item_Items).Where((Item_Items x) => x.Item_code == Itemcod).FirstOrDefault().ItemId);
				int ItemRowChek = Convert.ToInt32(value2);
				Item_Items item_Items = ((IQueryable<Item_Items>)db.Item_Items).Where((Item_Items z) => z.ItemId == ItemRowChek).FirstOrDefault();
				if (item_Items != null)
				{
					item_ItemComponent.ItemID_Master = Convert.ToInt32(value);
					item_ItemComponent.ItemID_Complant = Convert.ToInt32(item_Items.ItemId);
					item_ItemComponent.Amount = Convert.ToDecimal(row["الكمية"].ToString());
					string nmae = row["الوحدة"].ToString();
					item_ItemComponent.ItemUnitID = GetUnitIdByName(nmae);
					item_ItemComponent.SmallUnitPrice = Convert.ToDecimal(row["م.التكلفة"].ToString());
					item_ItemComponent.TotalPrice = Math.Round(Convert.ToDecimal(row["الاجمالى"].ToString()), DecimalNum);
					item_ItemComponent.ItemUnitType = row["أسم_الوحدة"].ToString();
					item_ItemComponent.StoreID = Convert.ToInt32(row["رقم المخزن"]);
					db.Item_ItemComponent.Add(item_ItemComponent);
					result = ((DbContext)db).SaveChanges();
				}
			}
		}
		return result;
	}

	public int ItemQuantityIn(int ItemID, decimal Quantity, string unitType, int StoreID, int itemType)
	{
		GTSdbEntities gTSdbEntities = new GTSdbEntities();
		int result = 0;
		if (ItemID > 0)
		{
			if (itemType == 1)
			{
				ItemQuantity itemQuantity = ((IQueryable<ItemQuantity>)gTSdbEntities.ItemQuantities).Where((ItemQuantity x) => x.ItemID == (int?)ItemID && x.StoreID == (int?)StoreID).FirstOrDefault();
				Item_Items item_Items = ((IQueryable<Item_Items>)gTSdbEntities.Item_Items).Where((Item_Items x) => x.ItemId == ItemID).FirstOrDefault();
				if (itemQuantity != null)
				{
					ItemQuantity itemQuantity2 = ((IQueryable<ItemQuantity>)gTSdbEntities.ItemQuantities).Where((ItemQuantity x) => x.ItemID == (int?)ItemID && x.StoreID == (int?)StoreID).FirstOrDefault();
					if (itemQuantity2 != null)
					{
						if (unitType == "الصغرى")
						{
							itemQuantity2.CurrentBalance -= (decimal?)Quantity;
							result = ((DbContext)gTSdbEntities).SaveChanges();
						}
						if (unitType == "المتوسطة")
						{
							decimal? currentBalance = itemQuantity2.CurrentBalance;
							decimal value = Quantity;
							decimal? convertMediumUnit = item_Items.ConvertMediumUnit;
							itemQuantity2.CurrentBalance = currentBalance - (decimal?)value * convertMediumUnit;
							result = ((DbContext)gTSdbEntities).SaveChanges();
						}
						if (unitType == "الكبرى")
						{
							decimal? currentBalance2 = itemQuantity2.CurrentBalance;
							decimal value = Quantity;
							decimal? convertMediumUnit2 = item_Items.ConvertMediumUnit;
							itemQuantity2.CurrentBalance = currentBalance2 - (decimal?)value * convertMediumUnit2 * item_Items.ConvertBigUnit;
							result = ((DbContext)gTSdbEntities).SaveChanges();
						}
					}
					return result;
				}
				ItemQuantity itemQuantity3 = new ItemQuantity();
				int itemQuantityID = Convert.ToInt32(((IQueryable<ItemQuantity>)gTSdbEntities.ItemQuantities).Select((ItemQuantity p) => p.ItemQuantityID).DefaultIfEmpty(0).Max()) + 1;
				itemQuantity3.ItemQuantityID = itemQuantityID;
				itemQuantity3.ItemID = ItemID;
				if (unitType == "الصغرى")
				{
					itemQuantity3.CurrentBalance = -Quantity;
				}
				if (unitType == "المتوسطة")
				{
					decimal value = -Quantity;
					decimal? currentBalance = item_Items.ConvertMediumUnit;
					itemQuantity3.CurrentBalance = (decimal?)value * currentBalance;
				}
				if (unitType == "الكبرى")
				{
					decimal value = -Quantity;
					decimal? convertMediumUnit3 = item_Items.ConvertMediumUnit;
					itemQuantity3.CurrentBalance = (decimal?)value * convertMediumUnit3 * item_Items.ConvertBigUnit;
				}
				itemQuantity3.BeginningInventory = 0m;
				itemQuantity3.BeginningInventoryPrice = 0m;
				itemQuantity3.OpeningBalance = 0m;
				itemQuantity3.StoreID = StoreID;
				gTSdbEntities.ItemQuantities.Add(itemQuantity3);
				result = ((DbContext)gTSdbEntities).SaveChanges();
			}
			if (itemType == 3)
			{
				List<Item_ItemComponent> list = ((IQueryable<Item_ItemComponent>)gTSdbEntities.Item_ItemComponent).Where((Item_ItemComponent x) => x.ItemID_Master == (int?)ItemID).ToList();
				Item_Items item_Items2 = ((IQueryable<Item_Items>)gTSdbEntities.Item_Items).Where((Item_Items x) => x.ItemId == ItemID).FirstOrDefault();
				foreach (Item_ItemComponent item in list)
				{
					Item_Items item_Items3 = ((IQueryable<Item_Items>)gTSdbEntities.Item_Items).Where((Item_Items x) => (int?)x.ItemId == item.ItemID_Complant).FirstOrDefault();
					ItemQuantity itemQuantity4 = ((IQueryable<ItemQuantity>)gTSdbEntities.ItemQuantities).Where((ItemQuantity x) => x.ItemID == item.ItemID_Complant && x.StoreID == (int?)StoreID).FirstOrDefault();
					if (itemQuantity4 != null)
					{
						ItemQuantity itemQuantity5 = ((IQueryable<ItemQuantity>)gTSdbEntities.ItemQuantities).Where((ItemQuantity x) => x.ItemID == item.ItemID_Complant && x.StoreID == (int?)StoreID).FirstOrDefault();
						if (itemQuantity5 == null)
						{
							continue;
						}
						if (unitType == "الصغرى")
						{
							if (item.ItemUnitType == "الصغرى")
							{
								itemQuantity5.CurrentBalance -= item.Amount * (decimal?)Quantity;
								result = ((DbContext)gTSdbEntities).SaveChanges();
							}
							if (item.ItemUnitType == "المتوسطة")
							{
								itemQuantity5.CurrentBalance -= item.Amount * (decimal?)Quantity * item_Items3.ConvertMediumUnit;
								result = ((DbContext)gTSdbEntities).SaveChanges();
							}
							if (item.ItemUnitType == "الكبرى")
							{
								itemQuantity5.CurrentBalance -= item.Amount * (decimal?)Quantity * item_Items3.ConvertMediumUnit * item_Items3.ConvertBigUnit;
								result = ((DbContext)gTSdbEntities).SaveChanges();
							}
						}
						if (unitType == "المتوسطة")
						{
							if (item.ItemUnitType == "الصغرى")
							{
								itemQuantity5.CurrentBalance -= item.Amount * (decimal?)Quantity * item_Items2.ConvertMediumUnit;
								result = ((DbContext)gTSdbEntities).SaveChanges();
							}
							if (item.ItemUnitType == "المتوسطة")
							{
								itemQuantity5.CurrentBalance -= item.Amount * (decimal?)Quantity * item_Items3.ConvertMediumUnit * item_Items2.ConvertMediumUnit;
								result = ((DbContext)gTSdbEntities).SaveChanges();
							}
							if (item.ItemUnitType == "الكبرى")
							{
								itemQuantity5.CurrentBalance -= item.Amount * (decimal?)Quantity * item_Items3.ConvertMediumUnit * item_Items3.ConvertBigUnit * item_Items2.ConvertMediumUnit;
								result = ((DbContext)gTSdbEntities).SaveChanges();
							}
						}

(Truncated for brevity in tool input; full file content uploaded)
