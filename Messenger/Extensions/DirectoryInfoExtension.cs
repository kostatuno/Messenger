using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shkiper_Messenger.Extensions
{
    /// <summary>
    /// Moves up the directory by a certain amount.
    /// </summary>
    public static class DirectoryInfoExtension
    {
        public static string GetParents(this DirectoryInfo directory, int numOfLifting)
        {
            if (numOfLifting == 0)
            {
                return directory.FullName;
            }
            return GetParents(directory.Parent, numOfLifting - 1);
        }
    }
}
