using GenSci.FM.Core.Notify;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace GenSci.FM.ElementList
{
    public class ElementListModel : NotifyPropertyBase
    {
        private string _addressLine = DriveInfo.GetDrives().First().Name;
        private ObservableCollection<ElementStruct> _files;

        public ElementListModel()
        {
            _files = GetDirectoryElements();
        }

        public string AddressLine
        {
            get => _addressLine;
            set
            {
                if (value != _addressLine)
                {
                    if (Directory.Exists(_addressLine))
                    {
                        _addressLine = value;

                        Files = GetDirectoryElements();

                        OnPropertyChanged();
                    }
                }
            }
        }

        public ObservableCollection<ElementStruct> Files
        {
            get => _files;
            set
            {
                if (value != _files)
                {
                    _files = value;
                    OnPropertyChanged();
                }
            }
        }

        public void RefreshDirectory() => Files = GetDirectoryElements();

        private ObservableCollection<ElementStruct> GetDirectoryElements()
        {
            var resultCollection = new ObservableCollection<ElementStruct>();

            if (_addressLine.Split("\\", StringSplitOptions.RemoveEmptyEntries).Length > 1)
                resultCollection.Add(new ElementStruct { FileName = ".." });

            var directoryInfo = new DirectoryInfo(_addressLine);

            var fileList = directoryInfo.GetFiles();
            var directoryList = directoryInfo.GetDirectories();

            foreach (var file in fileList)
                resultCollection.Add(new ElementStruct { ElementType = eElementType.File, FileName = file.Name, Size = file.Length });

            foreach (var directory in directoryList)
                resultCollection.Add(new ElementStruct { ElementType = eElementType.Directory, FileName = directory.Name, Size = "Каталог" });

            return resultCollection;
        }
    }
}
