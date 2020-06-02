
using System.Windows;
using Weather.Core;
using Weather.WPF.ViewModels;

namespace Weather.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = ContainerProvider.Resolve<MainViewModel>();
        }
    }
}
