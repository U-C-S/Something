using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;

namespace Something
{
    class Common
    {
        public static Color HtoRGB(double h)
        {
            h = Math.Max(0D, Math.Min(360D, h)) / 360D;
            double[] T = { (h + (1D / 3D)), h, (h - (1D / 3D)) };

            for (int i = 0; i < 3; i++)
            {
                if (T[i] < 0D)
                    T[i] += 1D;
                if (T[i] > 1D)
                    T[i] -= 1D;

                if ((T[i] * 6D) < 1D)
                    T[i] = 0.25D + (3D * T[i]);
                else if ((T[i] * 2D) < 1)
                    T[i] = 0.75D;
                else if ((T[i] * 3D) < 2)
                    T[i] = 0.25D + (3D * ((2D / 3D) - T[i]));
                else
                    T[i] = 0.25D;
            }

            return Color.FromRgb(
                    (byte)Math.Max(0, Math.Min(255, Convert.ToInt32(double.Parse($"{T[0] * 255D:0.00}")))),
                    (byte)Math.Max(0, Math.Min(255, Convert.ToInt32(double.Parse($"{T[1] * 255D:0.00}")))),
                    (byte)Math.Max(0, Math.Min(255, Convert.ToInt32(double.Parse($"{T[2] * 255D:0.00}")))));
        }

        public static void ErrorBox(int x = 0)
        {
            string err;
            switch (x)
            {
                case 1: err = "Error! Check the existence of file and addressing of it in the XML file"; break;
                case 2: err = "Invaild Story Structure"; break;
                case 3: err = "Trees/_stories.xml is Non-existent!! You can't start without it."; break;
                default: err = "Unknown Error"; break;
            }
            MessageBox.Show(err);
        }
    }
}
