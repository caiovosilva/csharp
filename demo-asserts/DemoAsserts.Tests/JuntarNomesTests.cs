using NUnit.Framework;
using DemoAsserts;
namespace Tests
{
    [TestFixture]
    public class JuntarNomesTests
    {
        [Test]
        public void DeveJuntarDoisNomes()
        {
            var sut = new JuntarNomes();
            var nomeCompleto = sut.Juntar("Caio", "Silva");
            Assert.That(nomeCompleto, Is.EqualTo("Caio Silva"));
        }
    }
}