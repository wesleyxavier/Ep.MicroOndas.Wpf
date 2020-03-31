namespace Ep.MicroOndas.Regras.state
{
    public class MicroOndaStateLigado : AbstractMicroOndaState
    {
        private static MicroOndaStateLigado instancia;

        public override string Status => "Ligado";
        protected MicroOndaStateLigado() { }
        public static MicroOndaStateLigado Instancia()
        {
            if (instancia == null)
                instancia = new MicroOndaStateLigado();

            return instancia;
        }
    }
}
