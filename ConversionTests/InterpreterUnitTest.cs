/******************************************************************************
* Filename    = InterpreterUnitTest.cs
*
* Author      = Sneha Bhattacharjee
*
* Product     = InterpreterCurrencyConvertorDemo
* 
* Project     = ConversionTests
*
* Description = Unit tests for the interpreter pattern demo
*****************************************************************************/

using InterpreterPatternDemo;

namespace ConversionTests
{
    /// <summary>
    /// Unit tests for the interpreter design pattern demo
    /// </summary>
    [TestClass]
    public class InterpreterUnitTest
    {
        /// <summary>
        /// Test on Dollar to Rupee without overflow
        /// </summary>
        [TestMethod]
        public void TestDollar()
        {
            string expression = "43 dollars";

            double rupeeValue = Math.Round(Interpreter.Convert(expression), 4);

            Assert.AreEqual(3572.87, rupeeValue);
        }

        /// <summary>
        /// Test on Dollar to Rupee with overflow
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestDollarDoubleOverflow()
        {
            string expression = "4356874236912545239874522 dollars";

            _ = Math.Round(Interpreter.Convert(expression), 4);

            // If control flow reaches this point, then no exception was raised.
            Assert.Fail("OverflowException was not raised.");
        }

        /// <summary>
        /// Test on Dollar to Rupee without long overflow
        /// The final conversion is a long overflow
        /// Won't throw exception, since DBL_MAX is much larger
        /// </summary>
        [TestMethod]
        public void TestDollarLong()
        {
            string expression = "9223372036854775806 dollars";

            double rupeeValue = Math.Round(Interpreter.Convert(expression), 4);
            // value determined from a scientific calculator
            Assert.AreEqual(7.663699825422634E+20, rupeeValue);
        }

        /// <summary>
        /// Test on NLC to Rupee without overflow
        /// </summary>
        [TestMethod]
        public void TestNLC()
        {
            string expression = "26 NLC";

            double rupeeValue = Math.Round(Interpreter.Convert(expression), 4);

            Assert.AreEqual(948, rupeeValue);
        }

        /// <summary>
        /// Test on Rouble to Rupee without overflow
        /// </summary>
        [TestMethod]
        public void TestRouble()
        {
            string expression = "43 Rouble";

            double rupeeValue = Math.Round(Interpreter.Convert(expression), 4);

            Assert.AreEqual(36.98, rupeeValue);
        }

        /// <summary>
        /// Test on invalid/unsupported expression
        /// </summary>
        [TestMethod]
        [ExpectedException (typeof(Exception))]
        public void TestUnsupported()
        {
            string expression = "43 Dirham";

            _ = Math.Round(Interpreter.Convert(expression), 4);

            // If control flow reaches this point, then no exception was raised.
            Assert.Fail("Unsupported currency exception was not raised");
        }

        /// <summary>
        /// Test on invalid expression
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInvalidExpression()
        {
            string expression = "43 467 ffdh";

            _ = Math.Round(Interpreter.Convert(expression), 4);

            // If control flow reaches this point, then no exception was raised.
            Assert.Fail("Invalid Expression exception was not raised");
        }

        /// <summary>
        /// Reversed input test 
        /// </summary>
        [TestMethod]
        public void TestDollarReverse()
        {
            string expression = "DOLLAR 42";

            double rupeeValue = Math.Round(Interpreter.Convert(expression), 4);

            Assert.AreEqual(3489.78, rupeeValue);
        }

        /// <summary>
        /// Symbol of $ is used 
        /// </summary>
        [TestMethod]
        public void TestDollarSymbol()
        {
            string expression = "$ 42";

            double rupeeValue = Math.Round(Interpreter.Convert(expression), 4);

            Assert.AreEqual(3489.78, rupeeValue);
        }
    }
}