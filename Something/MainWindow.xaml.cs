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
using System.IO;
using System.Xml;
using Content;
using System.Xml.Linq;

namespace Content
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
            _NavigationFrame.Navigate(new Something.MainPage());
        }
    }




    /*
     
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

            BrContext.Text = branchdata.Consequences;
            path1.Content = branchdata.ChoiceBtn1;
            path2.Content = branchdata.ChoiceBtn2;
            x1 = branchdata.ChoseOne;
            x2 = branchdata.ChoseTwo;
        }
     
     
     
     */
}
