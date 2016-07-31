using SharedFolderProgrammDll.Entities.Events.FolderCreatedEvent;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SharedFolderProgrammDll.Model
{
    public interface ISharingFolderModel
    {
        Int32  AllFoldersCount { get; set; }
        Int32  ProcessedFoldersCount { get; set; }

        String ParentFolder { get; set; }
        String FolderNamePrefix { get; set; }

        event FolderHasBeenProcessed FolderProcessed;

        ObservableCollection<String> FileNames { get; set; }

        void CreateFolders();
        void ShareFolders();
        void FeedFolders();
    }
}
