using Autofac;
using Volo.Wish.Core.UseCases.CreateWish;
using Volo.Wish.Core.UseCases.GetWishes;

namespace Volo.Wish.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GetWishesUseCase>().As<IGetWishesUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<CreateWishUseCase>().As<ICreateWishUseCase>().InstancePerLifetimeScope();
        }
    }
}