namespace GenSci.FM.ElementList
{
    public enum eElementType
    {
        Directory,
        File
    }

    public struct ElementStruct
    {
        public eElementType ElementType { get; set; }
        public string FileName { get; set; }
        public object Size { get; set; }

        public static bool operator ==(ElementStruct element1, ElementStruct element2) => element1.FileName == element2.FileName;

        public static bool operator !=(ElementStruct element1, ElementStruct element2) => element1.FileName != element2.FileName;
    }
}