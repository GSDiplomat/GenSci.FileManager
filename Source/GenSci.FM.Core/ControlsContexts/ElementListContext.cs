using GenSci.FM.Core.Notify;
using GenSci.FM.ElementList;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GenSci.FM.Core.Context
{
    public class ElementListContext : ElementListContextBase
    {
        private bool _isActive = false;
        private ElementStruct _selectedElement;
        private KeyValuePair<DriveInfo, string> _selectedDrive;

        public ElementListContext()
        {
            _elementListCommands = new ElementListCommand(this);

            foreach (var drive in DriveInfo.GetDrives())
            {
                DrivePaths.Add(drive, drive.Name);
            }

            SelectedDrive = DrivePaths.First();
        }

        public override ElementListModel ElementListModel { get; } = new ElementListModel();
        public override Dictionary<DriveInfo, string> DrivePaths { get; } = new Dictionary<DriveInfo, string>();

        public override bool IsActive
        {
            get => _isActive;
            set
            {
                if (value != _isActive)
                {
                    _isActive = value;
                    OnPropertyChanged();
                }
            }
        }

        public override ElementStruct SelectedElement
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

        public override KeyValuePair<DriveInfo, string> SelectedDrive
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

    }
}
