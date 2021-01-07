using System;

namespace JogarDados
{
    // Classe simplificada para facilitar consulta.
    // Possível aplicar os conceitos de Orientação a Objeto para melhorar qualidade do código fonte.
    class Program
    {
        // Criação de variáveis para acessar os jogadores de qualquer método.
        public static string Jogador1;
        public static string Jogador2;

        // Variáveis para armazenar a pontuação dos jogadores
        public static byte PontosJogador1;
        public static byte PontosJogador2;

        // Variável para armazenar a rodada atual
        public static byte RodadaAtual;
        
        static void Main(string[] args)
        {
            Console.Clear();
            ConfigurarJogo();
            IniciarRodadas();
        }

        public static void ConfigurarJogo()
        {
            RodadaAtual = 0;

            CriarJogadores();
            AtualizarPlacar();

            Console.WriteLine($"\n Jogadores {Jogador1} e {Jogador2} criados. Pressione qualquer tecla para iniciar o jogo."); // \n para pular mais uma linha antes de imprimir a frase
            Console.ReadKey();
        }

        public static void CriarJogadores()
        {
            Console.WriteLine("Informe o nome do primeiro jogador:");
            Jogador1 = Console.ReadLine();
            PontosJogador1 = 0;
            Console.WriteLine("Informe o nome do segundo jogador:");
            Jogador2 = Console.ReadLine();
            PontosJogador2 = 0;
        }

        public static void AtualizarPlacar()
        {
            Console.Clear();
            Console.WriteLine($"### Pontos do jogador {Jogador1}: {PontosJogador1}");
            Console.WriteLine($"### Pontos do jogador {Jogador2}: {PontosJogador2}");
            Console.WriteLine();

            if(RodadaAtual == 0)
            {
                Console.WriteLine("### Jogo não iniciado...");
            }
        }

        // Esse método faz uso de recursão, pesquise sobre o assunto caso não conheça...
        public static void IniciarRodadas()
        {
            AtualizarPlacar();
            if(RodadaAtual == 3)
            {
                FinalizarJogo();
                return;
            }
            
            RodadaAtual++;

            Console.WriteLine($"Rodada {RodadaAtual} iniciada!\n");

            Console.WriteLine($"Jogador {Jogador1}, pressione ENTER para fazer sua jogada...");
            Console.ReadLine();
            byte valorTiradoJogador1 = JogarDado();
            Console.WriteLine($"Valor do dado jogado pelo {Jogador1}: {valorTiradoJogador1}");

            Console.WriteLine($"Jogador {Jogador2}, pressione ENTER para fazer sua jogada...");
            Console.ReadLine();
            byte valorTiradoJogador2 = JogarDado();
            Console.WriteLine($"Valor do dado jogado pelo {Jogador2}: {valorTiradoJogador2}");

            if(valorTiradoJogador1 == valorTiradoJogador2)
            {
                Console.WriteLine($"\n{Jogador1} tirou o número {valorTiradoJogador1} e {Jogador2} o número {valorTiradoJogador2}. Empate!");
                Console.WriteLine("Pressione ENTER para continuar com o jogo...");
                Console.ReadLine();
            }
            else
            {
                string vencedor;

                if(valorTiradoJogador1 > valorTiradoJogador2)
                {
                    vencedor = Jogador1;
                    PontosJogador1++;
                }
                else
                {
                    vencedor = Jogador2;
                    PontosJogador2++;
                }

                Console.WriteLine($"\n{Jogador1} tirou o número {valorTiradoJogador1} e {Jogador2} o número {valorTiradoJogador2}. {vencedor} venceu a rodada {RodadaAtual}");
                Console.WriteLine("Pressione ENTER para continuar com o jogo...");
                Console.ReadLine();
            }

            IniciarRodadas();
        }

        public static byte JogarDado()
        {
            Random random = new Random();
            return Convert.ToByte(random.Next(1, 6));
        }

        public static void FinalizarJogo()
        {
            AtualizarPlacar();
            Console.WriteLine("Jogo finalizado!!!");

            if(PontosJogador1 == PontosJogador2)
            {
                Console.WriteLine("Empate!");
            }
            else if(PontosJogador1 > PontosJogador2)
            {
                Console.WriteLine($"O jogador {Jogador1} venceu com {PontosJogador1} pontos!");
            }
            else
            {
                Console.WriteLine($"O jogador {Jogador2} venceu com {PontosJogador2} pontos!");
            }
        }
    }
}
