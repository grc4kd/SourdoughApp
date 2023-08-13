using Autofac;
using Microsoft.Extensions.Logging;
using webapi.Services;

namespace api
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new ValuesService(c.Resolve<ILogger<ValuesService>>()))
                .InstancePerLifetimeScope();
        }
    }
}