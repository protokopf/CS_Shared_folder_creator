using System;
using System.Collections.Generic;

namespace SharedFolderProgrammDll.Entities.FilesBatch
{
    class FileBatch : IFileBatch
    {
        private List<String> _files;

        public FileBatch()
        {
            _files = new List<string>();
        }

        public List<string> Files
        {
            get
            {
                return _files;
            }
        }
    }
}
