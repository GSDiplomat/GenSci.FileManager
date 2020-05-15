using GenSci.FM.Core.Notify;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GenSci.FM.Core.Context
{
    public class GenSciContext : NotifyPropertyBase
    {
        private GenSciCommand _swapPanels;
        private ElementListContext _elementListContextLeft = new ElementListContext();
        private ElementListContext _elementListContextRight = new ElementListContext();
        private ElementListContext _activeElementList;

        public ElementListContext ElementListContextLeft
        {
            get => _elementListContextLeft;
            set
            {
                if (value != _elementListContextLeft)
                {
                    _elementListContextLeft = value;
                    OnPropertyChanged();
                }
            }
        }

        public ElementListContext ElementListContextRight
        {
            get => _elementListContextRight;
            set
            {
                if (value != _elementListContextRight)
                {
                    _elementListContextRight = value;
                    OnPropertyChanged();
                }
            }
        }

        public ElementListContext ActiveElementList
        {
            get => _activeElementList;
            set
            {
                if (value != _activeElementList)
                {
                    _activeElementList = value;
                    OnPropertyChanged();
                }
            }
        }

        public GenSciCommand SwapPanels => _swapPanels ?? (_swapPanels = new GenSciCommand(obj => Swap()));

        private void Swap()
        {
            var templContext = ElementListContextLeft;

            ElementListContextLeft = ElementListContextRight;

            ElementListContextRight = templContext;
        }
    }
}
