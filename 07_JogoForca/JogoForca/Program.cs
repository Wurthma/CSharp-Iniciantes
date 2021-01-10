using System;

namespace JogoForca
{
    public class Program
    {
        public static void Main(string[] args)
        {
            do 
            {
                Jogar();
            }
            while(RepetirJogo());
        }

        private static bool RepetirJogo()
        {
            Console.WriteLine();
            Console.WriteLine("Pressione 'S' para jogar novamente ou qualquer outra tecla para sair.");
            var readKey = Console.ReadKey();

            return readKey.KeyChar.ToString().ToUpper() == "S";
        }

        private static void Jogar()
        {
            var forca = new Forca();
            while(forca.TentativasRestantes > 0)
            {
                AtualizarResultados(forca);

                if(!forca.PalavraConluida)
                {
                    Console.WriteLine("Informe uma nova letra: ");
                    var readKey = Console.ReadKey();
                    forca.TentarNovaLetra(readKey.KeyChar);
                }
                else
                {
                    AtualizarResultados(forca);
                    Console.WriteLine();
                    Console.WriteLine("Fim de jogo, você venceu!");
                    return;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Fim de jogo, você perdeu!");
        }

        private static void AtualizarResultados(Forca forca)
        {
            Console.Clear();
            Console.WriteLine($"Tentativas disponíveis: {forca.TentativasDisponiveis}");
            Console.WriteLine($"Tentativas usadas: {forca.TentativasUsadas}");
            Console.WriteLine($"Tentativas restantes: {forca.TentativasRestantes}");
            Console.WriteLine();
            Console.WriteLine($"Categoria: {forca.Categoria}");
            Console.WriteLine($"Letras já utilizadas: {ListarLetrasUsadas(forca)}");
            Console.WriteLine();
            Console.WriteLine($"Adivinhe as letras da palavra:");
            Console.WriteLine(forca.LetrasCorretasDaPalavra);
            Console.WriteLine();
        }

        private static string ListarLetrasUsadas(Forca forca)
        {
            string letrasUsadas = string.Empty;

            foreach(var letra in forca.LetrasUsadas)
            {
                letrasUsadas += $"{letra} - ";
            }

            return letrasUsadas;
        }
    }
}
