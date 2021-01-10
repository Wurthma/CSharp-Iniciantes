using System;

namespace JogoForca
{
    public class PalavraForca
    {
        public PalavraForca(string categoria, string palavra)
        {
            Categoria = categoria;
            Palavra = palavra;
        }

        public string Categoria { get; set; }
        public string Palavra { get; set; }
    }
}