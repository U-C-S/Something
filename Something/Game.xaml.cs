using System;
using System.Collections;
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
            ajna("START");
            Renderer();
        }
        void ajna(string source)
        {
            IEnumerable<XElement> a = SourceFileXML.Root.Element("body").Elements("div");
            foreach (XElement e in a)
            {
                if(e.Attribute("id").Value == source)
                {
                    currentElem = e;
                }
            }
        }
        void Renderer()
        {
            try
            {
                BrContext.Text = currentElem.Element("p").Value.ToString();
                path1.Content = currentElem.Elements("a").First().Value.ToString();
                path2.Content = currentElem.Elements("a").Last().Value.ToString();
            }
            catch (System.NullReferenceException)
            {
                Common.ErrorBox(2);
                GameOver();
            }
        }

        private void PathClick(object sender, RoutedEventArgs e)
        {
            string actionElem;

            if ((string)(sender as Button).Tag == "btn1")
                actionElem = currentElem.Elements("a").First().Attribute("href").Value.ToString();
            else
                actionElem = currentElem.Elements("a").Last().Attribute("href").Value.ToString();

            actionElem = actionElem.Remove(0,1);
            if (actionElem == "END")
            {
                GameOver();
            }
            else
            {
                ajna(actionElem);
                Renderer();
            }
        }
        void GameOver()
        {
            try
            {
                NavigationService.Navigate(new MainPage());
            }
            catch (NullReferenceException)
            {
                Common.ErrorBox();
            }
        }
    }
}
