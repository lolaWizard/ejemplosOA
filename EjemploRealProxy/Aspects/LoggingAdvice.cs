using System;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

namespace EjemploRealProxy.Aspects
{
    public class LoggingAdvice<T> : RealProxy
    {
        private readonly T _decorated;

        public LoggingAdvice(T decorated):base(typeof(T))
        {
            _decorated = decorated;   
        }

        private void WriteInLog(string message, object argument =  null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message, argument);
            Console.ResetColor();
        }

        public override IMessage Invoke(IMessage message)
        {
            var methodCall = message as IMethodCallMessage;
            var methodInfo = methodCall.MethodBase as MethodInfo;
            var methodName = methodCall.MethodName;

            WriteInLog("Log -> Se va a ejecutar: '{0}'", methodName);

            var result = methodInfo.Invoke(_decorated, methodCall.InArgs);

            WriteInLog("Log -> Se ha ejecutado: '{0}' ", methodName);

            var returnMessage = new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
            return returnMessage;

        }
    }
}
