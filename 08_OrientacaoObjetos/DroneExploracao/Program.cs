using System;

namespace DroneExploracao
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var drone = new Drone();
            bool continuarNoMenu;

            do
            {
                continuarNoMenu = AtualizarMenuDrone(drone);
            }
            while(continuarNoMenu);
        }

        private static bool AtualizarMenuDrone(Drone drone)
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"Altura de vôo atual: {drone.AlturaDeVoo}");
            Console.WriteLine("W- Para aumentar progressivamente a altura.");
            Console.WriteLine("S- Para diminuir progressivamente a altura.");
            Console.WriteLine("1- Para especificar altura do vôo.");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"Ângulo de direção de vôo atual: {drone.DirecaoDeMovimento}");
            Console.WriteLine("D- Aumentar a direção do ângulo progressivamente.");
            Console.WriteLine("A- Diminuir a direção do ângulo progressivamente.");
            Console.WriteLine("2- Para especificar ângulo de direção de vôo.");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Informe qualquer outro valor para sair.");
            Console.WriteLine();

            var readKey = Console.ReadKey();
            string opcao = readKey.KeyChar.ToString().ToUpper();

            switch(opcao)
            {
                case "W":
                    drone.ModificarAlturaDeVoo(EAltura.Aumentar);
                    break;
                case "S":
                    drone.ModificarAlturaDeVoo(EAltura.Diminuir);
                    break;
                case "1":
                    Console.Clear();
                    Console.WriteLine("Informe a altura: ");
                    float valorAltura = Convert.ToSingle(Console.ReadLine());
                    drone.ModificarAlturaDeVoo(valorAltura);
                    break;
                case "D":
                    drone.ModificarDirecaoDeMovimento(EDirecaoAngulo.Positivo);
                    break;
                case "A":
                    drone.ModificarDirecaoDeMovimento(EDirecaoAngulo.Negativo);
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Informe o ângulo da direção: ");
                    ushort valorAnguloDirecao = Convert.ToUInt16(Console.ReadLine());
                    drone.ModificarDirecaoDeMovimento(valorAnguloDirecao);
                    break;
                default:
                    return false;
            }
            return true;
        }
    }
}
