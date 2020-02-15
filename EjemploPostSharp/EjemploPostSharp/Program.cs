using EjemploPostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPostSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new Account(300);

            account.ShowBalance();
            account.Add(50);
            account.Sustract(100);
            account.ShowBalance();

            Console.ReadKey();
        }
    }
}
