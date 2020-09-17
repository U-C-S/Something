using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Threading;

namespace Something
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public bool StartClicked = false;
        private void TheStart(object sender, RoutedEventArgs e)
        {
            StartClicked = true;
            OpeningScreen.Visibility = Visibility.Collapsed;
            TheGame.Visibility = Visibility.Visible;
        }

        private void TestClick(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            Brush brush = new SolidColorBrush(Color.FromRgb((byte)rand.Next(1, 255), (byte)rand.Next(1, 255), (byte)rand.Next(1, 255)));
            TheGame.Background = brush;
        }

        private void SkipCode_btn(object sender, RoutedEventArgs e)
        {
            if (SkipCode_txt.Text == "")
            {
                System.Windows.MessageBox.Show("That's empty");
            }
            else
            {
                System.Windows.MessageBox.Show($"This Feature is yet to be Implemented. \nYou typed {SkipCode_txt.Text}");
            }
        }
        private void mouseColorEffect(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //Add a option to disable this effect if (!StartClicked || mouseColEff)
            if (!StartClicked)
            {
                double hue = (Math.Atan2(e.GetPosition(centerPoint).X, e.GetPosition(centerPoint).Y) * 180 / Math.PI) + 180;
                OpeningScreen.Background = new SolidColorBrush(LongFunctions.HSLtoRGB(hue, 0.5, 0.5));
            }
        }
    }


    class LongFunctions
    {
        public static Color HSLtoRGB(double h, double s, double l)
        {
            h = Math.Max(0D, Math.Min(360D, h)) / 360D;
            s = Math.Max(0D, Math.Min(1D, s));
            l = Math.Max(0D, Math.Min(1D, l));

            if (Math.Abs(s) < 0.000000000000001)
            {
                return Color.FromRgb(
                        (byte)Math.Max(0, Math.Min(255, Convert.ToInt32(double.Parse($"{l * 255D:0.00}")))),
                        (byte)Math.Max(0, Math.Min(255, Convert.ToInt32(double.Parse($"{l * 255D:0.00}")))),
                        (byte)Math.Max(0, Math.Min(255, Convert.ToInt32(double.Parse($"{l * 255D:0.00}")))));
            }

            double q = (l < .5D) ? (l * (1D + s)) : ((l + s) - (l * s));
            double p = (2D * l) - q;

            double[] T = { (h + (1D / 3D)) , h , (h - (1D / 3D)) };

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
                    (byte)Math.Max(0, Math.Min(255, Convert.ToInt32(double.Parse($"{T[0] * 255D:0.00}")))),
                    (byte)Math.Max(0, Math.Min(255, Convert.ToInt32(double.Parse($"{T[1] * 255D:0.00}")))),
                    (byte)Math.Max(0, Math.Min(255, Convert.ToInt32(double.Parse($"{T[2] * 255D:0.00}")))));
        }

    }
}
