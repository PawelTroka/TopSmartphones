using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TopSmartphones
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    /*
Przygotować aplikację w WPF
Wymagania:
     * aplikacja powinna prezentować podstawowe mechanizmy WPF np. w zakresie grafiki/grafiki 3D, animacji, stylów itd. /DONE
     * Aplikcja powinna obejmowac przynajmniej 3 okna (należy zapewnic przekazywanie danych miedzy nimi) /DONE
     * Nalezy zrealizowac scenariusz master/detail /DONE
Przykładowy temat aplikacji terminarz. Termin oddawania: zajecia projektowe w tygodniu 27.10-31.10.
     */
    public partial class MainWindow : Window
    {
        private ObservableCollectionWithItemNotify<Smartphone> _smartphones;

        public MainWindow()
        {
            using (var sf = new SmartphoneFactory())
            {
                sf.produce();
                _smartphones = new ObservableCollectionWithItemNotify<Smartphone>(sf.smartphones);
            }

            SmartphoneDetails = new ObservableCollectionWithItemNotify<Detail>();

            DataContext = this;
            InitializeComponent();

            selectedSmartphones = smartphonesListBox.SelectedItems;
        }

        public ObservableCollectionWithItemNotify<Smartphone> smartphones
        {
            get { return _smartphones; }
            set { _smartphones = value; }
        }


        private Smartphone m_SelectedSmartphone
        {
            get
            {
                if (smartphonesListBox == null || smartphonesListBox.SelectedItem == null) return null;
                return smartphonesListBox.SelectedItem as Smartphone;
            }
            set { smartphonesListBox.SelectedItem = value; }
        }

        private IEnumerable<Detail> m_DetailSmartphoneProperty
        {
            get
            {
                if (m_SelectedSmartphone == null) yield break;
                foreach (PropertyInfo property in m_SelectedSmartphone.GetType().GetProperties())
                    yield return new Detail(property.Name, property.GetValue(m_SelectedSmartphone));
            }
        }

        public ObservableCollectionWithItemNotify<Detail> SmartphoneDetails { get; set; }

        public IList selectedSmartphones { get; set; }


        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Paweł Troka, 132334, Programowanie Lokalnych Aplikacji .NET");
        }

        private void SmartphonesListBox_OnSelected(object sender, RoutedEventArgs e)
        {
            selectedSmartphones = smartphonesListBox.SelectedItems;
            SmartphoneDetails.Clear();

            foreach (Detail d in m_DetailSmartphoneProperty)
                SmartphoneDetails.Add(d);
        }

        private void EditItemsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (smartphonesListBox.SelectedItem != null)
            {
                var editWindow = new EditSelectedItems((Smartphone) smartphonesListBox.SelectedItem);
                bool? result = editWindow.ShowDialog();
                //if(result==true)
                //  smartphonesListBox.
            }
        }

        private void EditListMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (smartphonesListBox.SelectedItems != null)
            {
                var compareWindow = new CompareWindow(selectedSmartphones);
                bool? result = compareWindow.ShowDialog();
                if (result == true)
                {
                }
            }
        }

        private void AddMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var sp = new Smartphone("", "");
            var editWindow = new EditSelectedItems(sp);
            bool? result = editWindow.ShowDialog();

            if (result == true)
            {
                _smartphones.Add(sp);
            }
        }

        private void smartphonesListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item =
                ItemsControl.ContainerFromElement(smartphonesListBox, e.OriginalSource as DependencyObject) as
                    ListBoxItem;
            if (item != null)
            {
                var imageWindow = new ImageWindow((item.Content as Smartphone).PictureLocation);
                imageWindow.Show();
            }
        }
    }
}