using SharedFolderProgrammDll.Entities.Folder;
using System.IO;

namespace SharedFolderProgrammDll.Algorythms.Creating
{
    public class CreateFolderAlgorythm : ICreatingFolderAlgorythm
    {
        public IFolder Create(string name, string parentPath)
        {
            IFolder folder = null;
            if(Directory.Exists(parentPath))
            {
                string fullPath = Path.Combine(parentPath, name);
                Directory.CreateDirectory(fullPath);
                folder = new FolderEntity(name, fullPath);
            }
            return folder;
        }
    }
}
