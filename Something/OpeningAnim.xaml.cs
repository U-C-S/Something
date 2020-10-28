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
    /// Interaction logic for OpeningAnim.xaml
    /// </summary>
    public partial class OpeningAnim : Page
    {
        public OpeningAnim() => InitializeComponent();
        private void Page_MouseUp(object sender, MouseButtonEventArgs e) => Skip();
        private void DoubleAnimationUsingKeyFrames_Completed(object sender, EventArgs e) => Skip();
        private void Skip() => NavigationService.Navigate(new MainPage());

    }
}
