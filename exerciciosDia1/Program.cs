using System;
using System.Collections.Generic;
using System.Linq;
using users;

namespace exerciciosDia1
{
    class Program
    {
        static void Main(string[] args)
        {
            //exercicio1();
            exercicio2();
        }

        static void exercicio1()
        {
            double caloriasGastas = calcularCalorias(2, 3);
            Console.WriteLine(caloriasGastas);
        }
        static double calcularCalorias(int andares, int quantidadeVoltas)
        {
            double calorias = 0;

            for (int i = 0; i < quantidadeVoltas; i++)
            {
                for (int j = 0; j < andares; j++)
                {
                    calorias += 2.2;
                }
            }
            return calorias;
        }

        static void exercicio2()
        {
            void PrintUserList(List<Usuario> l)
            {
                l.ForEach(i => Console.WriteLine($"{i.Nome}: {i.Idade}"));
            }

            List<Usuario> usuarios = new List<Usuario>() {
                new Usuario() { Nome = "Usuario 1", Idade = 12 },
                new Usuario() { Nome = "Usuario 2", Idade = 15 },
                new Usuario() { Nome = "Usuario 3", Idade = 19 },
                new Usuario() { Nome = "Usuario 4", Idade = 20 },
                new Usuario() { Nome = "Usuario 5", Idade = 18 }
            };

            Console.WriteLine("Todos os usnarios:");
            PrintUserList(usuarios);

            // Somente os usuários maior de idade;
            List<Usuario> maioresDeIdade = usuarios.Where((usr) => usr.Idade>17).ToList();
            Console.WriteLine("Usuarios maiores de idade:");
            PrintUserList(maioresDeIdade);

            // Quantidade dos usuários maior de idade;
            Console.WriteLine(usuarios.Where((u) => u.Idade >= 18).Count());

            // Ou
            Console.WriteLine(usuarios.Count((u) => u.Idade >= 18));

            // Soma das idades
            Console.WriteLine(usuarios.Sum((u) => u.Idade));

            // Lista Somente as Idades dos Usuários

            usuarios.Select((u) => u.Idade).ToList().ForEach(i => Console.WriteLine(i));
        }
        
    }
}
