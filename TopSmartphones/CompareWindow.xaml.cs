using System.Collections;
using System.Windows;

namespace TopSmartphones
{
    /// <summary>
    ///     Interaction logic for CompareWindow.xaml
    /// </summary>
    public partial class CompareWindow : Window
    {
        public CompareWindow(IList smartphones)
        {
            DataContext = this;
            this.smartphones = smartphones;
            InitializeComponent();
        }

        public IList smartphones { get; set; }
    }
}