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
            SelectIndex = 0,
            noofstories = 0;
        string GameAddress;
        readonly XDocument storiesXML = XDocument.Load(@"Trees\_stories.xml");
        List<XElement> storey = new List<XElement>();

        public GameSelect(int a)
        {
            InitializeComponent();
            ComboxVal = a;
            StoriesXMLFileOperations();
            renderer(0);
        }
        void StoriesXMLFileOperations()
        {
            IEnumerable<XElement> stories = storiesXML.Root.Elements("story");
            foreach (XElement story in stories)
            {
                storey.Add(story);
                noofstories++;
            }
        }
        private void IndexPlusOrMinus(object sender, RoutedEventArgs e)
        {
            if ((string)(sender as Button).Tag == "m")
            {
                if (SelectIndex == 0) renderer(noofstories - 1);
                else renderer(SelectIndex - 1);
            }
            else
            {
                if (SelectIndex == noofstories -1) renderer(0);
                else renderer(SelectIndex + 1);
            }
        }

        private void renderer(int x)
        {
            SelectIndex = x;
            XElement storyelem = storey[x];
            XElement name = storyelem.Element("name");
            Heading.Text = name.Value;
            Heading.FontFamily = FontofHeading(name);
            Description.Text = storyelem.Element("description").Value.ToString();
            GameAddress = storyelem.Element("filename").Value.ToString();
        }
        private FontFamily FontofHeading(XElement source)
        {
            XAttribute HeadFOnt = source.Attribute("font");
            string x;
            if (HeadFOnt != null)
            {
                switch (HeadFOnt.Value)
                {
                    case "sp": x = "Segoe Print"; break;
                    case "cs": x = "Comic Sans MS"; break;
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
            try
            {
                XDocument GameFile = XDocument.Load(Path.Combine("Trees", GameAddress));
                NavigationService.Navigate(new Game(GameFile));
            }
            catch (FileNotFoundException)
            {
                Common.ErrorBox(1);
                NavigationService.GoBack();
            }
        }
    }
}
