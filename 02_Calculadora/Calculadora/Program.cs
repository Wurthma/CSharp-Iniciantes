using System;

namespace Calculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();            
        }

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine("1 - Somar");
            Console.WriteLine("2 - Subtrair");
            Console.WriteLine("3 - Multiplicar");
            Console.WriteLine("4 - Dividir");
            Console.WriteLine("5 - Resto da divisão");
            Console.WriteLine("6 - Potenciação");
            Console.WriteLine("0 - Sair");

            string opcao = Console.ReadLine();

            switch(opcao)
            {
                case "1":
                    Somar();
                    break;
                case "2":
                    Subtrair();                    
                    break;
                case "3":
                    Multiplicar();                    
                    break;
                case "4":
                    Dividir();                    
                    break;
                case "5":
                    EncontrarRestoDivisao();                    
                    break;
                case "6":
                    CalcularPotenciacao();                    
                    break;
                case "0":
                    break;
                default:
                    Menu();
                    break;
            }
        }

        public static void Somar()
        {
            double valor1, valor2;

            Console.WriteLine("Entre com o primeiro valor:");
            valor1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Entre com o segundo valor:");
            valor2 = double.Parse(Console.ReadLine());

            Console.WriteLine($"{valor1} + {valor2} = {valor1 + valor2}");
            Console.ReadLine();
            Menu();
        }

        public static void Subtrair()
        {
            double valor1, valor2;

            Console.WriteLine("Entre com o primeiro valor:");
            valor1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Entre com o segundo valor:");
            valor2 = double.Parse(Console.ReadLine());

            Console.WriteLine($"{valor1} - {valor2} = {valor1 - valor2}");
            Console.ReadLine();
            Menu();
        }

        public static void Multiplicar()
        {
            double valor1, valor2;

            Console.WriteLine("Entre com o primeiro valor:");
            valor1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Entre com o segundo valor:");
            valor2 = double.Parse(Console.ReadLine());

            Console.WriteLine($"{valor1} * {valor2} = {valor1 * valor2}");
            Console.ReadLine();
            Menu();
        }

        public static void Dividir()
        {
            double dividendo, divisor;

            Console.WriteLine("Informe o dividendo:");
            dividendo = double.Parse(Console.ReadLine());
            Console.WriteLine("Informe o divisor:");
            divisor = double.Parse(Console.ReadLine());

            if(divisor != 0)
                Console.WriteLine($"{dividendo} / {divisor} = {dividendo / divisor}");
            else
                Console.WriteLine("Não é possível dividir por zero.");

            Console.ReadLine();
            Menu();
        }

        // Desafios
        // 1- Crie uma nova opção na calculadora (opção número 5 do menu) que retorne o resto da divisão.
        public static void EncontrarRestoDivisao()
        {
            double dividendo, divisor;

            Console.WriteLine("Informe o dividendo:");
            dividendo = double.Parse(Console.ReadLine());
            Console.WriteLine("Informe o divisor:");
            divisor = double.Parse(Console.ReadLine());

            if(divisor != 0)
                Console.WriteLine($"Resto entre {dividendo} e {divisor} = {dividendo % divisor}");
            else
                Console.WriteLine("Não é possível dividir por zero.");

            Console.ReadLine();
            Menu();
        }

        // Desafios
        // 2- Crie uma nova opção na calculadora (opção número 6 do menu) que retorne o resultado da potenciação de uma determinada base pelo seu expoente. Exemplo **2³ = 8**.
        public static void CalcularPotenciacao()
        {
            double basePotenciacao, expoente;

            Console.WriteLine("Informe a base:");
            basePotenciacao = double.Parse(Console.ReadLine());
            Console.WriteLine("Informe o expoente:");
            expoente = double.Parse(Console.ReadLine());

            Console.WriteLine($"{basePotenciacao} elevado a {expoente} = {Math.Pow(basePotenciacao, expoente)}");

            Console.ReadLine();
            Menu();
        }
    }
}
