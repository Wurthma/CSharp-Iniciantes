using System.Collections.Generic;
using System.Globalization;

namespace ConversaoMoedas
{
    public class ConversaoMoeda
    {
        /// <summary>
        /// Propriedade utilizada para identificar a moeda que deve ser convertida.
        /// </summary>
        /// <value></value>
        public EMoeda MoedaTipo { get; private set; }

        /// <summary>
        /// Contém a lista com os valores de cada moeda em real (BLR)
        /// </summary>
        /// <value></value>
        private Dictionary<EMoeda, decimal> ValoresMoedas 
        { 
            get {
                var dicionarioValoresMoedas = new Dictionary<EMoeda, decimal>();
                dicionarioValoresMoedas.Add(EMoeda.Real, 1m);
                dicionarioValoresMoedas.Add(EMoeda.Dolar, 4.50m);
                dicionarioValoresMoedas.Add(EMoeda.Euro, 6.20m);
                dicionarioValoresMoedas.Add(EMoeda.Iene, 0.052m);
                dicionarioValoresMoedas.Add(EMoeda.Libra, 6.95m);

                return dicionarioValoresMoedas;
            }
        }

        /// <summary>
        /// Contém a lista com os valores de cada moeda em real (BLR)
        /// </summary>
        /// <value></value>
        private Dictionary<EMoeda, CultureInfo> CultureMoedas 
        { 
            get {
                var dicionarioCultureMoedas = new Dictionary<EMoeda, CultureInfo>();
                
                dicionarioCultureMoedas.Add(EMoeda.Real, CultureInfo.CreateSpecificCulture("pt-BR"));
                dicionarioCultureMoedas.Add(EMoeda.Dolar, CultureInfo.CreateSpecificCulture("en-US"));
                dicionarioCultureMoedas.Add(EMoeda.Euro, CultureInfo.CreateSpecificCulture("fr-FR")); // pode ser utilizado outras cultures da europa
                dicionarioCultureMoedas.Add(EMoeda.Iene, CultureInfo.CreateSpecificCulture("jp-JP"));
                dicionarioCultureMoedas.Add(EMoeda.Libra, CultureInfo.CreateSpecificCulture("en-GB"));

                return dicionarioCultureMoedas;
            }
        }
        
        /// <summary>
        /// Construtor recebe a moeda 'originaria' que será convertida para as outras disponíveis.
        /// </summary>
        /// <param name="Moeda">Tipo da moeda 'originaria'.</param>
        public ConversaoMoeda(EMoeda Moeda)
        {
            MoedaTipo = Moeda;
        }

        /// <summary>
        /// Converte uma moeda específica para valores em real (BLR).
        /// </summary>
        /// <param name="moedaConversao">Moeda para qual deseja converter o real.</param>
        /// <returns>Retornar o valor convertido.</returns>
        public decimal Converter(EMoeda moedaConversao, decimal valorReal)
        {
            decimal valorMoedaConversao = BuscarValorMoeda(moedaConversao);
            return valorReal * valorMoedaConversao;
        }

        public CultureInfo BuscarCultureMoeda(EMoeda Moeda) => CultureMoedas.GetValueOrDefault(Moeda);

        private decimal BuscarValorMoeda(EMoeda Moeda) => ValoresMoedas.GetValueOrDefault(Moeda);
    }
}