﻿using System;
using System.IO;
using System.Windows;

namespace ShareFolderProgramm.ViewModel.Validators
{
    class SimpleValidator : IValidator
    {
        private SharingFolderViewModel _viewModel;

        public SimpleValidator(SharingFolderViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool Validate()
        {
            return ValidateParentFolder() && ValidateFoldersCount() && ValidatePrefix();
        }

        private bool ValidateParentFolder()
        {
            bool isExists = Directory.Exists(_viewModel.ParentFolder);
            if(!isExists)
            {
                MessageBox.Show("Parent directory does not exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return isExists;
        }
        private bool ValidateFoldersCount()
        {
            bool isCorrect = _viewModel.AllFoldersCount >= 0;
            if(!isCorrect)
            {
                MessageBox.Show("Folders count is not correct!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return isCorrect;
        }
        private bool ValidatePrefix()
        {
            bool isOk =  !String.IsNullOrWhiteSpace(_viewModel.FolderNamePrefix);
            if(!isOk)
            {
                MessageBox.Show("Enter correct folder name prefix!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return isOk;
        }
    }
}
