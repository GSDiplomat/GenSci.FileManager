using GenSci.FM.Core.Notify;
using GenSci.FM.ElementList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace GenSci.FM.Core.Context
{
    public class ElementListContext : NotifyPropertyBase
    {
        private ElementStruct _selectedElement;
        private GenSciCommand _enterDirectory;

        public ElementListModel ElementListModel { get; set; } = new ElementListModel();


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
                        ElementListModel.AddressLine += SelectedElement.FileName;
                    }
                }));
    }
}
