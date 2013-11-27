
namespace RefplusWebtools
{

    class FingerPrintHandler
    {
        public enum FingerPrintType { Login, Logout, Error, Update, Log, Kick };

        public static int GetFingerPrintType(FingerPrintType fpt)
        {
            //1	Login
            //2	Logout
            //3	Error
            //4	Update
            //5	Log
            //6	Kick

            int intFPT = 0;

            switch (fpt)
            {
                case FingerPrintType.Login:
                    intFPT = 1;
                    break;
                case FingerPrintType.Logout:
                    intFPT = 2;
                    break;
                case FingerPrintType.Error:
                    intFPT = 3;
                    break;
                case FingerPrintType.Update:
                    intFPT = 4;
                    break;
                case FingerPrintType.Log:
                    intFPT = 5;
                    break;
                case FingerPrintType.Kick:
                    intFPT = 6;
                    break;
            }

            return intFPT;
        }

        private static FingerPrint _defaultFingerPrint;

        private static void SetDefaultFingerPrint()
        {
            _defaultFingerPrint = new FingerPrint(
                UserInformation.UserName,
                ComputerInformations.GetComputerName(),
                Public.ApplicationVersion,
                ComputerInformations.GetLocalIP(),
                Query.GetWanIP(),
                Query.GetSessionID(),
                ComputerInformations.GetOsVersion(),
                ComputerInformations.MacAddress());
        }

        public static void LoginProcess()
        {
            if (UserInformation.UserName != "admin" && UserInformation.UserName != "lcoufal")
            {
                //create the fingerprint
                SetDefaultFingerPrint();

                //clear any left over session there could be
                ClearSessions();

                //add to the live connection table
                Query.Execute("INSERT INTO FingerPrint(Username,SessionID) VALUES ('" + _defaultFingerPrint.Username + "','" + _defaultFingerPrint.SessionID + "')");

                //add the history log for it
                AddHistory(FingerPrintType.Login, "");
            }
        }

        private static void ClearSessions()
        {
            //delete from the live connection table all connection related to this user
            //that would make the recurent check noticed if the session got cleared because
            //of multi usage.
            Query.Execute("DELETE FROM FingerPrint WHERE Username = '" + _defaultFingerPrint.Username + "'");
        }

        public static void LogoutProcess()
        {
            if (UserInformation.UserName != "admin" && UserInformation.UserName != "lcoufal")
            {
                //clear any left over session there could be
                ClearSessions();

                //add to history
                AddHistory(FingerPrintType.Logout, "");
            }
        }

        public static bool RecurrentCheckForActivity()
        {
            bool result = true;

            if (UserInformation.UserName != "admin" && UserInformation.UserName != "lcoufal")
            {
                if (!IsFingerPrintAlive())
                {
                    //2011-02-09 : remove the kick user
                    //KickUser();

                    //2011-01-12 : remove the user disable
                    //DisableUserAccount();

                    result = false;
                }
            }

            return result;
        }

        private static bool IsFingerPrintAlive()
        {
            return (Query.Select("SELECT * FROM FingerPrint WHERE Username = '" + _defaultFingerPrint.Username + "' AND SessionID ='" + _defaultFingerPrint.SessionID + "'").Rows.Count == 1);
        }

        private static void AddHistory(FingerPrintType fpt, string description)
        {
            Query.Execute(@"INSERT INTO FingerPrintHistory(
            [Username]
           ,[Computername]
           ,[Version]
           ,[LocalIP]
           ,[WanIP]
           ,[OperatingSystem]
           ,[MacAddress]
           ,[SessionID]
           ,[Type]
           ,[Description])
     VALUES
           ('" + _defaultFingerPrint.Username + @"'
           ,'" + _defaultFingerPrint.ComputerName + @"'
           ,'" + _defaultFingerPrint.Version + @"'
           ,'" + _defaultFingerPrint.LocalIP + @"'
           ,'" + _defaultFingerPrint.WanIP + @"'
           ,'" + _defaultFingerPrint.OperatingSystem + @"'
           ,'" + _defaultFingerPrint.MacAddress + @"'
           ,'" + _defaultFingerPrint.SessionID + @"'
           ," + GetFingerPrintType(fpt) + @"
           ,'" + description + @"')");
        }
    }
}
