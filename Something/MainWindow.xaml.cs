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
using System.Windows.Markup;

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
        private void TheStart(object sender, RoutedEventArgs e)
        {
            OpeningScreen.Visibility = Visibility.Collapsed;
            TheGame.Visibility = Visibility.Visible;
        }

        private void TestClick(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            Brush brush = new SolidColorBrush(Color.FromRgb((byte)rand.Next(1, 255), (byte)rand.Next(1, 255), (byte)rand.Next(1, 255)));
            TheGame.Background = brush;
        }

        Branch br = new Branch();
        private void SkipCode_btn(object sender, RoutedEventArgs e)
        {
            if (SkipCode_txt.Text == "")
            {
                System.Windows.MessageBox.Show(br.texxt);
            }
            else
            {
                System.Windows.MessageBox.Show($"This Feature is yet to be Implemented. \nYou typed {SkipCode_txt.Text}");
            }
        }
        
        private void Form1_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            double xp = e.GetPosition(centerPoint).X;
            double yp = e.GetPosition(centerPoint).Y;
            mouse.Text = $"({xp}, {yp})";
            double hue = (Math.Atan2(xp,yp) * 180 / Math.PI) + 180;
            OpeningScreen.Background = new SolidColorBrush(Branch.SimpleColorTransforms.HsLtoRgb(hue,0.7,0.5));
        }
    }
}
