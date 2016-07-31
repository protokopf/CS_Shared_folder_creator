using SharedFolderProgrammDll.Entities.FilesBatch;
using SharedFolderProgrammDll.Entities.Folder;
using System.IO;

namespace SharedFolderProgrammDll.Algorythms.Feeding
{
    public class FeederAlgorythm : IFeedingAlgorythm
    {
        public void Feed(IFolder folder, IFileBatch fileBatch)
        {
            if(Directory.Exists(folder.Path))
            {
                foreach(string fileName in fileBatch.Files)
                {
                    CopyFileToFolder(fileName, folder.Path);
                }
            }
        }

        private void CopyFileToFolder(string file, string folder)
        {
            if(File.Exists(file))
            { 
                File.Copy(file, Path.Combine(folder, Path.GetFileName(file)),true);
            }
        }
    }
}
