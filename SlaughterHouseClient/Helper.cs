using System;
using System.Net;
using System.Net.Sockets;

namespace SlaughterHouseClient
{
    public static class Helper
    {

        public static string GetWeightIWX(string DataInvoke)
        {
            double num = 0.0;
            if (DataInvoke.Length == 38)
            {

                int scaleDecimal = DataInvoke.Substring(20, 2).ToInt32();
                int scaleDivision = (int)Math.Round(Math.Pow(10.0, unchecked(scaleDecimal)));

                string strFormatWt = scaleDecimal == 0 ? "#0" : "#0." + "0".PadRight(scaleDecimal, '0');
                short stateOfScale = DataInvoke.Substring(2, 1).ToInt16();
                //short stableWt = DataInvoke.Substring(2, 1).ToInt16();

                if (stateOfScale == 0)
                {
                    num = DataInvoke.Substring(14, 6).ToDouble() / scaleDivision;
                }
                else
                {
                    num = -1.0 * DataInvoke.Substring(14, 6).ToDouble() / scaleDivision;
                }
                return num.ToString(strFormatWt);

            }

            return num.ToString();
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }


}
