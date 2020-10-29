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
        XDocument SourceFile;
        XElement currentElem;
        public Game(XDocument file)
        {
            InitializeComponent();
            SourceFile = file;
            Renderer("START");
        }

        void Renderer(string source)
        {
            ElementAttacher(source);
            try
            {
                BrContext.Text = currentElem.Element("p").Value.ToString();
                path1.Content = currentElem.Elements("a").First().Value.ToString();
                path2.Content = currentElem.Elements("a").Last().Value.ToString();
            }
            catch (NullReferenceException)
            {
                Common.ErrorBox(2);
                GameOver();
            }
        }
        void ElementAttacher(string source)
        {
            IEnumerable<XElement> a = SourceFile.Root.Element("body").Elements("div");
            foreach (XElement e in a)
            {
                if (e.Attribute("id").Value == source)
                {
                    currentElem = e;
                }
            }
        }

        private void PathClick(object sender, RoutedEventArgs e)
        {
            string actionElem = (string)(sender as Button).Tag == "btn1" ? 
                currentElem.Elements("a").First().Attribute("href").Value.ToString() : currentElem.Elements("a").Last().Attribute("href").Value.ToString();
            actionElem = actionElem.Remove(0,1);

            if (actionElem == "END") GameOver();
            else Renderer(actionElem);
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
