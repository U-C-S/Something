using System;
using System.Collections.Generic;
using System.IO;
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
        string GameAddress;
        readonly XDocument storiesXML = XDocument.Load(@"Trees\_stories.xml");

        public GameSelect(int a)
        {
            InitializeComponent();
            ComboxVal = a;
            noofstories = short.Parse(storiesXML.Root.Element("meta").Element("numberofgames").Value);
            renderer(1);
        }
        private void IndexPlusOrMinus(object sender, RoutedEventArgs e)
        {
            if ((string)(sender as Button).Tag == "m")
            {
                if (SelectIndex == 1) renderer(noofstories);
                else renderer(SelectIndex - 1);
            }
            else
            {
                if (SelectIndex == noofstories) renderer(1);
                else renderer(SelectIndex + 1);
            }
        }

        private void renderer(int x)
        {
            SelectIndex = x;
            string storyelem = $"story{x}";
            Heading.Text = storiesXML.Root.Element(storyelem).Element("name").Value.ToString();
            Description.Text = storiesXML.Root.Element(storyelem).Element("description").Value.ToString();
            Heading.FontFamily = FontofHeading(storyelem);

            GameAddress = storiesXML.Root.Element(storyelem).Element("filename").Value.ToString();
        }
        private FontFamily FontofHeading(string source)
        {
            XAttribute fontAttr = storiesXML.Root.Element(source).Element("name").Attribute("font");
            string x;
            if (fontAttr != null)
            {
                switch (fontAttr.Value.ToString())
                {
                    case "1": x = "Segoe Print"; break;
                    case "2": x = "Comic Sans MS"; break;
                    case "3": x = "Candara Light"; break;
                    default:  x = "Segoe UI"; break;
                }
                return new FontFamily(x);
            }
            else return new FontFamily("Segoe UI");
        }

        private void Button_Click(object sender, RoutedEventArgs e) => NavigationService.GoBack();

        private void mouseColorEffect(object sender, MouseEventArgs e)
        {
            if (ComboxVal != 3)
            {
                double hue = (Math.Atan2(e.GetPosition(centerPoint).X, e.GetPosition(centerPoint).Y) * 180 / Math.PI) + 180;
                Brush x = new SolidColorBrush(Common.HtoRGB(hue));
                GameSelectScreen.Background = x;
            }
        }

        private void BeginScenario(object sender, RoutedEventArgs e)
        {
            XDocument GameXML = XDocument.Load(Path.Combine("Trees", GameAddress));
            NavigationService.Navigate(new Game(GameXML));
        }
    }
}
