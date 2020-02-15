using System;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

namespace EjemploRealProxy.Aspects
{
    public class AuthenticationAdvice<T> : RealProxy
    {
        private readonly T _decorated;

        public AuthenticationAdvice(T decorated):base(typeof(T))
        {
            _decorated = decorated;   
        }

        private void WriteMessage(string message, object argument = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message, argument);
            Console.ResetColor();
        }

        public override IMessage Invoke(IMessage message)
        {
            var methodCall = message as IMethodCallMessage;
            var methodInfo = methodCall.MethodBase as MethodInfo;
            var methodName = methodCall.MethodName;

            if (AuthToken.Authenticated)
            {
                var result = methodInfo.Invoke(_decorated, methodCall.InArgs);
                var returnMessage = new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
                return returnMessage;
            }
            else
            {
                WriteMessage("Intento de acceso no autorizado a: '{0}'", methodName);
                return new ReturnMessage(null, null, 0, methodCall.LogicalCallContext, methodCall);
            }



        }
    }
}
