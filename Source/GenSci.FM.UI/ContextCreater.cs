using GenSci.FM.Core.Context;

namespace GenSci.FM.UI
{
    public class ContextCreater
    {
        private GenSciContextBase _genSciContextBase;
        private ElementListContextBase _elementListContextBase;
        private IGenSciOperation _genSciOperation;

        public ContextCreater(GenSciContextBase genSciContextBase)
        {
            _genSciContextBase = genSciContextBase;
            
            _genSciContextBase.CreateElementListContext();
            _genSciContextBase.CreateGenSciOperation();

            _genSciContextBase.ElementListContextLeft.CreateElementListCommand();
            _genSciContextBase.ElementListContextRight.CreateElementListCommand();
        }

        public GenSciContextBase GenSciContext => _genSciContextBase;
    }
}
