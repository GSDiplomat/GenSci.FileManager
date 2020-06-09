using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GenSci.FM.ElementList
{
    public static class ElementManagement
    {
        public static void CopyFile(string sourceFileName, string destFileName) => 
            File.Copy(sourceFileName, destFileName);

        public static void ReplaceFile(string sourceFileName, string destFileName, string destinationBackupFileName) => 
            File.Replace(sourceFileName, destFileName, destinationBackupFileName);

        public static void Remove(ElementListModel elementListModel, ElementStruct selectedElement)
        {
            var elementAddress = elementListModel.AddressLine + selectedElement.FileName;

            if (selectedElement.ElementType == eElementType.Directory)
                Directory.Delete(elementAddress);
            else
                File.Delete(elementAddress);
        }

        public static bool CreateDirectory(string newFolderPath)
        {
            bool fileExist = !Directory.Exists(newFolderPath);
            
            if(fileExist)
                Directory.CreateDirectory(newFolderPath);

            return fileExist;
        }
    }
}
