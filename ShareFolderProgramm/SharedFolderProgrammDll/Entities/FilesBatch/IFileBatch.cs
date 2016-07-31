using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SharedFolderProgrammDll.Entities.FilesBatch
{
    public interface IFileBatch
    {
        ObservableCollection<String> Files { get; set; }
    }
}
