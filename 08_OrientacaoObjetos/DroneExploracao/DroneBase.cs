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
        
        public float ModificarAlturaDeVoo(EAltura altura) => ModificarAlturaDeVoo(altura, 1);
        
        public float ModificarAlturaDeVoo(EAltura altura, ushort valor)
        {
            AlturaDeVoo += (float)valor;
            if(AlturaDeVoo > AlturaMaximaDeVoo)
                AlturaDeVoo = AlturaMaximaDeVoo;
            else if (AlturaDeVoo < AlturaMinimaDeVoo)
                AlturaDeVoo = AlturaMinimaDeVoo;

            return AlturaDeVoo;
        }
    }
}