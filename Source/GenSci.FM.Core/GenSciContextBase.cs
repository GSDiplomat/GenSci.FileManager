using GenSci.FM.Core.Notify;

namespace GenSci.FM.Core.Context
{
    public abstract class GenSciContextBase : NotifyPropertyBase
    {
        protected ElementListContextBase _elementListContextLeft;
        protected ElementListContextBase _elementListContextRight;

        protected IGenSciOperation _genSciOperation;

        private GenSciCommand _swapPanels;
        private GenSciCommand _changeActivePanel;
        private GenSciCommand _copyElement;
        private GenSciCommand _replaceElement;
        private GenSciCommand _removeElement;
        private GenSciCommand _createElement;
        private GenSciCommand _renameElement;

        public abstract ElementListContextBase ElementListContextLeft { get; set; }

        public abstract ElementListContextBase ElementListContextRight { get; set; }

        public GenSciCommand SwapPanels => _swapPanels ??
            (_swapPanels = new GenSciCommand(obj => _genSciOperation.SwapPanels()));

        public GenSciCommand ChangeActivePanel => _changeActivePanel ??
            (_changeActivePanel = new GenSciCommand(obj => _genSciOperation.ChangeActivePanel()));


        public GenSciCommand CopyElement => _copyElement ??
            (_copyElement = new GenSciCommand(obj => _genSciOperation.CopyElement()));


        public GenSciCommand ReplaceElement => _replaceElement ??
            (_replaceElement = new GenSciCommand(obj => _genSciOperation.ReplaceElement()));


        public GenSciCommand RemoveElement => _removeElement ??
            (_removeElement = new GenSciCommand(obj => _genSciOperation.RemoveElement()));


        public GenSciCommand CreateElement => _createElement ??
            (_createElement = new GenSciCommand(obj => _genSciOperation.CreateElement()));

        public GenSciCommand RenameElement => _renameElement ??
            (_renameElement = new GenSciCommand(obj => _genSciOperation.RenameElement()));
    }
}