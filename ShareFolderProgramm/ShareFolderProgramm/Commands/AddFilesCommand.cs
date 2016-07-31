using ShareFolderProgramm.ViewModel;
using System;
using System.Windows.Forms;
using System.Windows.Input;

namespace ShareFolderProgramm.Commands
{
    class AddFilesCommand : ICommand
    {
        private SharingFolderViewModel _viewModel;

        public AddFilesCommand(SharingFolderViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach(string str in dlg.FileNames)
                {
                    _viewModel.FileNames.Add(str);
                }
            }
        }
    }
}
