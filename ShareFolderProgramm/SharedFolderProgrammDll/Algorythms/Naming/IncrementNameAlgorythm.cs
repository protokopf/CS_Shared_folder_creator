using System;

namespace SharedFolderProgrammDll.Algorythms.Naming
{
    public class IncrementNameAlgorythm : ICreatingNameAlgorythm
    {
        private Int32 _number = 0;

        public string CreateNameWith(string prefix)
        {
            return prefix + _number++.ToString();
        }
    }
}
