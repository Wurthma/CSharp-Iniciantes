using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JogoForca
{
    public class Forca
    {
        public byte TentativasDisponiveis { get; private set; }
        
        public byte TentativasUsadas { get; private set; }

        public int TentativasRestantes { get; set; }

        private List<PalavraForca> Filmes { get; set; }

        private List<PalavraForca> Jogos { get; set; }

        private List<PalavraForca> Paises { get; set; }

        private PalavraForca PalavraSorteada { get; set; }

        private ECategoriaPalavra CategoriaSorteada { get; set; }

        public string Categoria { get => CategoriaSorteada.ToString(); }

        public List<char> LetrasUsadas { get; set; }

        public string LetrasCorretasDaPalavra { get; set; }

        private string ControleLetrasJaInformadas { get; set; }

        private byte QuantidadeTentativasPadrao { get => 6; }

        public bool PalavraConluida { get => VerificarSeConcluiuPalavra(); }
        
        public Forca()
        {// O padrao de tentativa é 6, mas pode ser customizado no segundo construtor
            InicializarJogo(QuantidadeTentativasPadrao);
        }

        public Forca(byte tentativasDisponiveis)
        {
            InicializarJogo(tentativasDisponiveis);
        }

        private void InicializarJogo(byte tentativas)
        {
            TentativasUsadas = 0;
            TentativasDisponiveis = tentativas;
            RecalcularTentativasRestantes();
            CarregarPalavras();
            SortearNovaPalavra();
            AtualizarLetrasCorretasDaPalavra();
            ControleLetrasJaInformadas = RemoverAcentos(PalavraSorteada.Palavra);

            LetrasUsadas = new List<char>();
        }

        private void RecalcularTentativasRestantes()
        {
            TentativasRestantes = TentativasDisponiveis - TentativasUsadas;
        }

        private bool VerificarSeConcluiuPalavra() => string.IsNullOrEmpty(ControleLetrasJaInformadas.Replace(" ", "").Replace("#", ""));

        public PalavraForca SortearNovaPalavra()
        {
            
            var random = new Random();
            CategoriaSorteada = (ECategoriaPalavra)random.Next(0,2);
            var listaDePalavrasDaCategoria = RetornarListaPalavrasPorCategoria(CategoriaSorteada);
            int posicaoPalavra = random.Next(0, listaDePalavrasDaCategoria.Count);

            PalavraSorteada = listaDePalavrasDaCategoria[posicaoPalavra];
            return PalavraSorteada;
        }

        public bool TentarNovaLetra(char letra)
        {
            char letraSemAcentos = RemoverAcentos(letra);

            if(LetrasUsadas.Any(c => c == letraSemAcentos))
            {
                Console.WriteLine();
                Console.WriteLine($"Letra {letra} já utilizada. Pressione qualquer tecla para informar outra.");
                Console.ReadKey();
                return false;
            }
            else
            {
                AtualizarForcaComNovaLetra(letraSemAcentos);
                return true;
            }
        }

        private void AtualizarForcaComNovaLetra(char letra)
        {
            if(TentativasUsadas < TentativasDisponiveis)
            {
                LetrasUsadas.Add(letra);
                if(PalavraSorteadaContemLetra(letra))
                {
                    AtualizarLetrasCorretasDaPalavra(letra);
                }
                else
                {
                    TentativasUsadas++;
                    RecalcularTentativasRestantes();
                }
            }
            else 
            {
                Console.WriteLine();
                Console.WriteLine("Você não possui mais tentativas. Pressione uma tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void AtualizarLetrasCorretasDaPalavra()
        {
            LetrasCorretasDaPalavra = string.Empty;
            var lestras = PalavraSorteada.Palavra.ToCharArray();
            var qtdeLetras = PalavraSorteada.Palavra.ToCharArray().Count();

            foreach(var letra in lestras)
            {
                if(letra == ' ')
                    LetrasCorretasDaPalavra += letra.ToString();
                else
                    LetrasCorretasDaPalavra += "_";
            }
        }

        private void AtualizarLetrasCorretasDaPalavra(char letra)
        {
            var posicaoLetra = ControleLetrasJaInformadas.ToUpper().IndexOf(letra.ToString());
            
            if(posicaoLetra < 0)
                return;
            
            //remove a letra que já foi encontrada
            ControleLetrasJaInformadas = ControleLetrasJaInformadas.Remove(posicaoLetra, 1).Insert(posicaoLetra, "#"); 
            // remove o underline e coloca a letra no lugar
            LetrasCorretasDaPalavra = LetrasCorretasDaPalavra.Remove(posicaoLetra, 1).Insert(posicaoLetra, PalavraSorteada.Palavra.Substring(posicaoLetra, 1));

            AtualizarLetrasCorretasDaPalavra(letra);
        }

        private bool PalavraSorteadaContemLetra(char letra) => ControleLetrasJaInformadas.ToCharArray().ToList().Exists(c => c == letra);

        private string RemoverAcentos(string texto)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            byte[] tempBytes;
            tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(texto);

            return System.Text.Encoding.UTF8.GetString(tempBytes).ToUpper();
        }

        private char RemoverAcentos(char letra)
        {
            string letraString = letra.ToString().ToUpper();
            
            return RemoverAcentos(letraString).ToCharArray().FirstOrDefault();
        }

        private List<PalavraForca> RetornarListaPalavrasPorCategoria(ECategoriaPalavra categoria)
        {
            switch(categoria)
            {
                case ECategoriaPalavra.Filme: return Filmes;
                case ECategoriaPalavra.Jogo: return Jogos;
                case ECategoriaPalavra.Pais: return Paises;
                default: throw new ArgumentException("Categoria de palavra invalida.");
            }
        }

        private void CarregarPalavras()
        {
            Filmes = new List<PalavraForca>();
            Jogos = new List<PalavraForca>();
            Paises = new List<PalavraForca>();

            var diretorio = Directory.GetCurrentDirectory();
            var path = Path.Combine(diretorio, "ListaPalavras.csv");
            var linhas = File.ReadAllLines(path);

            foreach(var linha in linhas)
            { // cada linha do CSV deve ter sempre o nome e a categoria, ou causará erro na nossa aplicação, estude como tratar o erro
                var palavras = linha.Split(";");

                string palavra = palavras[0];
                ECategoriaPalavra categoria = (ECategoriaPalavra)Convert.ToInt32(palavras[1]);

                CarregarPalavraParaSuaCategoria(palavra, categoria);
            }
        }

        private void CarregarPalavraParaSuaCategoria(string nome, ECategoriaPalavra categoria)
        {
            var palavra = new PalavraForca(categoria.ToString(), nome);
            switch(categoria)
            {
                case ECategoriaPalavra.Filme: CarregarPalavra(Filmes, palavra); break;
                case ECategoriaPalavra.Jogo: CarregarPalavra(Jogos, palavra); break;
                case ECategoriaPalavra.Pais: CarregarPalavra(Paises, palavra); break;
                default: throw new ArgumentException("Categoria de palavra invalida.");
            }
        }

        private void CarregarPalavra(List<PalavraForca> listaPalavraForca, PalavraForca palavra)
        {
            listaPalavraForca.Add(palavra);
        }
    }
}