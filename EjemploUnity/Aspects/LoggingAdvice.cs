using System;
using System.Collections.Generic;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace EjemploUnity.Aspects
{
    public class LoggingAdvice : IInterceptionBehavior
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            WriteInLog("Log -> Se va a ejecutar: '{0}'", input.MethodBase);

            var result = getNext()(input, getNext);

            WriteInLog("Log -> Se ha ejecutado: '{0}' ", input.MethodBase);

            return result;
        }

        private void WriteInLog(string message, object argument = null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message, argument);
            Console.ResetColor();
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute { get { return true; } }


    }
}
