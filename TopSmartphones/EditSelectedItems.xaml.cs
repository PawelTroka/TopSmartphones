using System.Reflection;
using System.Windows;

namespace TopSmartphones
{
    /// <summary>
    ///     Interaction logic for EditSelectedItems.xaml
    /// </summary>
    public partial class EditSelectedItems : Window
    {
        private readonly Smartphone _smartphone;

        public EditSelectedItems(Smartphone smartphone)
        {
            _smartphone = smartphone;

            DataContext = this;
            InitializeComponent();

            PropertyGrid.CurrentObject = new Smartphone(_smartphone); //= this.smartphoneCopy;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            PropertyInfo[] props = typeof (Smartphone).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if (prop.CanRead && prop.CanWrite)
                    prop.SetValue(_smartphone, prop.GetValue(PropertyGrid.CurrentObject));
            }
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}