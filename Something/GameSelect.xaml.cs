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

namespace Something
{
    /// <summary>
    /// Interaction logic for GameSelect.xaml
    /// </summary>
    public partial class GameSelect : Page
    {
        int ComboxVal;
        public GameSelect(int a)
        {
            InitializeComponent();
            ComboxVal = a;
        }

        private void mouseColorEffect(object sender, MouseEventArgs e)
        {
            if (ComboxVal != 3)
            {
                double hue = (Math.Atan2(e.GetPosition(centerPoint).X, e.GetPosition(centerPoint).Y) * 180 / Math.PI) + 180;
                Brush x = new SolidColorBrush(Common.HtoRGB(hue));
                if (ComboxVal == 0)
                {
                    //default
                    //Btn_Abt.Margin = new Thickness(0, 40, 60, 0);
                    //OpeningScreen.Background = Btn_Main.Foreground = x;
                    //ellipse1.Visibility = ellipse2.Visibility = ellipse3.Visibility = rect1.Visibility = Visibility.Visible;
                    //ellipse1.Fill = ellipse2.Fill = ellipse3.Fill = rect1.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                }
                else if (ComboxVal == 1)
                {
                    //inverted
                    //Btn_Abt.Margin = new Thickness(0, 40, 60, 0);
                    //ellipse1.Visibility = ellipse2.Visibility = ellipse3.Visibility = rect1.Visibility = Visibility.Visible;
                    //ellipse1.Fill = ellipse2.Fill = ellipse3.Fill = rect1.Fill = Btn_Main.Foreground = x;
                    //OpeningScreen.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                }
                else if (ComboxVal == 2)
                {
                    //plain
                    //Btn_Abt.Margin = new Thickness(0, 5, 85, 0);
                    //OpeningScreen.Background = Btn_Main.Foreground = x;
                    //ellipse1.Visibility = ellipse2.Visibility = ellipse3.Visibility = rect1.Visibility = Visibility.Collapsed;
                }

            }
        }
    }
}
