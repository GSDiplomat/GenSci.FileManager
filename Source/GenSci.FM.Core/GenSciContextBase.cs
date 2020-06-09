using GenSci.FM.Core.Notify;
using System.Windows.Input;

namespace GenSci.FM.Core.Context
{
    public abstract class GenSciContextBase
    {
        protected ElementListContextBase _elementListContextLeft;
        protected ElementListContextBase _elementListContextRight;

        protected IGenSciOperation _genSciOperation;

        private ICommand _swapPanels;
        private ICommand _changeActivePanel;
        private ICommand _copyElement;
        private ICommand _replaceElement;
        private ICommand _removeElement;
        private ICommand _createElement;
        private ICommand _renameElement;

        public ElementListContextBase ElementListContextLeft
        {
            get => _elementListContextLeft;
            set => _elementListContextLeft = value;
        }

        public ElementListContextBase ElementListContextRight
        {
            get => _elementListContextRight;
            set => _elementListContextRight = value;
        }

        public ICommand SwapPanels => _swapPanels ??
                (_swapPanels = new GenSciCommand(obj => _genSciOperation.SwapPanels()));

        public ICommand ChangeActivePanel => _changeActivePanel ??
            (_changeActivePanel = new GenSciCommand(obj => _genSciOperation.ChangeActivePanel()));


        public ICommand CopyElement => _copyElement ??
            (_copyElement = new GenSciCommand(obj => _genSciOperation.CopyElement()));


        public ICommand ReplaceElement => _replaceElement ??
            (_replaceElement = new GenSciCommand(obj => _genSciOperation.ReplaceElement()));


        public ICommand RemoveElement => _removeElement ??
            (_removeElement = new GenSciCommand(obj => _genSciOperation.RemoveElement()));


        public ICommand CreateElement => _createElement ??
            (_createElement = new GenSciCommand(obj => _genSciOperation.CreateElement()));

        public ICommand RenameElement => _renameElement ??
            (_renameElement = new GenSciCommand(obj => _genSciOperation.RenameElement()));

        public abstract void CreateElementListContext();

        public abstract void CreateGenSciOperation();
    }
}