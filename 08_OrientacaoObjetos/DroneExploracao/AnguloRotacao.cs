using System;
using DroneExploracao.Enums;

namespace DroneExploracao
{
    public abstract class AnguloRotacao
    {
        protected AnguloRotacao()
        {
        }

        protected static readonly ushort AnguloMaximo = 360;
        
        protected static readonly ushort AnguloMinimo = 0;

        protected virtual ushort CalcularAngulo(EDirecaoAngulo direcaoAngulo, ushort anguloAtual, ushort valorAlteracaoAngulo)
        {
            int angulo = anguloAtual;
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

        protected virtual void ValidarAngulo(ushort angulo)
        {
            if(angulo > AnguloMaximo || angulo < AnguloMinimo)
                throw new ArgumentException("Valor do ângulo deve estar entre 0 e 360.");
        }
    }
}