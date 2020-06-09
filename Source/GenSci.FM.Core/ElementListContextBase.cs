using GenSci.FM.Core.Notify;
using GenSci.FM.ElementList;
using System.Collections.Generic;
using System.IO;

namespace GenSci.FM.Core.Context
{
    public abstract class ElementListContextBase : NotifyPropertyBase
    {
        protected IElementListCommand _elementListCommands;
        private GenSciCommand _enterDirectory;

        public abstract ElementListModel ElementListModel { get; }

        public abstract Dictionary<DriveInfo, string> DrivePaths { get; }

        public abstract bool IsActive { get; set; }

        public abstract ElementStruct SelectedElement { get; set; }

        public abstract KeyValuePair<DriveInfo, string> SelectedDrive { get; set; }

        public GenSciCommand EnterDirectory => _enterDirectory ?? (_enterDirectory = new GenSciCommand(obj => _elementListCommands.EnterDirectory()));
    }
}