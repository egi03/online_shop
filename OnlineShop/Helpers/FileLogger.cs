using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Helpers
{
    class FileLogger
    {
        public string FilePath { get; private set; }
        public FileLogger() 
        {
            FilePath = "receipt.txt";
        }
        public FileLogger(string filePath)
        {
            FilePath = filePath;
        }
        public void SetFilePath(string filePath)
        {
            FilePath = filePath;
        }
        public void Log(string message)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(FilePath))
            {
                writer.WriteLine(message);
            }
        }
    }
}
