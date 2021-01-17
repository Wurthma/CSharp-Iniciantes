using DroneExploracao.Enums;

namespace DroneExploracao
{
    public class Drone : DroneBase
    {
        private static readonly float AlturaMaximaPadrao = 25;

        private static readonly float AlturaMinimaPadrao = 0.5f;

        private static readonly float VelocidadeMaximaDeMovimentoPadrao = 15f;
        
        private static readonly float VelocidadeMinimaDeMovimentoPadrao = 0f;
        
        public Drone() : base(AlturaMaximaPadrao, AlturaMinimaPadrao, VelocidadeMaximaDeMovimentoPadrao, VelocidadeMinimaDeMovimentoPadrao)
        {
        }
        
        public Drone(float alturaMaximaDeVoo, float alturaMinimaDeVoo, float velocidadeMaximaDeMovimento, float velocidadeMinimaDeMovimento) 
            : base(alturaMaximaDeVoo, alturaMinimaDeVoo, velocidadeMaximaDeMovimento, velocidadeMinimaDeMovimento)
        {
        }

        public float ModificarAlturaDeVoo(EAltura alturaDirecao) => ModificarAlturaDeVoo(alturaDirecao, 0.5f);

        public ushort ModificarDirecaoDeMovimento(EDirecaoAngulo direcaoAngulo) => ModificarDirecaoDeMovimento(direcaoAngulo, 5);

        public float ModificarVelocidadeDeMovimento(EVelocidade velocidadeStatus) => ModificarVelocidadeDeMovimento(velocidadeStatus, 0.5f);
    }
}