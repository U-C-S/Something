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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        branch br = new branch();
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

        private void SkipCode_btn(object sender, RoutedEventArgs e)
        {
            if (SkipCode_txt.Text == "")
            {
                MessageBox.Show(br.texxt);
            }
            else
            {
                MessageBox.Show($"This Feature is yet to be Implemented. \nYou typed {SkipCode_txt.Text}");

            }
        }
    }
}
