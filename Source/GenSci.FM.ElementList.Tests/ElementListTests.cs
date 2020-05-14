using NUnit.Framework;
using GenSci.FM.ElementList;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GenSci.FM.ElementList.Tests
{
    [TestFixture()]
    public class ElementListTests
    {
        [Test()]
        public void ElementListTest()
        {
            var directoryInfo = new DirectoryInfo(@"C:\");
            var files = directoryInfo.GetFiles();

            var elementList = new ElementListModel();


            string[] resultList = new string[files.Length];

            for (int i = 0; i < resultList.Length; i++)
                resultList[i] = elementList.Files[i].FileName;

            Assert.AreEqual(files, resultList);
        }
    }
}