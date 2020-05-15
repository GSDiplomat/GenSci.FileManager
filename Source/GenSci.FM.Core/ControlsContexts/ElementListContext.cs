using GenSci.FM.Core.Notify;
using GenSci.FM.ElementList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace GenSci.FM.Core.Context
{
    public class ElementListContext : NotifyPropertyBase
    {
        private ElementStruct _selectedElement;
        private GenSciCommand _enterDirectory;
        private KeyValuePair<DriveInfo, string> _selectedDrive;

        public ElementListContext()
        {
            foreach (var drive in DriveInfo.GetDrives())
            {
                DrivePaths.Add(drive, drive.Name);
            }

            SelectedDrive = DrivePaths.First();
        }

        public ElementListModel ElementListModel { get; } = new ElementListModel();
        public Dictionary<DriveInfo, string> DrivePaths { get; } = new Dictionary<DriveInfo, string>();

        public ElementStruct SelectedElement
        {
            get => _selectedElement;
            set
            {
                if (value != _selectedElement)
                {
                    _selectedElement = value;
                    OnPropertyChanged();
                }
            }
        }

        public KeyValuePair<DriveInfo, string> SelectedDrive
        {
            get => _selectedDrive;
            set
            {
                if (value.Key != _selectedDrive.Key)
                {
                    if (_selectedDrive.Key != null)
                        DrivePaths[_selectedDrive.Key] = ElementListModel.AddressLine;

                    _selectedDrive = value;

                    ElementListModel.AddressLine = DrivePaths[value.Key];

                    OnPropertyChanged();
                }
            }
        }


        public GenSciCommand EnterDirectory => _enterDirectory ??
            (_enterDirectory = new GenSciCommand(
                obj =>
                {
                    if (SelectedElement.FileName == "..")
                    {
                        var separetedPath = ElementListModel.AddressLine.Split("\\", StringSplitOptions.RemoveEmptyEntries);

                        if (separetedPath.Length > 1)
                        {
                            ElementListModel.AddressLine = ElementListModel.AddressLine.Replace(separetedPath.Last(), "");
                        }
                    }
                    else if (SelectedElement.ElementType == eElementType.Directory)
                    {
                        ElementListModel.AddressLine += SelectedElement.FileName + "\\";
                    }
                }));
    }
}
