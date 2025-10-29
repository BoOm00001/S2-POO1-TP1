using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionTP1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionTP1.Tests
{
    [TestClass()]
    public class NumberGeneratorTests
    {
        [TestMethod]
        public void TestEmptyConstructorCreateSequentialGenerator()
        {
            NumberGenerator gen = new NumberGenerator();

            for (int i = 1; i < 100; i++)
            {
                Assert.AreEqual(i, gen.Next());
            }
        }  //Nb genarator pour le constructeur il prend un long il faudrait ajouter un L 

        [TestMethod]
        public void TestIntConstructorCreateConstantGenerator_5()
        {
            int expected = 5;
            NumberGenerator gen = new NumberGenerator(expected);

            for (int i = 1; i < 100; i++)
            {
                Assert.AreEqual(expected, gen.Next());
            }
        }

        [TestMethod]
        public void TestIntConstructorCreateConstantGenerator_7()
        {
            int expected = 7;
            NumberGenerator gen = new NumberGenerator(expected);

            for (int i = 1; i < 100; i++)
            {
                Assert.AreEqual(expected, gen.Next());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "La valeur de zéro est interdite")]
        public void TestIntConstructorRefuses_0()
        {
            int parameter = 0;
            NumberGenerator gen = new NumberGenerator(parameter);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "La valeur est trop élevée")]
        public void TestIntConstructorRefuses_1000()
        {
            int parameter = 1000;

            NumberGenerator gen = new NumberGenerator(parameter);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "La valeur négative est interdite")]
        public void TestIntConstructorRefusesNegative()
        {
            int parameter = -1;
            NumberGenerator gen = new NumberGenerator(parameter);

        }

        [TestMethod]
        public void TestLongConstructorGeneratesPseudorandomSequenceProperlySeeded()
        {
            long parameter = 1337l;
            NumberGenerator gen = new NumberGenerator(parameter);
            Random random = new Random((int)parameter);

            for (int i = 0; i < 1000; i++)
            {
                Assert.AreEqual(random.Next(1, 1000), gen.Next());
            }
        }

        [TestMethod]
        public void TestLongConstructorGeneratesPseudorandomSequenceAlwaysInBounds_1337()
        {
            long parameter = 1337L;
            NumberGenerator gen = new NumberGenerator(parameter);

            for (int i = 0; i < 1000; i++)
            {

                int val = gen.Next();
                Assert.IsTrue(val > 0);
                Assert.IsTrue(val < 1000);
            }
        }

        [TestMethod]
        public void TestLongConstructorGeneratesPseudorandomSequenceAlwaysInBounds_1()
        {
            long parameter = 1l;
            NumberGenerator gen = new NumberGenerator(parameter);

            for (int i = 0; i < 1000; i++)
            {

                int val = gen.Next();
                Assert.IsTrue(val > 0);
                Assert.IsTrue(val < 1000);
            }
        }

        [TestMethod]
        public void TestLongConstructorGeneratesPseudorandomSequenceAlwaysInBounds_99()
        {
            long parameter = 99L;
            NumberGenerator gen = new NumberGenerator(parameter);

            for (int i = 0; i < 1000; i++)
            {

                int val = gen.Next();
                Assert.IsTrue(val > 0);
                Assert.IsTrue(val < 1000);
            }
        }
    }
}