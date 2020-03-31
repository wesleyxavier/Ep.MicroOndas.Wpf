using Ep.MicroOndas.Dominio.entidades;
using Ep.MicroOndas.Regras.regra.interfaces;
using Ep.MicroOndas.Regras.regra.objetos;
using Ep.MicroOndas.Servicos.interfaces;
using Ep.MicroOndas.Servicos.objetos;
using Ninject;
using System.Timers;

namespace Ep.MicroOndas.Ioc
{
    public static class IocBase
    {
        public static IKernel Injecao(this IKernel container)
        {
            container.Bind(typeof(IMicroOndasRegra)).To(typeof(MicroOndasRegra)).InTransientScope();
            container.Bind(typeof(IMicroOndasServico)).To(typeof(MicroOndasServico)).InTransientScope();

            container.Bind<MicroOndasEntity>().ToSelf().InSingletonScope();
            container.Bind<Timer>().ToSelf().InSingletonScope();

            return container;
        }
    }
}
