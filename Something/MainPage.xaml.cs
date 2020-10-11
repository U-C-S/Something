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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Something
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
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
                Brush x = new SolidColorBrush(LongFunctions.HtoRGB(hue));
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
                else if (ComboxVal == 2)
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
            Content.About about = new Content.About();
            about.ShowDialog();
        }


        //The game code starts here:

        private void TheStart(object sender, RoutedEventArgs e)
        {
            StartClicked = true;
            OpeningScreen.Visibility = Visibility.Collapsed;
            TheGame.Visibility = Visibility.Visible;

            BrContext.Text = XDocument.Load(@"Trees\Test.xml").Root.Element("meta").Element("name").Value.ToString();

        }
    }


    class LongFunctions
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

    }
}

