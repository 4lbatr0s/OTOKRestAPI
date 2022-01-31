using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Business.Concrete;
using Business.Abstract;
using DataAccess.Concrete;
using DataAccess.Abstract;
using Core.Utilities.Helpers;
using Core.Utilities.Interceptors;
using DataAccess.Concrete.EntityFramework;
using Core.Utilities.Security.JWT;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModel:Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {

            containerBuilder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            containerBuilder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

            containerBuilder.RegisterType<ComponentManager>().As<IComponentService>().SingleInstance();
            containerBuilder.RegisterType<EfComponentDal>().As<IComponentDal>().SingleInstance();

            containerBuilder.RegisterType<ComponentImageManager>().As<IComponentImageService>().SingleInstance();
            containerBuilder.RegisterType<EfComponentDal>().As<IComponentDal>().SingleInstance();

            containerBuilder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            containerBuilder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            containerBuilder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            containerBuilder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            containerBuilder.RegisterType<FileHelper>().As<IFileHelper>().SingleInstance();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly(); //from the executed(current program)
            containerBuilder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()  //find the implemented interfaces which are above (IComponent etc...)
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
