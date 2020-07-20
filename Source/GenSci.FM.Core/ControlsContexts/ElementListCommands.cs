using GenSci.FM.ElementList;
using System;
using System.Linq;

namespace GenSci.FM.Core.Context
{
    class ElementListCommand : IElementListCommand
    {
        private ElementListContextBase _elementListContext;

        public ElementListCommand(ElementListContextBase elementListContext)
        {
            _elementListContext = elementListContext;
        }

        public void EnterDirectory()
        {
            if (_elementListContext.SelectedElement != null)
            {
                if (_elementListContext.SelectedElement.FileName == "..")
                {
                    var separetedPath = _elementListContext.ElementListModel.AddressLine.Split("\\", StringSplitOptions.RemoveEmptyEntries);

                    if (separetedPath.Length > 1)
                    {
                        string addressLine = _elementListContext.ElementListModel.AddressLine;

                        addressLine = addressLine.Remove(addressLine.Length - 1);
                        addressLine = addressLine.Replace(separetedPath.Last(), "");

                        _elementListContext.ElementListModel.AddressLine = addressLine;
                    }
                }
                else if (_elementListContext.SelectedElement.ElementType == eElementType.Directory)
                {
                    _elementListContext.ElementListModel.AddressLine += _elementListContext.SelectedElement.FileName + "\\";
                }
            }
        }
    }
}
