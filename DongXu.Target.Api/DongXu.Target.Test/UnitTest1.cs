using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DongXu.Target.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Repository.LoginRepository login = new Repository.LoginRepository();
            Assert.IsTrue(login.GetPower(1)!=null);

        }
    }
}
