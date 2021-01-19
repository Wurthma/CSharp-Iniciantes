using DroneExploracao.Enums;

namespace DroneExploracao
{
    public class BracoEsquerdo : Braco
    {
        public BracoEsquerdo(DroneBase drone) : base(drone)
        {
            this.drone = drone;
        }

        private readonly DroneBase drone;

        public bool Bater()
        {
            if(drone.AproximadoDeObjeto)
            {
                if(Cotovelo.EstadoAtual == ECotoveloEstado.Contraido && !Ocupado && EstadoAtual == EBracoEstado.EmAtividade)
                {
                    //Simular batida em algum objeto, se cotovelo contraído
                    return true;
                }
            }
            return false;
        }
    }
}