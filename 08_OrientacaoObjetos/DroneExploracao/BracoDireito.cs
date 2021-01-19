using DroneExploracao.Enums;

namespace DroneExploracao
{
    public class BracoDireito : Braco
    {
        public BracoDireito(DroneBase drone) : base(drone)
        {
            this.drone = drone;
        }

        private readonly DroneBase drone;

        public bool Cortar()
        {
            if(drone.AproximadoDeObjeto)
            {
                if(Cotovelo.EstadoAtual == ECotoveloEstado.Contraido && !Ocupado && EstadoAtual == EBracoEstado.EmAtividade)
                {
                    //Simular cortar algum objeto, se cotovelo contraído
                    return true;
                }
            }
            return false;
        }

        public bool Coletar()
        {
            if(drone.AproximadoDeObjeto)
            {
                if(Cotovelo.EstadoAtual == ECotoveloEstado.EmRepouso && !Ocupado && EstadoAtual == EBracoEstado.EmAtividade)
                {
                    // Simulação de objeto pego pelo braço
                    AlterarEstadoOcupado(true);
                    return true;
                }
            }
            return false;
        }
    }
}