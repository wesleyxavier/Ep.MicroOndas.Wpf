using Ep.MicroOndas.Regras.regra.objetos;

namespace Ep.MicroOndas.Regras.state
{
    public abstract class AbstractMicroOndaState
    {
        private bool SetEstado<T>(MicroOndasRegra micro, T instance)
            where T : AbstractMicroOndaState
        {
            micro.EstabelecerEstado(instance);
            return true;
        }
        public bool Ligar(MicroOndasRegra micro)
        {
            var instance = MicroOndaStateLigado.Instancia();
            return SetEstado(micro, instance);
        }
        public bool Aquecida(MicroOndasRegra micro)
        {
            var instance = MicroOndaStateAquecida.Instancia();
            return SetEstado(micro, instance);
        }

        public bool Desligar(MicroOndasRegra micro)
        {
            var instance = MicroOndaStateDesligado.Instancia();
            return SetEstado(micro, instance);
        }
        public abstract string Status { get; }
    }
}
