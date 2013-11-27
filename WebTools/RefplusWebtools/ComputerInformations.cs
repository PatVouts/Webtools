using System;

namespace RefplusWebtools
{
    class ComputerInformations
    {
        public static string GetOsVersion()
        {
           return Identifier("Win32_OperatingSystem", "Caption");
        }


        public static string GetComputerName()
        {
            //format is : DOMAIN\\COMPUTERNAME
            var windowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent();
            if (windowsIdentity != null)
            {
                string computerName = windowsIdentity.Name;
                return computerName;
            }
            return null;
        }

        public static string GetLocalIP()
        {
            //format is : 000.000.000.000
            System.Net.IPAddress[] a = System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName());
            string localIP = a[0].ToString();
            return localIP;

        }

        private static string Identifier(string wmiClass, string wmiProperty, string wmiMustBeTrue)
        {
            string result = "";
            try
            {
                var mc = new System.Management.ManagementClass(wmiClass);
                System.Management.ManagementObjectCollection moc = mc.GetInstances();
                foreach (System.Management.ManagementObject mo in moc)
                {
                    if (mo[wmiMustBeTrue].ToString() == "True")
                    {
                        //Only get the first one    
                        if (result == "")
                        {
                            try
                            {
                                result = mo[wmiProperty].ToString();
                                break;
                            }
                            catch (Exception ex)
                            {
                                Public.PushLog(ex.ToString(), "ComputerInformation Identifier catch 1");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Public.PushLog(ex.ToString(), "ComputerInformation Identifier catch 2");
                result = "UNKNOWN";
            }
            return result;
        }

        private static string Identifier(string wmiClass, string wmiProperty)
        {
            string result = "";
            try
            {
            var mc = new System.Management.ManagementClass(wmiClass);
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            foreach (System.Management.ManagementObject mo in moc)
            {
                //Only get the first one    
                if (result == "")
                {
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch(Exception ex)
                    {
                        Public.PushLog(ex.ToString(), "ComputerInformation Identifier catch1");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Public.PushLog(ex.ToString(), "ComputerInformation Identifier catch2");
            result = "UNKNOWN";
        }

            return result;
        } 

        public static string MacAddress()
        {
            return Identifier("Win32_NetworkAdapterConfiguration", "MACAddress", "IPEnabled");
        }
    }
}
