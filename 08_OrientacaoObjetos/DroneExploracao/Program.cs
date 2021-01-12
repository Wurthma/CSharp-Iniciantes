using System;

namespace DroneExploracao
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Em construção...
        }

        private static void AtualizarMenuDrone(Drone drone)
        {
            Console.Clear();
            AtualizarMenuVoo(drone);
        }

        private static void AtualizarMenuVoo(Drone drone)
        {
            Console.WriteLine($"Altura de vôo atual: {drone.AlturaDeVoo}");
            Console.WriteLine($"A- Para aumentar progressivamente a altura.");
            Console.WriteLine($"D- Para diminuir progressivamente a altura.");
            Console.WriteLine($"1- Para especificar altura do vôo.");
            Console.WriteLine();
        }
    }
}
