using ShareFolderProgramm.ViewModel;
using System;
using System.Windows.Input;

namespace ShareFolderProgramm.Commands
{
    class CreateFoldersCommand : ICommand
    {
        private SharingFolderViewModel _viewModel;

        public CreateFoldersCommand(SharingFolderViewModel viewModel)
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
            if(_viewModel.Validate())
            {
                _viewModel.StartCreatingFolders();
            }
        }
    }
}
