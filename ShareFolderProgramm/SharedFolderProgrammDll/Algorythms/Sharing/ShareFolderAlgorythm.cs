using System;
using SharedFolderProgrammDll.Entities.Folder;
using System.Management;

namespace SharedFolderProgrammDll.Algorythms.Sharing
{
    public class ShareFolderAlgorythm : ISharingFolderAlgorythm
    {
        public void ShareFolder(IFolder folder)
        {
            ManagementClass managementClass = new ManagementClass("Win32_Share");
            ManagementBaseObject inParams = managementClass.GetMethodParameters("Create");
            ManagementBaseObject outParams;


            inParams["Description"] = String.Format("Shared {0}", folder.Name) ;
            inParams["Name"] = folder.Name;
            inParams["Path"] = folder.Path;
            inParams["Type"] = 0x0; // Disk Drive

            outParams = managementClass.InvokeMethod("Create", inParams, null);
        }
    }
}
