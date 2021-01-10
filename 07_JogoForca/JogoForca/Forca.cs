using System;
using System.IO;

namespace JogoForca
{
    public class Forca
    {
        public byte TentativasDisponiveis { get; private set; }
        
        public byte TentativasUsadas { get; private set; }

        public int TentativasRestantes { get; set; }
        
        public Forca()
        {// O padrao de tentativa é 6, mas pode ser customizado no segundo construtor
            TentativasDisponiveis = 6;
            RecalcularTentativasRestantes();
        }

        public Forca(byte tentativasDisponiveis)
        {
            TentativasDisponiveis = tentativasDisponiveis;
            RecalcularTentativasRestantes();
        }

        private void RecalcularTentativasRestantes()
        {
            TentativasRestantes = TentativasDisponiveis - TentativasUsadas;
        }

        private void SortearPalavra()
        {

        }

        private void CarregarPalavras()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), @"\ListaPalavras.csv");
            //File.ReadAllLines(path);
        }
    }
}