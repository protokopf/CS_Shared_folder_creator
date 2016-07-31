using ShareFolderProgramm.ViewModel;
using System;
using System.Windows.Forms;
using System.Windows.Input;

namespace ShareFolderProgramm.Commands
{
    class ChooseParentFolderCommand : ICommand
    {

        private SharingFolderViewModel _viewModel;
        public ChooseParentFolderCommand(SharingFolderViewModel viewModel)
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
            FolderBrowserDialog browser = new FolderBrowserDialog();

            DialogResult result = browser.ShowDialog();
            if(result == DialogResult.OK)
            {
                _viewModel.ParentFolder = browser.SelectedPath;
            }
        }
    }
}
