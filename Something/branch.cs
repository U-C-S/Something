using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using SystemMath = System.Math;

namespace Something
{
    class Branch
    {
        public string texxt = "Blah";


        public static class SimpleColorTransforms
        {
            private static double tolerance => 0.000000000000001;

            public static Color HsLtoRgb(double h, double s, double l)
            {
                h = SystemMath.Max(0D, SystemMath.Min(360D, h));
                s = SystemMath.Max(0D, SystemMath.Min(1D, s));
                l = SystemMath.Max(0D, SystemMath.Min(1D, l));

                // achromatic argb (gray scale)
                if (SystemMath.Abs(s) < SimpleColorTransforms.tolerance)
                {
                    return Color.FromRgb(
                            (byte)SystemMath.Max(0, SystemMath.Min(255, Convert.ToInt32(double.Parse($"{l * 255D:0.00}")))),
                            (byte)SystemMath.Max(0, SystemMath.Min(255, Convert.ToInt32(double.Parse($"{l * 255D:0.00}")))),
                            (byte)SystemMath.Max(0, SystemMath.Min(255, Convert.ToInt32(double.Parse($"{l * 255D:0.00}")))));
                }

                double q = l < .5D
                        ? l * (1D + s)
                        : (l + s) - (l * s);
                double p = (2D * l) - q;

                double hk = h / 360D;
                double[] T = new double[3];
                T[0] = hk + (1D / 3D); // Tr
                T[1] = hk; // Tb
                T[2] = hk - (1D / 3D); // Tg

                for (int i = 0; i < 3; i++)
                {
                    if (T[i] < 0D)
                        T[i] += 1D;
                    if (T[i] > 1D)
                        T[i] -= 1D;

                    if ((T[i] * 6D) < 1D)
                        T[i] = p + ((q - p) * 6D * T[i]);
                    else if ((T[i] * 2D) < 1)
                        T[i] = q;
                    else if ((T[i] * 3D) < 2)
                        T[i] = p + ((q - p) * ((2D / 3D) - T[i]) * 6D);
                    else
                        T[i] = p;
                }

                return Color.FromRgb(
                        (byte)SystemMath.Max(0, SystemMath.Min(255, Convert.ToInt32(double.Parse($"{T[0] * 255D:0.00}")))),
                        (byte)SystemMath.Max(0, SystemMath.Min(255, Convert.ToInt32(double.Parse($"{T[1] * 255D:0.00}")))),
                        (byte)SystemMath.Max(0, SystemMath.Min(255, Convert.ToInt32(double.Parse($"{T[2] * 255D:0.00}")))));
            }
        }
    }
}
