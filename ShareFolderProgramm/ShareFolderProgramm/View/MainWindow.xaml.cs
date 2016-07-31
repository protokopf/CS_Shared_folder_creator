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
            List<string> strings = new List<string>();

            foreach(var item in listBox.SelectedItems)
                strings.Add(item.ToString());

            foreach (string str in strings)
                _viewModel.FileNames.Remove(str);
        }
    }
}
