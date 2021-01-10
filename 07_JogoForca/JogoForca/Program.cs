using System;

namespace JogoForca
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var forca = new Forca();
            
            Console.WriteLine("");
        }

        public static void AtualizarResultados(Forca forca)
        {
            Console.Clear();
            Console.WriteLine($@"Tentativas disponíveis: {forca.TentativasDisponiveis}");
            Console.WriteLine($@"Tentativas usadas: {forca.TentativasUsadas}");
            Console.WriteLine($@"Tentativas restantes: {forca.TentativasRestantes}");
        }
    }
}
