using System;

namespace DroneExploracao
{
    public abstract class DroneBase
    {
        protected DroneBase(float alturaMaximaDeVoo, float alturaMinimaDeVoo)
        {
            AlturaMaximaDeVoo = alturaMaximaDeVoo;
            AlturaMinimaDeVoo = alturaMinimaDeVoo;
        }

        public float AlturaDeVoo { get; private set; }

        private float AlturaMaximaDeVoo { get; set; }

        private float AlturaMinimaDeVoo { get; set; }

        public ushort DirecaoDeMovimento { get; private set; }

        private static readonly ushort AnguloMaximo = 360;
        private static readonly ushort AnguloMinimo = 0;
        
        public virtual float ModificarAlturaDeVoo(EAltura alturaDirecao, float valor)
        {
            if(alturaDirecao == EAltura.Aumentar)
                AlturaDeVoo += valor;
            else
                AlturaDeVoo -= valor;

            if(AlturaDeVoo > AlturaMaximaDeVoo)
                AlturaDeVoo = AlturaMaximaDeVoo;
            else if (AlturaDeVoo < AlturaMinimaDeVoo)
                AlturaDeVoo = AlturaMinimaDeVoo;

            return AlturaDeVoo;
        }

        public virtual float ModificarAlturaDeVoo(float valor) => ModificarAlturaDeVoo(EAltura.Aumentar, valor);

        private void ValidarAngulo(ushort angulo)
        {
            if(angulo > AnguloMaximo || angulo < AnguloMinimo)
                throw new ArgumentException("Valor do ângulo deve estar entre 0 e 360.");
        }
        
        public virtual ushort ModificarDirecaoDeMovimento(ushort angulo)
        {
            ValidarAngulo(angulo);

            DirecaoDeMovimento = angulo;

            return DirecaoDeMovimento;
        }

        public virtual ushort ModificarDirecaoDeMovimento(EDirecaoAngulo direcaoAngulo, ushort angulo)
        {
            ValidarAngulo(angulo);
            DirecaoDeMovimento = CalcularAnguloDirecaoAtual(direcaoAngulo, angulo);
            return DirecaoDeMovimento;
        }

        private ushort CalcularAnguloDirecaoAtual(EDirecaoAngulo direcaoAngulo, ushort valorAlteracaoAngulo)
        {
            int angulo = DirecaoDeMovimento;
            if(direcaoAngulo == EDirecaoAngulo.Positivo)
            {
                angulo += valorAlteracaoAngulo;

                if(angulo - AnguloMaximo > 0)
                    angulo -= AnguloMaximo;
            }
            else
            {
                angulo -= valorAlteracaoAngulo;

                if(angulo < 0)
                    angulo += AnguloMaximo;
            }

            return Convert.ToUInt16(angulo);
        }
    }
}