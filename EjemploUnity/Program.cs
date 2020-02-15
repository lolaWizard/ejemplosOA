using EjemploUnity.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Interception;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Resolution;

namespace EjemploUnity
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.AddNewExtension<Interception>();
            container.RegisterType<IAccount, Account>(new Interceptor<InterfaceInterceptor>()
                                                    , new InterceptionBehavior<AuthenticationAdvice>()
                                                    , new InterceptionBehavior<LoggingAdvice>());

            var accountWithLoggingAndAuth = container.Resolve<IAccount>(new ResolverOverride[]
                                                                 {
                                                                        new ParameterOverride("amount", 300)
                                                                 });

            AuthToken.Authenticated = true;

            accountWithLoggingAndAuth.ShowBalance();
            accountWithLoggingAndAuth.Add(50);
            accountWithLoggingAndAuth.Sustract(100);
            accountWithLoggingAndAuth.ShowBalance();

            Console.ReadKey();
        }
    }
}
