using System;
using System.Collections.Generic;
using SharedFolderProgrammDll.Entities.Events.FolderCreatedEvent;
using SharedFolderProgrammDll.Algorythms.Naming;
using SharedFolderProgrammDll.Algorythms.Creating;
using SharedFolderProgrammDll.Algorythms.Feeding;
using SharedFolderProgrammDll.Algorythms.Sharing;
using SharedFolderProgrammDll.Entities.Folder;
using SharedFolderProgrammDll.Entities.FilesBatch;


namespace SharedFolderProgrammDll.Model
{
    public class SharingModel : ISharingFolderModel
    {
        private Int32 _allFoldersCount;
        private Int32 _processedFoldersCount;

        private String _folderNamePrefix;
        private String _parentFolder;

        private IFolder[] _folders;
        private IFileBatch _fileBatch;

        private ICreatingNameAlgorythm _namingAlgorythm;
        private ICreatingFolderAlgorythm _creatingAlgorythm;
        private ISharingFolderAlgorythm _sharingAlgorythm;
        private IFeedingAlgorythm _feedingAlgorythm;
        

        public SharingModel (ICreatingNameAlgorythm nameAlgorythm, ICreatingFolderAlgorythm folderAlgorythm,
            IFeedingAlgorythm feedingAlgorythm, ISharingFolderAlgorythm sharingFolderAlg)
        {
            _namingAlgorythm = nameAlgorythm;
            _creatingAlgorythm = folderAlgorythm;
            _sharingAlgorythm = sharingFolderAlg;
            _feedingAlgorythm = feedingAlgorythm;
                     
            _fileBatch = new FileBatch();
        }

        #region ISharingFolderModel implementation

        public Int32 AllFoldersCount
        {
            get
            {
                return _allFoldersCount;
            }
            set
            {
                _allFoldersCount = value;
            }
        }

        public Int32 ProcessedFoldersCount
        {
            get
            {
                return _processedFoldersCount;
            }
            set
            {
                _processedFoldersCount = value;
            }
        }

        public List<String> FileNames
        {
            get
            {
                return _fileBatch.Files;
            }
        }

        public String FolderNamePrefix
        {
            get
            {
                return _folderNamePrefix;
            }
            set
            {
                _folderNamePrefix = value;
            }
        }

        public String ParentFolder
        {
            get
            {
                return _parentFolder;
            }
            set
            {
                _parentFolder = value;
            }
        }

        public event FolderHasBeenProcessed FolderProcessed;

        public void CreateFolders()
        {
            _folders = new FolderEntity[_allFoldersCount];           
            while(ProcessedFoldersCount != _allFoldersCount)
            { 
                String folderName = _namingAlgorythm.CreateNameWith(_folderNamePrefix);
                _folders[ProcessedFoldersCount] = _creatingAlgorythm.Create(folderName, _parentFolder);

                ++_processedFoldersCount;
                OnFolderProcessed();
            }
            _processedFoldersCount = 0;
            OnFolderProcessed();
        }

        public void ShareFolders()
        {
            foreach (IFolder folder in _folders)
            {
                _sharingAlgorythm.ShareFolder(folder);

                ++_processedFoldersCount;
                OnFolderProcessed();
            }
            _processedFoldersCount = 0;
            OnFolderProcessed();
        }

        public void FeedFolders()
        {
            foreach(IFolder folder in _folders)
            {
                _feedingAlgorythm.Feed(folder, _fileBatch);
                ++_processedFoldersCount;
                OnFolderProcessed();
            }
            _processedFoldersCount = 0;
            OnFolderProcessed();
        }



        #endregion

        protected void OnFolderProcessed()
        {
            FolderProcessed?.Invoke(null);
        }
    }
}
