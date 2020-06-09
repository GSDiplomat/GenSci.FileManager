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
        public override void CreateElementListContext()
        {
            _elementListContextLeft = new ElementListContext { IsActive = true };
            _elementListContextRight = new ElementListContext();
        }

        public override void CreateGenSciOperation()
        {
            _genSciOperation = new GenSciOperation(this);
        }
    }
}
