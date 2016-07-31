using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedFolderProgrammDll.Entities.Folder;
using System.Security.Principal;
using System.Management;
using System.Security.AccessControl;

namespace SharedFolderProgrammDll.Algorythms.Sharing
{
    public class ShareFolderAndGiveFullAccessToEveryone : ISharingFolderAlgorythm
    {
        public void ShareFolder(IFolder folder)
        {
            SecurityIdentifier sid = GetSecurityIdentifier();
            byte[] utenteSIDArray = new byte[sid.BinaryLength];
            sid.GetBinaryForm(utenteSIDArray, 0);

            ManagementObject oGrpTrustee = new ManagementClass(new ManagementPath("Win32_Trustee"), null);
            oGrpTrustee["Name"] = ((NTAccount)sid.Translate(typeof(NTAccount))).ToString();
            oGrpTrustee["SID"] = utenteSIDArray;

            ManagementObject oGrpACE = new ManagementClass(new ManagementPath("Win32_Ace"), null);
            oGrpACE["AccessMask"] = 2032127;
            oGrpACE["AceFlags"] = AceFlags.ObjectInherit | AceFlags.ContainerInherit;
            oGrpACE["AceType"] = AceType.AccessAllowed;
            oGrpACE["Trustee"] = oGrpTrustee;

            ManagementObject oGrpSecurityDescriptor = new ManagementClass(new ManagementPath("Win32_SecurityDescriptor"), null);
            oGrpSecurityDescriptor["ControlFlags"] = 4;
            oGrpSecurityDescriptor["DACL"] = new object[] { oGrpACE };

            string FolderPath = folder.Path;
            string ShareName = folder.Name;
            string Description = "Shared folder";
            ManagementClass mc = new ManagementClass("win32_share");
            ManagementBaseObject inParams = mc.GetMethodParameters("Create");
            inParams["Description"] = Description;
            inParams["Name"] = ShareName;
            inParams["Path"] = FolderPath;
            inParams["Type"] = 0x0;
            inParams["MaximumAllowed"] = null;
            inParams["Password"] = null;
            inParams["Access"] = oGrpSecurityDescriptor;
            ManagementBaseObject outParams = mc.InvokeMethod("Create", inParams, null);
        }

        private SecurityIdentifier GetSecurityIdentifier()
        {
            return new SecurityIdentifier(WellKnownSidType.WorldSid, null);
        }
    }
}
