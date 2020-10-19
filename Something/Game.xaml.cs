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
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        XDocument currentXMLfile;
        public Game(XDocument currentXMLfile)
        {
            InitializeComponent();
            this.currentXMLfile = currentXMLfile;
            Renderer("START");
        }

        void Renderer(string x)
        {
            XElement currentBranch = currentXMLfile.Root.Element("story").Element(x);
            BrContext.Text = currentBranch.Element("conseq").Value.ToString();
            path1.Content = currentBranch.Element("choice1").Element("btn").Value.ToString();
            path2.Content = currentBranch.Element("choice2").Element("btn").Value.ToString();
        }

        private void PathClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
