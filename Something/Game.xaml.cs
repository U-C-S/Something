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
        XDocument SourceFileXML;
        XElement currentElem;
        public Game(XDocument XMLfile)
        {
            InitializeComponent();
            SourceFileXML = XMLfile;
            currentElem = SourceFileXML.Root.Element("story").Element("START");
            Renderer();
        }

        void Renderer()
        {
            BrContext.Text = currentElem.Element("conseq").Value.ToString();
            path1.Content = currentElem.Element("choice1").Element("btn").Value.ToString();
            path2.Content = currentElem.Element("choice2").Element("btn").Value.ToString();
        }

        private void PathClick(object sender, RoutedEventArgs e)
        {
            string actionElem;
            if((string)(sender as Button).Tag == "btn1")
                actionElem = currentElem.Element("choice1").Element("action").Value.ToString();
            else
                actionElem = currentElem.Element("choice2").Element("action").Value.ToString();

            if(actionElem == "END")
            {
                GameOver();
            }
            else
            {
                currentElem = SourceFileXML.Root.Element("story").Element(actionElem);
                Renderer();
            }
        }
        void GameOver()
        {
            NavigationService.Navigate(new MainPage());
        }
    }
}
