using System;

namespace SlaughterHouseClient
{
    public static class ScaleHelper
    {

        public static string GetWeightIWX(string DataInvoke)
        {
            double num = 0.0;
            if (DataInvoke.Length == 40)
            {

                int scaleDecimal = DataInvoke.Substring(22, 2).ToInt32();
                int scaleDivision = (int)Math.Round(Math.Pow(10.0, unchecked(scaleDecimal)));

                string strFormatWt = scaleDecimal == 0 ? "#0" : "#0." + "0".PadRight(scaleDecimal, '0');
                short stateOfScale = DataInvoke.Substring(7, 1).ToInt16();
                short stableWt = DataInvoke.Substring(6, 1).ToInt16();

                if (stateOfScale == 0)
                {
                    num = DataInvoke.Substring(16, 6).ToDouble() / scaleDivision;
                }
                else
                {
                    num = -1.0 * DataInvoke.Substring(16, 6).ToDouble() / scaleDivision;
                }
                return num.ToString(strFormatWt);

            }

            return num.ToString();
        }
    }
}
