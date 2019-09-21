using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriceEngine.Core.Operators;

namespace PriceEngine.Core.Tests.Operators
{
    [TestClass]
    public class OperatorTests
    {
        [TestMethod]
        public void When_integers_are_equal_equaloperator_should_return_true()
        {
            var result = new EqualsCheck().Check(1, 1);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void When_integers_differ_equaloperator_should_return_false()
        {
            
            var result = new EqualsCheck().Check(1, 2);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void When_strings_are_equal_equaloperator_should_return_true()
        {
            var result = new EqualsCheck().Check("test", "test");
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void When_strings_differ_equaloperator_should_return_false()
        {
            var result = new EqualsCheck().Check("test", "anotherstring");
            Assert.IsFalse(result);
        }
    }
}
