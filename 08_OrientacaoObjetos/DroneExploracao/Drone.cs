namespace DroneExploracao
{
    public class Drone : DroneBase
    {
        private static readonly float AlturaMaximaPadrao = 25;
        private static readonly float AlturaMinimaPadrao = 0.5f;
        
        public Drone() : base(AlturaMaximaPadrao, AlturaMinimaPadrao)
        {
        }
        
        public Drone(float alturaMaximaDeVoo, float alturaMinimaDeVoo) : base(alturaMaximaDeVoo, alturaMinimaDeVoo)
        {
        }

        public float ModificarAlturaDeVoo(EAltura alturaDirecao) => ModificarAlturaDeVoo(alturaDirecao, 0.5f);

        public ushort ModificarDirecaoDeMovimento(EDirecaoAngulo direcaoAngulo) => ModificarDirecaoDeMovimento(direcaoAngulo, 5);
    }
}