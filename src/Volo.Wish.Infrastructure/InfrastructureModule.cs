using Autofac;
using Volo.Wish.Core.Interfaces.Repositories;
using Volo.Wish.Infrastructure.Repositories;

namespace Volo.Wish.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WishEfRepository>().As<IWishRepository>().SingleInstance();
        }
    }
}