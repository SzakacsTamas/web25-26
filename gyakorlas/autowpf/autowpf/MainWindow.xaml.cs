using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace autowpf
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

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<adatok> autok = new List<adatok>();
            string[] sorok = File.ReadAllLines("szerviz.txt");

            for (int i = 0; i < sorok.Length; i++)
            {
                string[] adatok = sorok[i].Split("\t");
                adatok adat = new adatok(adatok[0], adatok[1], DateOnly.Parse(adatok[2]), adatok[3], DateOnly.Parse(adatok[4]));
                autok.Add(adat);
            }
            var valtozo = autok.Select(s=>s.rendSzam).Distinct().OrderByDescending(s=>s.Length);
            xbox.ItemsSource=valtozo.OrderBy(s=>s);

        }
    }
}