namespace GenSci.FM.Core.Context
{
    public interface IGenSciOperation
    {
        void SwapPanels();

        void ChangeActivePanel();

        void CopyElement();

        void ReplaceElement();

        void RemoveElement();

        void CreateElement();

        void RenameElement();
    }
}