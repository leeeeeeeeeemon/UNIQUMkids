using Microsoft.VisualStudio.TestTools.UnitTesting;
using UNIQUMkidsCore;
namespace UNIQUMkidsTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGettingParent()
        {
            Assert.AreEqual(2, GetDataFromDB.GetParent().Find(x => x.id_Parent == 2));
        }
    }
}