using NUnit.Framework;
using DemoAsserts;

namespace Tests
{
    [TestFixture]
    public class CalculadoraTests
    {
        /* Método para testar se irá somar 2 números inteiros */
        [Test]
        public void DevoSomarNumerosInteiros()
        {
            var sut = new Calculadora();

            var resultado = sut.SomarNumerosInteiros(4, 2);

            Assert.That(resultado, Is.EqualTo(6));
        }

        /* Método para testar a tolerância de valores usando o método 'Within' */
        [Test]
        public void DevoSomarNumerosDecimais_UsandoWithin()
        {
            var sut = new Calculadora();

            var resultado = sut.SomarNumerosDecimais(1.1, 2.2); //3.3

            //Se o resultado estiver entre: 3,29 e 3,31 - teste ok!
            Assert.That(resultado, Is.EqualTo(3.3).Within(0.01)); 
        }

        /* Método para testar a tolerância de valores percentuais usando o método 'Within' */
        [Test]
        public void DevoSomarNumerosDecimais_UsandoWithinPorcentagem()
        {
            var sut = new Calculadora();

            var resultado = sut.SomarNumerosDecimais(50, 50); // 100%

            //Se o resultado estiver entre:  - teste ok!
            Assert.That(resultado, Is.EqualTo(101).Within(1).Percent); // tolerância de 1%
        }
    }
}