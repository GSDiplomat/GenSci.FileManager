using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GenSci.FM.Core.Context
{
    public class GenSciContext
    {
        public List<ElementListContext> ElementListContext { get; set; } = new List<ElementListContext> { new ElementListContext(), new ElementListContext() };
    }
}
