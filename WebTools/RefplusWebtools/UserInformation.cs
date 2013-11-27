
namespace RefplusWebtools
{
    class UserInformation
    {
        private static string _strEmail = "";
        private static string _strName = "";
        private static string _strCompanyName = "";
        private static string _strUserGroups = "";

        //rights

        static UserInformation()
        {
            MaxMultiplier = 1m;
            ParentGroupID = -1;
            CurrentSite = "";
            Site = "";
            UserKey = "";
            UserName = "";
        }


        public static string UserName { get; set; }

        public static string UserKey { get; set; }

        public static string Site { get; set; }

        public static string CurrentSite { get; set; }

        public static int UserID { get; set; }

        public static int ContactID { get; set; }

        public static int GroupID { get; set; }

        public static int CreatedByGroupID { get; set; }

        public static int ParentGroupID { get; set; }

        public static int Userlevel { get; set; }

        public static string Email
        {
            get { return _strEmail; }
            set { _strEmail = value; }
        }

        public static string Name
        {
            get { return _strName; }
            set { _strName = value; }
        }

        public static string CompanyName
        {
            get { return _strCompanyName; }
            set { _strCompanyName = value; }
        }

        public static string UserGroups
        {
            get { return _strUserGroups; }
            set { _strUserGroups = value; }
        }

        public static decimal MinMultiplier { get; set; }

        public static decimal MaxMultiplier { get; set; }

        public static bool AccessQuote { get; set; }
        public static bool AccessQuoteCoil { get; set; }
        public static bool AccessQuoteManualCoil { get; set; }
        public static bool AccessQuoteCondenser { get; set; }
        public static bool AccessQuoteCondensingUnit { get; set; }
        public static bool AccessQuoteEvaporator { get; set; }
        public static bool AccessQuoteWaterEvaporator { get; set; }
        public static bool AccessQuoteGravityCoil { get; set; }
        public static bool AccessQuoteFluidCooler { get; set; }
        public static bool AccessQuoteHeatPipe { get; set; }
        public static bool AccessQuoteCustomUnit { get; set; }
        public static bool AccessQuoteAdditionnalItems { get; set; }
        public static bool AccessQuoteOEMCoil { get; set; }
        public static bool AccessQuickCoil { get; set; }
        public static bool AccessQuickCondenser { get; set; }
        public static bool AccessQuickCondensingUnit { get; set; }
        public static bool AccessQuickEvaporator { get; set; }
        public static bool AccessQuickWaterEvaporator { get; set; }
        public static bool AccessQuickGravityCoil { get; set; }
        public static bool AccessQuickFluidCooler { get; set; }
        public static bool AccessQuickHeatPipe { get; set; }
        public static bool AccessQuickCustomUnit { get; set; }
        public static bool AccessUserManager { get; set; }
        public static bool AccessAdvancedSearch { get; set; }
        public static bool AccessBalancingModule { get; set; }
        public static bool AccessDataManager { get; set; }
        public static bool AccessReport { get; set; }
        public static bool AccessReportEngineeringReport { get; set; }
        public static bool AccessReportAdvancedSalesReport { get; set; }
        public static bool AccessQuoteOEMCoilProfitMargin { get; set; }

        public static bool RequiredPermissionLevel(int permissionLevel)
        {
            return Userlevel >= permissionLevel;
        }

        public static bool ExactRequiredPermission(int permissionLevel)
        {
            return Userlevel == permissionLevel;
        }

        public static bool ExactRequiredPermission(int[] permissionLevel)
        {
            for (int i = 0; i < permissionLevel.Length; i++)
            {
                if (ExactRequiredPermission(permissionLevel[i]))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
