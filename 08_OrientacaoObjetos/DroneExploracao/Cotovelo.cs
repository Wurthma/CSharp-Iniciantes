using System;
using DroneExploracao.Enums;

namespace DroneExploracao
{
    public class Cotovelo
    {
        public Cotovelo()
        {
            EstadoAtual = ECotoveloEstado.EmRepouso;
        }

        public ECotoveloEstado EstadoAtual { get; private set; }

        public virtual void MudarEstadoCotovelo()
        {
            if(EstadoAtual == ECotoveloEstado.Contraido)
                EstadoAtual = ECotoveloEstado.EmRepouso;
            else
                EstadoAtual = ECotoveloEstado.Contraido;
        }
    }
}