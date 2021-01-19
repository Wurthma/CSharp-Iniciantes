using System;
using DroneExploracao.Enums;

namespace DroneExploracao
{
    public class Pulso : AnguloRotacao
    {
        public Pulso()
        {
            AnguloRotacao = 0;
        }

        public ushort AnguloRotacao { get; set; }

        public virtual ushort ModificarAnguloDeRotacao(EDirecaoAngulo direcaoAngulo, ushort angulo)
        {
            ValidarAngulo(angulo);
            AnguloRotacao = CalcularAngulo(direcaoAngulo, AnguloRotacao, angulo);
            return AnguloRotacao;
        }

        public virtual ushort ModificarAnguloDeRotacao(ushort angulo)
        {
            ValidarAngulo(angulo);
            AnguloRotacao = angulo;
            return AnguloRotacao;
        }

        public virtual ushort ModificarAnguloDeRotacao(EDirecaoAngulo direcaoAngulo) => ModificarAnguloDeRotacao(direcaoAngulo, 5);
    }
}