using GenSci.FM.Core.Notify;
using GenSci.FM.ElementList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;

namespace GenSci.FM.Core.Context
{
    public class GenSciContext : GenSciContextBase
    {
        public GenSciContext()
        {
            _elementListContextLeft = new ElementListContext { IsActive = true };
            _elementListContextRight = new ElementListContext();

            _genSciOperation = new GenSciOperation(this);
        }

        public override ElementListContextBase ElementListContextLeft
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

        public override ElementListContextBase ElementListContextRight
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
    }
}
