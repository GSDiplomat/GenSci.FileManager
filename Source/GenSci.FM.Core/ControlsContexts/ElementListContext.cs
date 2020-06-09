using GenSci.FM.Core.Notify;
using GenSci.FM.ElementList;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GenSci.FM.Core.Context
{
    public class ElementListContext : ElementListContextBase
    {

        private KeyValuePair<DriveInfo, string> _selectedDrive;

        public override ElementListModel ElementListModel { get; } = new ElementListModel();
        public override Dictionary<DriveInfo, string> DrivePaths { get; } = new Dictionary<DriveInfo, string>();

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

        public override void CreateElementListCommand()
        {
            _elementListCommands = new ElementListCommand(this);
        }
    }
}
