namespace Ep.MicroOndas.Regras.state
{
    public class MicroOndaStateDesligado : AbstractMicroOndaState
    {
        private static MicroOndaStateDesligado instancia;
        public override string Status => "Desligado";
        protected MicroOndaStateDesligado() { }

        public static MicroOndaStateDesligado Instancia()
        {
            if (instancia == null)
                instancia = new MicroOndaStateDesligado();

            return instancia;
        }
    }
}
