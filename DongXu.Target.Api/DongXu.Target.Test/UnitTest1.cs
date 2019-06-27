using DongXu.Target.IRepository;
using DongXu.Target.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DongXu.Target.Test
{
    [TestClass]
    public class UnitTest1
    {

        LoginRepository login = new LoginRepository();




        [TestMethod]
        public void TestMethod1()
        {
            string name = "niu1";
            string pass = "1";
            var result = login.Login(name,pass);

            Assert.IsNotNull(result);
        }
    }
}
