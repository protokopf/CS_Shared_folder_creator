using SharedFolderProgrammDll.Entities.Events.FolderCreatedEvent;
using System;
using System.Collections.Generic;

namespace SharedFolderProgrammDll.Model
{
    public interface ISharingFolderModel
    {
        Int32  AllFoldersCount { get; set; }
        Int32  ProcessedFoldersCount { get; set; }

        String ParentFolder { get; set; }
        String FolderNamePrefix { get; set; }

        event FolderHasBeenProcessed FolderProcessed;
        
        List<String> FileNames { get; }

        void CreateFolders();
        void ShareFolders();
        void FeedFolders();
    }
}
