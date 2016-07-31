using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SharedFolderProgrammDll.Entities.FilesBatch
{
    class FileBatch : IFileBatch
    {
        private ObservableCollection<String> _files;

        public FileBatch()
        {
            _files = new ObservableCollection<string>();
        }

        public ObservableCollection<string> Files
        {
            get
            {
                return _files;
            }
            set
            {
                _files = value;
            }
        }
    }
}
