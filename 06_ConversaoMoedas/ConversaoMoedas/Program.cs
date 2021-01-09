using System;

namespace ConversaoMoedas
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            var conversaoMoeda = new ConversaoMoeda(EMoeda.Real);
            Console.WriteLine("Você está usando a moeda Real (BLR).");
            EMoeda tipoMoedaAConverter = EscolherMoedaConversao();
            decimal valorEmRealParaConverter = LerQuantidadeConverter();
            decimal valorConvertido = conversaoMoeda.Converter(tipoMoedaAConverter, valorEmRealParaConverter);

            Console.WriteLine($@"{valorEmRealParaConverter.ToString("C",  conversaoMoeda.BuscarCultureMoeda(EMoeda.Real))} convertido para {tipoMoedaAConverter.ToString()} é: ");
            Console.WriteLine($@"{valorConvertido.ToString("C", conversaoMoeda.BuscarCultureMoeda(tipoMoedaAConverter))}");
        }

        public static EMoeda EscolherMoedaConversao()
        {
            Console.WriteLine("Escolha para qual moeda deseja fazer a conversão:");
            Console.WriteLine("1- Dolar: moeda norte americana");
            Console.WriteLine("2- Euro: moeda europeia");
            Console.WriteLine("3- Iene: moeda japonesa");
            Console.WriteLine("4- Libra esterlina: moeda do Reino Unido");

            int opcao = int.Parse(Console.ReadLine());
            return (EMoeda)opcao;
        }

        public static decimal LerQuantidadeConverter()
        {
            Console.Clear();
            Console.WriteLine("Informe o valor em real (BLR) que deseja converter:");
            return decimal.Parse(Console.ReadLine());
        }
    }
}
