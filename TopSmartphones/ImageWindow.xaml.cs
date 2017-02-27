using System.Windows;

namespace TopSmartphones
{
    /// <summary>
    ///     Interaction logic for ImageWindow.xaml
    /// </summary>
    public partial class ImageWindow : Window
    {
        public ImageWindow(string imageLocation)
        {
            DataContext = this;
            PictureLocation = imageLocation;
            InitializeComponent();
        }

        public string PictureLocation { get; set; }
    }
}