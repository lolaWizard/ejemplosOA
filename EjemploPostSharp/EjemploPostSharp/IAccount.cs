using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPostSharp
{
    public interface IAccount
    {
        void Add(int amount);

        void Sustract(int amount);

        void ShowBalance();
    }
}
