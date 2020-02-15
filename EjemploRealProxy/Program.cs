using EjemploRealProxy.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploRealProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var myAccount = new Account(300);

            var loggingAdvice = new LoggingAdvice<Account>(myAccount);
            Account accountWithLogging = loggingAdvice.GetTransparentProxy() as Account;

            var authAdvice = new AuthenticationAdvice<Account>(accountWithLogging);
            Account accountWithLoggingAndAuth = authAdvice.GetTransparentProxy() as Account;

            AuthToken.Authenticated = true;
            //AuthToken.Authenticated = false;

            accountWithLoggingAndAuth.ShowBalance();
            accountWithLoggingAndAuth.Add(50);
            accountWithLoggingAndAuth.Sustract(100);
            accountWithLoggingAndAuth.ShowBalance();

            Console.ReadKey();

        }
    }
}
