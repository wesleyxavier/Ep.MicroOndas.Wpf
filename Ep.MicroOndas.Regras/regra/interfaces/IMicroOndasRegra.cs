using Ep.MicroOndas.Dominio.entidades;
using System;

namespace Ep.MicroOndas.Regras.regra.interfaces
{
    public interface IMicroOndasRegra
    {
        MicroOndasEntity GetMicroOndas { get; }
        void ConfigureMicroOndas(MicroOndasEntity microOndas);
        void Iniciar();
        void Desligar();
        void Ligar();
        void StatusInicial();
    }
}