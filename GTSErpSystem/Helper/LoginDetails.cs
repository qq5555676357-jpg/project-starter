using System;

namespace GTSErpSystem.Helper
{
    public static class LoginDetails
    {
        public static int DecimalNum { get; set; } = 2;
        public static string nameServer { get; set; } = @"(localdb)\\MSSQLLocalDB";
        public static string databaseServer { get; set; } = "GTSDB";
        public static string userNameServer { get; set; } = "sa";
        public static string passServer { get; set; } = "password";

        public static int BranchID { get; set; } = 1;
        public static int StoreIDWaiting { get; set; } = 1;
        public static int UserID { get; set; } = 1;
        public static int GroupID { get; set; } = 1;
        public static string macAddress { get; set; } = "00-00-00-00-00-00";

        public static int Acc_CashBox { get; set; } = 1;
        public static int Acc_BankNumCachir { get; set; } = 2;
        public static int Acc_OrderCash { get; set; } = 3;
        public static int Acc_VatNum { get; set; } = 4;
        public static int TobaccoNum { get; set; } = 5;
        public static int Acc_CostItemOrder { get; set; } = 6;
        public static int Acc_StockNum { get; set; } = 7;
        public static int Acc_OrderAjila { get; set; } = 8;
        public static int Acc_DiscountForAll { get; set; } = 9;
    }
}
