using ShareFolderProgramm.ViewModel;
using System.Windows;

namespace ShareFolderProgramm.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SharingFolderViewModel _viewModel;

        public MainWindow(SharingFolderViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;

            InitializeComponent();
        }

        private void RemoveFilesClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
