namespace SharedFolderProgrammDll.Entities.Folder
{
    class FolderEntity : IFolder
    {
        private string _name;
        private string _path;

        public FolderEntity(string name, string path)
        {
            _name = name;
            _path = path;
        }

        #region IFolder implementation

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
            }
        }

        #endregion
    }
}
