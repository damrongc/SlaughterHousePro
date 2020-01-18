using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlaughterHouseClient
{
    public static class WeightHelper
    {
        public static string DisplayWeightWithManualCapture(bool lockWeight, string DataInvoke, int scaleDivision)
        {
            string weightText = "";
            if (lockWeight == false)
            {
                double num = 0.0;
                if (DataInvoke.Length == 40)
                {

                    short stateOfScale = DataInvoke.Substring(7, 1).ToInt16();
                    short stableWt = DataInvoke.Substring(5, 1).ToInt16();

                    if (stableWt == 2)
                    {
                        weightText = "--.---";
                    }
                    else
                    {
                        if (stateOfScale == 0)
                        {
                            num = DataInvoke.Substring(16, 6).ToDouble() / scaleDivision;
                        }
                        else if (stateOfScale == 1)
                        {
                            num = -1.0 * DataInvoke.Substring(16, 6).ToDouble() / scaleDivision;
                        }
                        weightText = (num).ToFormat2Double();

                    }
                    return weightText;

                }

            }
            return weightText;
        }
    }
}
