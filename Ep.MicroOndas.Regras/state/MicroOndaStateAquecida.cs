namespace Ep.MicroOndas.Regras.state
{
    public class MicroOndaStateAquecida : AbstractMicroOndaState
    {
        private static MicroOndaStateAquecida instancia;
        public override string Status => "Aquecida";
        protected MicroOndaStateAquecida() { }
        public static MicroOndaStateAquecida Instancia()
        {
            if (instancia == null)
                instancia = new MicroOndaStateAquecida();

            return instancia;
        }

    }
}
