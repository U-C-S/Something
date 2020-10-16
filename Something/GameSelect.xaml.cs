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
    /// Interaction logic for GameSelect.xaml
    /// </summary>
    public partial class GameSelect : Page
    {
        int ComboxVal,
            SelectIndex = 1,
            noofstories;
        public GameSelect(int a)
        {
            InitializeComponent();
            ComboxVal = a;
            noofstories = short.Parse(storiesXML.Root.Element("meta").Element("numberofgames").Value);
            renderer(1);
        }
        XDocument storiesXML = XDocument.Load(@"Trees\_stories.xml");
        private void indexMinus(object sender, RoutedEventArgs e)
        {
            if(SelectIndex == 1)
            {
                renderer(noofstories);
            }
            else
            {
                renderer(SelectIndex - 1);
            }
        }

        private void indexPlus(object sender, RoutedEventArgs e)
        {
            if (SelectIndex == noofstories)
            {
                renderer(1);
            }
            else
            {
                renderer(SelectIndex + 1);
            }
        }

        private void renderer(int x)
        {
            SelectIndex = x;
            string storyelem = $"story{x}";
            Heading.Text = storiesXML.Root.Element(storyelem).Element("name").Value.ToString();
            Description.Text = storiesXML.Root.Element(storyelem).Element("description").Value.ToString();
        }

        private void mouseColorEffect(object sender, MouseEventArgs e)
        {
            if (ComboxVal != 3)
            {
                double hue = (Math.Atan2(e.GetPosition(centerPoint).X, e.GetPosition(centerPoint).Y) * 180 / Math.PI) + 180;
                Brush x = new SolidColorBrush(Common.HtoRGB(hue));
                GameSelectScreen.Background = x;
            }
        }

        //XDocument storiesXML = XDocument.Load(@"Trees\_stories.xml");
        //private void renderer()
        //{
        //    int noofstories = short.Parse(storiesXML.Root.Element("meta").Element("numberofgames").Value);
        //    for (int i = 0; i < noofstories; i++)
        //    {
        //        string storyelem = $"story{i + 1}";
        //        Button storyBtn = new Button
        //        {
        //            Content = storiesXML.Root.Element(storyelem).Attribute("name").Value.ToString(),
        //            Cursor = Cursors.Hand,
        //            Width = 210,
        //            Height = 60,
        //            FontSize = 16,
        //            Tag = storyelem
        //        };
        //        storyBtn.Click += new RoutedEventHandler(StoryBtn_click);
        //        SelectPanel.Children.Add(storyBtn);
        //    }
        //}

        //private void StoryBtn_click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new Game((string)(sender as Button).Tag));
        //private void NavigateBack_Click(object sender, RoutedEventArgs e) => NavigationService.GoBack();
    }
}
