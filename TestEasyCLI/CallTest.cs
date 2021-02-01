using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestEasyCLI
{
    [TestClass]
    public class CallTest
    {
        class Foo
        {
            string bar(int id, string name = "aaa")
            {
                return id + name;
            }
        }

        [TestMethod]
        public void SimpleTest()
        {
            var c = new EasyCLI.EasyCLI();
            c.AddClass(new Foo());

            var a = c.Call<string>("foo bar --id 20 --name hello");
            if (a != "20hello")
            {
                Assert.Fail();
            }
            var d = c.Call<string>("foo bar --id 20");
            if (d != "20aaa")
            {
                Assert.Fail();
            }
        }
    }
}