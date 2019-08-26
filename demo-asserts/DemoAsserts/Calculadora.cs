using System;

namespace DemoAsserts
{
    public class Calculadora
    {
        public int SomarNumerosInteiros(int n1, int n2)
        {
            return n1+n2;
        }

        public double SomarNumerosDecimais(double n1, double n2)
        {
            return n1+n2;
        }

        public double Dividir(double n1, double n2)
        {
            if(n1 > 100)
                throw new ArgumentOutOfRangeException("por");
                
            return n1/n2;
        }
    }
}
