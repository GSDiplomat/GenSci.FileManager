using GenSci.FM.ElementList;
using System.IO;
using System.Threading.Tasks.Dataflow;

namespace GenSci.FM.Core.Context
{
    internal class GenSciOperation : IGenSciOperation
    {
        private GenSciContext _genSciContext;

        public GenSciOperation(GenSciContext genSciContext)
        {
            _genSciContext = genSciContext;
        }

        public void ChangeActivePanel()
        {
            if (_genSciContext.ElementListContextLeft.IsActive)
            {
                _genSciContext.ElementListContextLeft.IsActive = false;
                _genSciContext.ElementListContextRight.IsActive = true;
            }
            else
            {
                _genSciContext.ElementListContextLeft.IsActive = true;
                _genSciContext.ElementListContextRight.IsActive = false;
            }
        }

        public void CopyElement()
        {
            var activePanel = GetActivePanel();
            var inactivePanel = GetInactivePanel();
            var sourceFileName = activePanel.ElementListModel.AddressLine + activePanel.SelectedElement.FileName;
            var destFileName = inactivePanel.ElementListModel.AddressLine + activePanel.SelectedElement.FileName;

            ElementManagement.CopyFile(sourceFileName, destFileName);
            inactivePanel.ElementListModel.RefreshDirectory();
        }

        public void CreateElement()
        {
            var activePanelModel = GetActivePanel().ElementListModel;

            var newFolderPath = activePanelModel.AddressLine + "NewFolder";

            if (ElementManagement.CreateDirectory(newFolderPath))
                activePanelModel.RefreshDirectory();

        }

        public void RemoveElement()
        {
            var activePanel = GetActivePanel();

            ElementManagement.Remove(activePanel.ElementListModel, activePanel.SelectedElement);

            activePanel.ElementListModel.RefreshDirectory();
        }

        public void RenameElement()
        {
            throw new System.NotImplementedException();
        }

        public void ReplaceElement()
        {
            throw new System.NotImplementedException();
        }

        public void SwapPanels()
        {
            var templContext = _genSciContext.ElementListContextLeft;

            _genSciContext.ElementListContextLeft = _genSciContext.ElementListContextRight;

            _genSciContext.ElementListContextRight = templContext;
        }

        private ElementListContextBase GetActivePanel() =>
            _genSciContext.ElementListContextLeft.IsActive ?
            _genSciContext.ElementListContextLeft : _genSciContext.ElementListContextRight;

        private ElementListContextBase GetInactivePanel() =>
            !_genSciContext.ElementListContextLeft.IsActive ?
            _genSciContext.ElementListContextLeft : _genSciContext.ElementListContextRight;
    }
}