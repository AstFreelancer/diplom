using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

//namespace InternetAvailable
//{
    class InternetChecker
    {
        [DllImport("WININET", CharSet = CharSet.Auto)]
        static extern bool InternetGetConnectedState(
            ref InternetConnectionState lpdwFlags,
            int dwReserved);

        [Flags]
        enum InternetConnectionState : int
        {
            INTERNET_CONNECTION_MODEM = 0x1,
            INTERNET_CONNECTION_LAN = 0x2,
            INTERNET_CONNECTION_PROXY = 0x4,
            INTERNET_RAS_INSTALLED = 0x10,
            INTERNET_CONNECTION_OFFLINE = 0x20,
            INTERNET_CONNECTION_CONFIGURED = 0x40
        }

        public static string Check()
        {
            InternetConnectionState flags = 0;

            string status = (InternetGetConnectedState(ref flags, 0) ? "ONLINE" : "OFFLINE");

            if (status != "ONLINE")
                return "Не обнаружено подключения к интернету";
            return "Обнаружено подключение к интернету (" + flags + ")";
        }
//    }
}

