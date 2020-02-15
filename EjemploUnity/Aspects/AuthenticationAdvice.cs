using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace EjemploUnity.Aspects
{
    public class AuthenticationAdvice : IInterceptionBehavior
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            if (AuthToken.Authenticated)
            {
                return getNext()(input, getNext);
            }
            else
            {
                WriteMessage("Intento de acceso no autorizado a: '{0}'", input.MethodBase);
                return input.CreateMethodReturn(null);
            }   
        }

        private void WriteMessage(string message, object argument = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
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
