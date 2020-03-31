using Ep.MicroOndas.Dominio.entidades;
using System;

namespace Ep.MicroOndas.Servicos.interfaces
{
    public interface IMicroOndasServico
    {
        void Inicio(MicroOndasEntity microOndas);
        MicroOndasEntity ConfiguracaoInicialMicroOndas();
    }
}