using System;
using System.Collections.Generic;

namespace Datas
{
    internal class DataConfiguracao
    {
        public DataConfiguracao()
        {
            // Iniciamos no construtor o formato com o padrão do sistema.
            Formato = 1;
        }
        
        private byte Formato { get; set; }

        private List<DateTime> ListaDatasImportanteTI 
        { 
            //Propriedade de apenas leitura para armazenar as datas que serão exibidas. Em um sistema real poderiamos buscar essas datas de um banco de dados, ou arquivo, por exemplo.
            get => new List<DateTime>() {
                new DateTime(1946, 8, 15),
                new DateTime(1969, 4, 17),
                new DateTime(1912, 6, 23)
            };
        }
        
        public void SolicitarFormatoData()
        {
            DateTime dataAgora = DateTime.Now;
            Console.Clear();
            Console.WriteLine("Informe o formato de data que deseja usar:");
            Console.WriteLine($"1- Utilizar minha configuração de sistema: {dataAgora.ToString()}");
            Console.WriteLine($"2- Formato simples: {string.Format("{0:dd-MM-yy}", dataAgora)}");
            Console.WriteLine($"3- Formato longo {dataAgora.ToLongDateString()}");
            Console.WriteLine($"4- Formato longo personalizado {string.Format("{0:dd-MM-yyyy hh:mm:ss}", dataAgora)}");
            Console.WriteLine($"5- Formato RFC1123 pattern {string.Format("{0:r}", dataAgora)}");

            // string formats para datas: https://docs.microsoft.com/pt-br/dotnet/standard/base-types/standard-date-and-time-format-strings
            
            var opcao = byte.Parse(Console.ReadLine());
            switch(opcao)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    Formato = opcao; break;
                default: 
                    Console.WriteLine("Opção invalida. Pressione qualquer tecla para voltar ao menu de formato de data.");
                    Console.ReadKey();
                    SolicitarFormatoData();
                    break;
            }
        }

        public void ExibirMenuDataTecnologia()
        {
            Console.Clear();
            Console.WriteLine("Selecione a data especial que deseja consultar:");
            Console.WriteLine("1- ENIAC");
            Console.WriteLine("2- RFC1");
            Console.WriteLine("3- Alan Turing");
            Console.WriteLine("Qualquer outro valor para sair.");

            var opcao = byte.Parse(Console.ReadLine());

            // Se preferir, troque essa estrutura condicional pelo switch case
            if(opcao == 1 || opcao == 2 || opcao == 3)
                ExibirDetalhesData(opcao);
            else
                return;
        }

        private void ExibirDetalhesData(byte opcaoDataTecnologia)
        {
            Console.Clear();
            ExibirCabecalhoDataFormatada(opcaoDataTecnologia);

            switch(opcaoDataTecnologia)
            {
                case 1: 
                    Console.WriteLine();
                    Console.WriteLine(@"No dia 15 de agosto de 1946 os norte-americanos John Eckert e John Mauchly apresentaram o ENIAC, o primeiro equipamento eletrônico chamado de computador no mundo.");
                    break;
                case 2: 
                    Console.WriteLine();
                    Console.WriteLine(@"Em 17 de abril de 1969 foi feita a publicação da RFC1, por esse motivo considera-se esse o dia da internet até hoje.");
                    break;
                case 3: 
                    Console.WriteLine();
                    Console.WriteLine(@"Nascimento de Alan Turing, matemático e criptoanalista britânico que é considerado o ""pai da informática"" por ter sido essencial na criação de máquinas que, mais tarde, dariam origem aos PCs que utilizamos hoje para trabalhar, estudar e realizar nossas atividades diárias. Sua genialidade e influência fundamental na história da humanidade, entretanto, foram ceifadas pelo preconceito de uma época que, felizmente, já ficou para trás.");
                    break;
            }

            Console.ReadKey();
            ExibirMenuDataTecnologia(); //retornar ao menu
        }

        private void ExibirCabecalhoDataFormatada(byte opcaoDataTecnologia)
        {
            // pegar na lista de datas, a data escolhida pelo usuário:
            DateTime dataEscolhida = ListaDatasImportanteTI[opcaoDataTecnologia-1];
            string dataFormatada = FormatarData(dataEscolhida);

            Console.WriteLine(dataFormatada);
        }

        private string FormatarData(DateTime data)
        {
            string dataFormatada;
            switch(Formato)
            {
                case 1: dataFormatada = data.ToString(); break;
                case 2: dataFormatada = string.Format("{0:dd-MM-yy}", data); break;
                case 3: dataFormatada = data.ToLongDateString(); break;
                case 4: dataFormatada = string.Format("{0:dd-MM-yyyy hh:mm:ss}", data); break;
                case 5: dataFormatada = string.Format("{0:r}", data); break;
                default: dataFormatada = data.ToString(); break;
            }
            return dataFormatada;
        }
    }
}