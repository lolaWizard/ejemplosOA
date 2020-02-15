using System;

namespace EjemploUnity
{
    public class Account : IAccount
    {
        private int _amount;

        public Account(int amount)
        {
            _amount = amount;
        }

        public void Add(int amount)
        {
            _amount += amount;
            Console.WriteLine("Saldo tras ingreso:" + _amount);
        }

        public void Sustract(int amount)
        {
            _amount -= amount;
            Console.WriteLine("Saldo tras retirada:" + _amount);
        }

        public void ShowBalance()
        {
            Console.WriteLine("Saldo actual:" + _amount);
        }
    }
}
