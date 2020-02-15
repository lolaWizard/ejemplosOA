using EjemploPostSharp.Aspects;
using System;

namespace EjemploPostSharp
{
    public class Account : IAccount
    {
        private int _amount;

        public Account(int amount)
        {
            _amount = amount;
        }

        [LoggingAdvice]
        public void Add(int amount)
        {
            _amount += amount;
            Console.WriteLine("Saldo tras ingreso:" + _amount);
        }

        [LoggingAdvice]
        public void Sustract(int amount)
        {
            _amount -= amount;
            Console.WriteLine("Saldo tras retirada:" + _amount);
        }

        [LoggingAdvice]
        public void ShowBalance()
        {
            Console.WriteLine("Saldo actual:" + _amount);
        }
    }
}
