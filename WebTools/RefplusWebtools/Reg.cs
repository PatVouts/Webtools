using Microsoft.Win32;

namespace RefplusWebtools
{
    class Reg
    {
        //enumeration of the possible key
        public enum Key { Username = 0, Location = 1, Site = 2, Language = 3, CustomLogo = 4, CustomAddress = 5 };

        //set an information
        public static void Set(Key myKey, string value)
        {
            RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\RefplusWebtools");
            if (reg != null) reg.SetValue(myKey.ToString(), value);
        }

        //get an information
        public static string Get(Key myKey)
        {
            RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"Software\RefplusWebtools");
            string value = "";
            if (reg != null)
            {
                string[] keyName = reg.GetValueNames();
                for (int x = 0; x < keyName.Length; x++)
                {
                    if (keyName[x] == myKey.ToString())
                    {
                        value = (string)reg.GetValue(keyName[x]);
                    }
                }
            }
            return value;
        }

        
    }
}
