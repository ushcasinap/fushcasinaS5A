using System;
using System.Collections.Generic;
using System.Text;

namespace fushcasinaS5A.Utils
{
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string fileName)
        {
            
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, fileName);
        }
    }
}
