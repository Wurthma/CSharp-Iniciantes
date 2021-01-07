using System;
using System.Collections.Generic;

namespace SomaMedia
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe quantos valores deseja informar:");
            int quantidadeDeValores = int.Parse(Console.ReadLine());

            var listaDeValores = ColetarValores(quantidadeDeValores);

            // No lugar dos métodos abaixo você usar a biblioteca System.Linq do dotnet para fazer a somar e a média da lista de valores.
            Console.WriteLine($"A soma dos valores é: {CalcularSoma(listaDeValores)}");
            Console.WriteLine($"A média dos valores é: {CalcularMedia(listaDeValores)}");
        }

        static List<decimal> ColetarValores(int quantidadeValores)
        {
            /* 
            Neste método recebemos como parâmetro a quantidade de valores que serão informados pelo usuário,
            então podemos definir nossa lista já especificando quantos valores serão utilizados, mas você
            também pode criar a lista de forma 'dinâmica' -> new List<decimal>().
            */
            List<decimal> listaDeValores = new List<decimal>(quantidadeValores);
            
            for(int i = 0; i < quantidadeValores; i++)
            {
                Console.WriteLine($"Informe o valor {i+1}");
                // No trecho abaixo você pode utilizar o TryParse para validar o valor (Desafio 1 do exercício)
                listaDeValores.Add(decimal.Parse(Console.ReadLine()));
            }

            return listaDeValores;
        }

        static decimal CalcularSoma(List<decimal> listaDeValores)
        {
            decimal total = 0;
            foreach(decimal valor in listaDeValores)
                total += valor;

            return total;
        }

        static decimal CalcularMedia(List<decimal> listaDeValores)
        {
            decimal soma = CalcularSoma(listaDeValores);
            decimal media = soma / listaDeValores.Count;
            return media;
        }
    }
}
