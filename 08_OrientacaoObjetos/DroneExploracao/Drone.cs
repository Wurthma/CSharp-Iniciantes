using DroneExploracao.Enums;

namespace DroneExploracao
{
    public class Drone : DroneBase
    {
        public Drone() : base(AlturaMaximaPadrao, AlturaMinimaPadrao, VelocidadeMaximaDeMovimentoPadrao, VelocidadeMinimaDeMovimentoPadrao)
        {
            IniciarDrone();
        }
        
        public Drone(float alturaMaximaDeVoo, float alturaMinimaDeVoo, float velocidadeMaximaDeMovimento, float velocidadeMinimaDeMovimento) 
            : base(alturaMaximaDeVoo, alturaMinimaDeVoo, velocidadeMaximaDeMovimento, velocidadeMinimaDeMovimento)
        {
            IniciarDrone();
        }

        private void IniciarDrone()
        {
            BracoEsquerdo = new BracoEsquerdo(this);
            BracoDireito = new BracoDireito(this);
        }

        public BracoDireito BracoDireito { get; private set; }

        public BracoEsquerdo BracoEsquerdo { get; private set; }

        private static readonly float AlturaMaximaPadrao = 25;

        private static readonly float AlturaMinimaPadrao = 0.5f;

        private static readonly float VelocidadeMaximaDeMovimentoPadrao = 15f;
        
        private static readonly float VelocidadeMinimaDeMovimentoPadrao = 0f;

        public float ModificarAlturaDeVoo(EAltura alturaDirecao) => AproximadoDeObjeto ? this.AlturaDeVoo : ModificarAlturaDeVoo(alturaDirecao, 0.5f);

        public ushort ModificarDirecaoDeMovimento(EDirecaoAngulo direcaoAngulo) => AproximadoDeObjeto ? this.DirecaoDeMovimento : ModificarDirecaoDeMovimento(direcaoAngulo, 5);

        public float ModificarVelocidadeDeMovimento(EVelocidade velocidadeStatus) => AproximadoDeObjeto ? this.VelocidadeDeMovimento : ModificarVelocidadeDeMovimento(velocidadeStatus, 0.5f);
    }
}