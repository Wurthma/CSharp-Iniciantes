using System;
using DroneExploracao.Enums;

namespace DroneExploracao
{
    public abstract class DroneBase : AnguloRotacao
    {
        protected DroneBase(float alturaMaximaDeVoo, float alturaMinimaDeVoo, float velocidadeMaximaDeMovimento, float velocidadeMinimaDeMovimento)
        {
            AlturaMaximaDeVoo = alturaMaximaDeVoo;
            AlturaMinimaDeVoo = alturaMinimaDeVoo;
            VelocidadeMaximaDeMovimento = velocidadeMaximaDeMovimento;
            VelocidadeMinimaDeMovimento = velocidadeMinimaDeMovimento;
        }

        public float AlturaDeVoo { get; private set; }

        private float AlturaMaximaDeVoo { get; set; }

        private float AlturaMinimaDeVoo { get; set; }

        public ushort DirecaoDeMovimento { get; private set; }

        public float VelocidadeDeMovimento { get; private set; }

        private float VelocidadeMaximaDeMovimento { get; set; }

        private float VelocidadeMinimaDeMovimento { get; set; }

        public bool AproximadoDeObjeto { get; private set; }
        
        public virtual float ModificarAlturaDeVoo(EAltura alturaDirecao, float valor)
        {
            if(alturaDirecao == EAltura.Aumentar)
                AlturaDeVoo += valor;
            else
                AlturaDeVoo -= valor;

            AlturaDeVoo = ValidarAlturaDeVoo(AlturaDeVoo);

            return AlturaDeVoo;
        }

        public virtual float ModificarAlturaDeVoo(float valor)
        {
            AlturaDeVoo = ValidarAlturaDeVoo(valor);
            return AlturaDeVoo;
        }

        private float ValidarAlturaDeVoo(float valor)
        {
            if(valor > AlturaMaximaDeVoo)
                valor = AlturaMaximaDeVoo;
            else if (valor < AlturaMinimaDeVoo)
                valor = AlturaMinimaDeVoo;

            return valor;
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
            DirecaoDeMovimento = CalcularAngulo(direcaoAngulo, DirecaoDeMovimento, angulo);
            return DirecaoDeMovimento;
        }

        public virtual float ModificarVelocidadeDeMovimento(EVelocidade velocidadeStatus, float valor)
        {
            if(velocidadeStatus == EVelocidade.Aumentar)
                VelocidadeDeMovimento += valor;
            else
                VelocidadeDeMovimento -= valor;

            VelocidadeDeMovimento = ValidarVelocidadeDeMovimento(VelocidadeDeMovimento);

            return VelocidadeDeMovimento;
        }

        public virtual float ModificarVelocidadeDeMovimento(float valor)
        {
            VelocidadeDeMovimento = ValidarVelocidadeDeMovimento(valor);
            return VelocidadeDeMovimento;
        }

        private float ValidarVelocidadeDeMovimento(float valor)
        {
            if(valor > VelocidadeMaximaDeMovimento)
                valor = VelocidadeMaximaDeMovimento;
            else if (valor < VelocidadeMinimaDeMovimento)
                valor = VelocidadeMinimaDeMovimento;

            return valor;
        }

        public bool AproximarDeObjeto()
        {
            if(VelocidadeDeMovimento == 0)
                AproximadoDeObjeto = true;

            return AproximadoDeObjeto;
        }

        public void DistanciarDeObjeto()
        {
            AproximadoDeObjeto = false;
        }
    }
}