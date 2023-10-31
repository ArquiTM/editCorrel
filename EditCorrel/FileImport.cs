using System;
using System.IO;
using System.Linq;

namespace EditCorrel
{
    class FileImport
    {
        public string CopyingFile(string directory)
        {
            try
            {
                FormApp frmApp = new FormApp();
                string directoryPath = @".\correl";
                string file_name = directory;
                string[] vet = file_name.Split('\\');
                int x = (vet.Length - 1);
                string name = vet[x];
                string correctDirectory = directoryPath + "\\" + name;

                if (!Directory.Exists(@"correl"))
                    Directory.CreateDirectory(@"correl");

                if (!Directory.GetFileSystemEntries(directoryPath).Contains(".correl"))
                {
                    string fileToCopy = directory;
                    File.Copy(fileToCopy, correctDirectory);
                }
                return correctDirectory;
            }
            catch
            {
                return "";
            }
        }

    }
}
