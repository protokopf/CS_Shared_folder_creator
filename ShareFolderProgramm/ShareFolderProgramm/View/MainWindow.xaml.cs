using ShareFolderProgramm.ViewModel;
using System.Collections.Generic;
using System.Windows;

namespace ShareFolderProgramm.View
{
    public partial class MainWindow : Window
    {
        private SharingFolderViewModel _viewModel;

        public MainWindow(SharingFolderViewModel viewModel)
        {
            _viewModel = viewModel;
            DataContext = _viewModel;

            InitializeComponent();
        }

        private void RemoveFilesCommand(object sender, RoutedEventArgs e)
        {
            List<int> indexes = new List<int>();

            foreach(var item in listBox.SelectedItems)
                indexes.Add(listBox.Items.IndexOf(item));

            foreach(int index in indexes)
                _viewModel.FileNames.RemoveAt(index);
        }
    }
}
