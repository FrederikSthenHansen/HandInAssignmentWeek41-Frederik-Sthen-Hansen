using WeightLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConverterTester
{
    [TestClass]
    public class ConvertTester
    {
        private double _myConverterResult;
        private double _actualResult;
        private double _allowedInaccurracy = 0.000001;

        [TestMethod]
        public void GramsToOunceTest()
        {
            _myConverterResult = Converter.GramsToOunces(42.00);
            _actualResult = 1.4815064019;

            Assert.AreEqual(_actualResult, _myConverterResult,_allowedInaccurracy);
        }

        [TestMethod]
        public void OuncesToGramsTest()
        {
            _myConverterResult = Converter.OuncesToGrams(42.00);
            _actualResult = 1190.67984;

            Assert.AreEqual(_actualResult, _myConverterResult, _allowedInaccurracy);
        }
    }
}
