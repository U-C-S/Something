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
    /// Completely made by github.com/U-C-S
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        bool StartClicked = false;
        int ComboxVal;

        private void ComboBoxSelect(object sender, SelectionChangedEventArgs e) => ComboxVal = MenuEffComboBox.SelectedIndex;

        private void mouseColorEffect(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!StartClicked && !(ComboxVal == 3))
            {
                double hue = (Math.Atan2(e.GetPosition(centerPoint).X, e.GetPosition(centerPoint).Y) * 180 / Math.PI) + 180;
                Brush x = new SolidColorBrush(LongFunctions.HSLtoRGB(hue, 0.5, 0.5));
                if (ComboxVal == 0)
                {
                    //default
                    Btn_Abt.Margin = new Thickness(0, 40, 60, 0);
                    OpeningScreen.Background = Btn_Main.Foreground = x;
                    ellipse1.Visibility = ellipse2.Visibility = ellipse3.Visibility = rect1.Visibility = Visibility.Visible;
                    ellipse1.Fill = ellipse2.Fill = ellipse3.Fill = rect1.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                }
                else if (ComboxVal == 1)
                {
                    //inverted
                    Btn_Abt.Margin = new Thickness(0, 40, 60, 0);
                    ellipse1.Visibility = ellipse2.Visibility = ellipse3.Visibility = rect1.Visibility = Visibility.Visible;
                    ellipse1.Fill = ellipse2.Fill = ellipse3.Fill = rect1.Fill = Btn_Main.Foreground = x;
                    OpeningScreen.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                }
                else if(ComboxVal == 2)
                {
                    //plain
                    Btn_Abt.Margin = new Thickness(0, 5, 85, 0);
                    OpeningScreen.Background = Btn_Main.Foreground = x;
                    ellipse1.Visibility = ellipse2.Visibility = ellipse3.Visibility = rect1.Visibility = Visibility.Collapsed;
                }

            }
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
        private void OpenAboutWindow(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }


        //The game code starts here:

        Branch branchdata = new Branch();
        Action x1 { get; set; }
        Action x2 { get; set; }
        private void TheStart(object sender, RoutedEventArgs e)
        {
            StartClicked = true;
            OpeningScreen.Visibility = Visibility.Collapsed;
            TheGame.Visibility = Visibility.Visible;
            branchdata.intialContext();
            ExecuteTheChoice();
        }

        private void branchingToOne(object sender, RoutedEventArgs e)
        {
            x1();
            ExecuteTheChoice();
        }

        private void branchingToTwo(object sender, RoutedEventArgs e)
        {
            x2();
            ExecuteTheChoice();
        }
        private void ExecuteTheChoice()
        {
            Random rand = new Random();
            Brush brush = new SolidColorBrush(Color.FromRgb((byte)rand.Next(1, 255), (byte)rand.Next(1, 255), (byte)rand.Next(1, 255)));
            TheGame.Background = brush;

            BrContext.Text = branchdata.consequences;
            path1.Content = branchdata.choiceOne;
            path2.Content = branchdata.choiceTwo;
            x1 = branchdata.oneFn;
            x2 = branchdata.twoFn;
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
