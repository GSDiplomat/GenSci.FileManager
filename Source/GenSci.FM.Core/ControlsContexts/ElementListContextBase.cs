using GenSci.FM.Core.Notify;
using GenSci.FM.ElementList;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace GenSci.FM.Core.Context
{
    public abstract class ElementListContextBase : NotifyPropertyBase
    {
        protected IElementListCommand _elementListCommands;
        
        private ICommand _enterDirectory;
        
        private bool _isActive = false;
        private ElementStruct _selectedElement;

        public ElementListContextBase()
        {
            foreach (var drive in DriveInfo.GetDrives())
            {
                DrivePaths.Add(drive, drive.Name);
            }

            SelectedDrive = DrivePaths.First();
        }

        public abstract ElementListModel ElementListModel { get; }

        public abstract Dictionary<DriveInfo, string> DrivePaths { get; }

        public abstract KeyValuePair<DriveInfo, string> SelectedDrive { get; set; }
        public bool IsActive
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

        public ICommand EnterDirectory => _enterDirectory ?? (_enterDirectory = new GenSciCommand(obj => _elementListCommands.EnterDirectory()));

        public abstract void CreateElementListCommand();
    }
}