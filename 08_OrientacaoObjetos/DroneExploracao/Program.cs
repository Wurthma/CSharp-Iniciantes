using System;
using DroneExploracao.Enums;

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

        private static string MsgFerramentaIndisponivelParaUso { get => "Não é possível usar essa ferramenta no momento. Drone deve estar aproximado, braço deve estar em atividade e desocupado."; }

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
            Console.WriteLine($"Velocidade de movimento atual: {drone.VelocidadeDeMovimento}");
            Console.WriteLine("E- Aumentar velocidade de movimento progressivamente.");
            Console.WriteLine("Q- Diminuir velocidade de movimento progressivamente.");
            Console.WriteLine("3- Para especificar a velocidade de movimento.");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"Aproximado de objeto: {(drone.AproximadoDeObjeto ? "Sim" : "Não")}");
            Console.WriteLine("Z- Aproximar de objeto.");
            Console.WriteLine("X- Distanciar de objeto.");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("L- Acessar braço esquerdo.");
            Console.WriteLine("R- Acessar braço direito.");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Informe qualquer outro valor para sair.");
            Console.WriteLine();

            var readKey = Console.ReadKey();
            string opcao = readKey.KeyChar.ToString().ToUpper();

            return LerOpcaoDoMenu(drone, opcao);
        }

        private static bool LerOpcaoDoMenu(Drone drone, string opcao)
        {
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
                case "E":
                    drone.ModificarVelocidadeDeMovimento(EVelocidade.Aumentar);
                    break;
                case "Q":
                    drone.ModificarVelocidadeDeMovimento(EVelocidade.Diminuir);
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Informe velocidade de movimento: ");
                    float valorVelocidade = Convert.ToSingle(Console.ReadLine());
                    drone.ModificarVelocidadeDeMovimento(valorVelocidade);
                    break;
                case "Z":
                    AproximarDroneDeObjetoMenu(drone);    
                    break;
                case "X":
                    drone.DistanciarDeObjeto();
                    break;
                case "L":
                    AtualizarMenuBraco(drone, EBracoLado.Esquerdo);
                    break;
                case "R":
                    AtualizarMenuBraco(drone, EBracoLado.Direito);
                    break;
                default:
                    return false;
            }
            return true;
        }

        private static void AproximarDroneDeObjetoMenu(Drone drone)
        {
            if(drone.AproximarDeObjeto())
            {
                Console.Clear();
                Console.WriteLine("Aproximação realizada com sucesso!");
                Console.WriteLine("Pressione qualquer tecla para concluir...");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Não é possível fazer a aproximação do objeto.");
                Console.WriteLine("Verique se o drone está parado antes de realizar a aproximação.");
                Console.WriteLine("Pressione qualquer tecla para voltar...");
                Console.ReadKey();
            }
        }

        private static void AtualizarMenuBraco(Drone drone, EBracoLado bracoLado)
        {
            string opcaoMenuBraco;
            bool continuarNoMenuBraco = true;

            Braco braco = drone.BracoEsquerdo;
            if(bracoLado == EBracoLado.Direito)
                braco = drone.BracoDireito;
            
            while(continuarNoMenuBraco)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine($"### Braço {bracoLado} ###");
                Console.WriteLine($"Estado atual do braço {bracoLado}: {braco.EstadoAtual}");
                Console.WriteLine($"Braço {bracoLado} ocupado: {(braco.Ocupado ? "Sim" : "Não")}");
                Console.WriteLine($"Estado atual do cotovelo {bracoLado}: {braco.Cotovelo.EstadoAtual}");
                Console.WriteLine($"Ângulo atual do pulso {bracoLado}: {braco.Pulso.AnguloRotacao}");
                Console.WriteLine($"R- Colocar braço {bracoLado} em atividade.");
                Console.WriteLine($"T- Colocar braço {bracoLado} em repouso.");
                Console.WriteLine($"Y- Contrair ou Descontrair cotovelo {bracoLado}.");
                Console.WriteLine($"D- Aumentar a rotação do ângulo do pulso {bracoLado} progressivamente.");
                Console.WriteLine($"A- Diminuir a rotação do ângulo do pulso {bracoLado} progressivamente.");
                Console.WriteLine($"4- Especificar a rotação do ângulo do pulso {bracoLado}.");
                Console.WriteLine($"F- Ferramenta Pegar do braço {bracoLado}.");
                Console.WriteLine($"G- Armazenar do braço {bracoLado}.");
                if(bracoLado == EBracoLado.Esquerdo)
                {
                    Console.WriteLine($"B- Ferramenta Bater.");
                }
                else
                {
                    Console.WriteLine($"X- Ferramenta Cortar.");
                    Console.WriteLine($"C- Ferramenta Coletar.");
                }
                Console.WriteLine("V- Voltar para menu principal.");
                Console.WriteLine("-----------------------------------------------------------------");

                var readKeyMenuBraco = Console.ReadKey();
                opcaoMenuBraco = readKeyMenuBraco.KeyChar.ToString().ToUpper();

                continuarNoMenuBraco = LerOpcaoDoMenuBraco(braco, opcaoMenuBraco, bracoLado);
            }
            
        }

        private static bool LerOpcaoDoMenuBraco(Braco braco, string opcaoMenuBraco, EBracoLado bracoLado)
        {
            switch(opcaoMenuBraco)
            {
                case "R":
                    AlterarEstadoBraco(braco, EBracoEstado.EmAtividade);
                    break;
                case "T":
                    AlterarEstadoBraco(braco, EBracoEstado.EmRepouso);
                    break;
                case "Y":
                    braco.Cotovelo.MudarEstadoCotovelo();
                    break;
                case "D":
                    braco.Pulso.ModificarAnguloDeRotacao(EDirecaoAngulo.Positivo);
                    break;
                case "A":
                    braco.Pulso.ModificarAnguloDeRotacao(EDirecaoAngulo.Negativo);
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Informe o ângulo: ");
                    ushort valorAngulo = Convert.ToUInt16(Console.ReadLine());
                    braco.Pulso.ModificarAnguloDeRotacao(valorAngulo);
                    break;
                case "F":
                    if(!braco.Pegar())
                    {
                        Console.Clear();
                        Console.WriteLine($"{MsgFerramentaIndisponivelParaUso} E cotovelo deve estar contraído.");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                    }
                    break;
                case "G":
                    if(!braco.ArmazenarObjeto())
                    {
                        Console.Clear();
                        Console.WriteLine($"{MsgFerramentaIndisponivelParaUso} E cotovelo deve estar em repouso.");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                    }
                    break;
                case "B":
                    if(bracoLado == EBracoLado.Esquerdo)
                    {
                        if(!((BracoEsquerdo)braco).Bater())
                        {
                            Console.Clear();
                            Console.WriteLine($"{MsgFerramentaIndisponivelParaUso} E cotovelo deve estar contraído.");
                            Console.WriteLine("Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                        }
                    }
                    break;
                case "X":
                    if(bracoLado == EBracoLado.Direito)
                    {
                        if(!((BracoDireito)braco).Cortar())
                        {
                            Console.Clear();
                            Console.WriteLine($"{MsgFerramentaIndisponivelParaUso} E cotovelo deve estar contraído.");
                            Console.WriteLine("Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                        }
                    }
                    break;
                case "C":
                    if(bracoLado == EBracoLado.Direito)
                    {
                        if(!((BracoDireito)braco).Coletar())
                        {
                            Console.Clear();
                            Console.WriteLine($"{MsgFerramentaIndisponivelParaUso} E cotovelo deve estar em repouso.");
                            Console.WriteLine("Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                        }
                    }
                    break;
                case "V":
                    return false;
                default:
                    return true;
            }
            return true;
        }

        private static void AlterarEstadoBraco(Braco braco, EBracoEstado bracoEstado)
        {
            bool estadoAlterado = braco.AlterarEstado(bracoEstado);
            if(!estadoAlterado)
            {
                Console.Clear();
                Console.WriteLine($"Não é possível alterar o estado do braço para {bracoEstado} no momento.");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
