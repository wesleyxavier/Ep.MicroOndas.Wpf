using Ep.MicroOndas.Dominio.entidades;
using Ep.MicroOndas.Regras.regra.interfaces;
using Ep.MicroOndas.Servicos.interfaces;
using System;

namespace Ep.MicroOndas.Servicos.objetos
{
    public class MicroOndasServico : IMicroOndasServico
    {
        private readonly IMicroOndasRegra _microOndasRegra;
        public MicroOndasServico(IMicroOndasRegra microOndasRegra)
        {
            _microOndasRegra = microOndasRegra;
        }

        public MicroOndasEntity ConfiguracaoInicialMicroOndas()
        {
            var microOndas = MicroOndasEntity.InstanciaInicio;
            _microOndasRegra.ConfigureMicroOndas(microOndas);
            _microOndasRegra.StatusInicial();
            return microOndas;
        }

        public void Inicio(MicroOndasEntity microOndas)
        {
            _microOndasRegra.ConfigureMicroOndas(microOndas);
            _microOndasRegra.Iniciar();
            _microOndasRegra.Ligar();
        }
    }
}
