using System;

namespace Hierarchy
{
    //Базовый интерфейс
    public interface IPerson : IComparable
    {
        IPerson GetSelf { get; }

        IPerson Create(IPerson person);

        Person BasePerson { get; }

        void Input(); //метод ввода

        void Show(); //метод вывода

        string ToString(); //Вывод

        new int CompareTo(object other); //сравнение
    }
}
