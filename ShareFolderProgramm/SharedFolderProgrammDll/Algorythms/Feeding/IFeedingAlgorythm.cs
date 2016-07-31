using SharedFolderProgrammDll.Entities.FilesBatch;
using SharedFolderProgrammDll.Entities.Folder;

namespace SharedFolderProgrammDll.Algorythms.Feeding
{
    public interface IFeedingAlgorythm
    {
        void Feed(IFolder folder, IFileBatch fileBatch);
    }
}
