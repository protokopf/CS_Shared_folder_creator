using SharedFolderProgrammDll.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SharedFolderProgrammDll.Entities.Events.FolderCreatedEvent;
using System.ComponentModel;
using System.Windows.Input;
using ShareFolderProgramm.Commands;
using System.Windows;
using ShareFolderProgramm.ViewModel.Validators;
using System.Collections.ObjectModel;

namespace ShareFolderProgramm.ViewModel
{
    public class SharingFolderViewModel :  INotifyPropertyChanged
    {
        private bool _isEnable;

        private ISharingFolderModel _model;
        private IValidator _validator;

        public SharingFolderViewModel(ISharingFolderModel model)
        {
            _model = model;
            _model.FolderProcessed += FolderProcessed;
            _validator = new SimpleValidator(this);

            ChooseParentCommand = new ChooseParentFolderCommand(this);
            CreateFoldersCommand = new CreateFoldersCommand(this);
            AddFilesCommand = new AddFilesCommand(this);
            
            AllFoldersCount = 1;
            IsControlsEnable = true;
        }

        private void FolderProcessed(FolderProcessedEventArgs e)
        {
            OnPropertyChanged("ProcessedFoldersCount");
        }

        public ICommand ChooseParentCommand { get; set; }
        public ICommand CreateFoldersCommand { get; set; }
        public ICommand AddFilesCommand { get; set; }

        public int AllFoldersCount
        {
            get
            {
                return _model.AllFoldersCount;
            }
            set
            {
                _model.AllFoldersCount = value;
                OnPropertyChanged("AllFoldersCount");
            }
        }

        public int ProcessedFoldersCount
        {
            get
            {
                return _model.ProcessedFoldersCount;
            }
            set
            {
                _model.ProcessedFoldersCount = value;
                OnPropertyChanged("CreatedFoldersCount");
            }
        }

        public ObservableCollection<string> FileNames
        {
            get
            {
                return _model.FileNames;
            }
            set
            {
                _model.FileNames = value;
                OnPropertyChanged("FileNames");
            }
        }


        public string FolderNamePrefix
        {
            get
            {
                return _model.FolderNamePrefix;
            }
            set
            {
                _model.FolderNamePrefix = value;
                OnPropertyChanged("FolderNamePrefix");
            }
        }

        public string ParentFolder
        {
            get
            {
                return _model.ParentFolder;
            }
            set
            {
                _model.ParentFolder = value;
                OnPropertyChanged("ParentFolder");
            }
        }

        public bool IsControlsEnable
        {
            get
            {
                return _isEnable;
            }
            set
            {
                _isEnable = value;
                OnPropertyChanged("IsControlsEnable");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void StartCreatingFolders()
        {
            Task.Run(() =>
            {
                IsControlsEnable = false;
                _model.CreateFolders();
                
                _model.ShareFolders();

                _model.FeedFolders();
                MessageBox.Show(String.Format("{0} folders has been created!", AllFoldersCount), "Finish", MessageBoxButton.OK, MessageBoxImage.Information);
                IsControlsEnable = true;
            });
        }
        public bool Validate()
        {
            return _validator.Validate();
        }

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
