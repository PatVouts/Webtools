
namespace RefplusWebtools
{
    class FingerPrint
    {
        public FingerPrint(string username,
         string computerName,
         string version,
         string localIP,
         string wanIP,
         string sessionID,
         string operatingSystem,
         string macAddress)
        {
            Username = username;
            ComputerName = computerName;
            Version = version;
            LocalIP = localIP;
            WanIP = wanIP;
            SessionID = sessionID;
            OperatingSystem = operatingSystem;
            MacAddress = macAddress;
        }

        public string Username { get; private set; }
        public string ComputerName { get; private set; }
        public string Version { get; private set; }
        public string LocalIP { get; private set; }
        public string WanIP { get; private set; }
        public string SessionID { get; private set; }
        public string OperatingSystem { get; private set; }
        public string MacAddress { get; private set; }
    }
}
