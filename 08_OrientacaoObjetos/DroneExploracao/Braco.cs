using System;
using DroneExploracao.Enums;

namespace DroneExploracao
{
    public abstract class Braco
    {
        public Braco(DroneBase drone)
        {
            Cotovelo = new Cotovelo();
            Pulso = new Pulso();
            EstadoAtual = EBracoEstado.EmRepouso;
            this.drone = drone;
        }

        private readonly DroneBase drone;

        private bool DroneEmMovimento { get => drone.VelocidadeDeMovimento > 0; }

        public EBracoEstado EstadoAtual { get; private set; }
        
        public Cotovelo Cotovelo { get; private set; }

        public Pulso Pulso { get; private set; }

        public bool Ocupado { get; private set; }

        public virtual bool AlterarEstado(EBracoEstado bracoEstado)
        {
            if(drone.AproximadoDeObjeto)
            {
                if(EstadoAtual == EBracoEstado.EmRepouso && (Ocupado || DroneEmMovimento))
                {
                    return false;
                }
                EstadoAtual = bracoEstado;
                return true;
            }
            return false;
        }

        public virtual bool Pegar()
        {
            if(drone.AproximadoDeObjeto)
            {
                if(Cotovelo.EstadoAtual == ECotoveloEstado.Contraido && !Ocupado && EstadoAtual == EBracoEstado.EmAtividade)
                {
                    // Simulação de objeto pego pelo braço
                    Ocupado = true;
                    return true;
                }
            }
            return false;
        }

        public virtual bool ArmazenarObjeto()
        {
            if(drone.AproximadoDeObjeto)
            {
                if(Cotovelo.EstadoAtual == ECotoveloEstado.Contraido && Ocupado && EstadoAtual == EBracoEstado.EmRepouso)
                {
                    return false;
                }

                //Simular armazenamento de objeto
                Ocupado = false;

                return true;
            }
            return false;
        }

        protected virtual void AlterarEstadoOcupado(bool ocupado)
        {
            Ocupado = ocupado;
        }
    }
}