using SharedFolderProgrammDll.Entities.Folder;
using System;

namespace SharedFolderProgrammDll.Algorythms.Creating
{
    public interface ICreatingFolderAlgorythm
    {
        IFolder Create(String name, String parentPath);
    }
}
