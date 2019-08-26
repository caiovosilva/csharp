using NUnit.Framework;
using Prime.Services;

namespace Prime.UnitTests.Services
{
    [TestFixture]
    public class PrimeService_IsPrimeShould
    {
        [TestCase(2)]
        [TestCase(7)]
        [TestCase(23)]
        [TestCase(31)]
        [TestCase(53)]
        [TestCase(79)]
        [TestCase(97)]
        public void IsPrime_InputIsTrue_ReturnTrue(int value)
        {
            PrimeService primeService = CreatePrimeService();
            var result = primeService.IsPrime(value);
            Assert.IsTrue(result, $"{value} should not be prime");
        }
        
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(57)]
        [TestCase(77)]
        [TestCase(63)]
        [TestCase(30)]
        public void IsPrime_ValuesAreNotPrime_ReturnFalse(int value)
        {
            PrimeService primeService = CreatePrimeService();
            var result = primeService.IsPrime(value);
            Assert.IsFalse(result, $"{value} should not be prime");
        }
        
        private PrimeService CreatePrimeService()
        {
             return new PrimeService();
        }
    }
}