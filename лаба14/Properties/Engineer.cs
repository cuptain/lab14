using System;

using Libriary;

namespace Hierarchy
{
    class Engineer : Worker, IComparable
    {
        protected int factory;

        //Получение завода
        public int GetFactory
        {
            get { return factory; }
            protected set { factory = value; }
        }

        //Конструктор без параметров
        public Engineer():base()
        {
            factory = 0;
        }

        //Конструктор с параметрами
        public Engineer(string Name, string Surname, int Experience, int Salary, int Factory) 
            : base (Name, Surname, Experience, Salary)
        {
            factory = Factory;
        }

        //Вывод инженера
        public override void Show()
        {
            Console.WriteLine(surname + " " + name + "\nСтаж: " + experience + "\n" +
                              "Зарплата: " + salary + " тыс. руб." + "\nРаботает в цеху № " + factory + "\n");
        }

        //Ввод инженера
        public new void Input()
        {
            string[] input = null;

            string inputFI = Easy.EnterName("Введите Фамилию и Имя инженера, которого необходимо найти: ");

            Console.WriteLine("Введите стаж инженерп: ");
            int exp = Easy.ReadVGran(1, 5, "Стаж инженера");

            Console.WriteLine("Введите зарплату инженера: ");
            int money = Easy.ReadVGran(5000, 100000, "Зарплата инженера");

            Console.WriteLine("Введите цех, в котором работает инженер: ");
            int fac = Easy.ReadVGran(1, 100, "Рабочий цех");

            input = inputFI.Split(' ');

            name = input[1];
            surname = input[0];
            experience = exp;
            salary = money;
            factory = fac;
        }

        public Engineer(Engineer engineer) : base (engineer.name, engineer.surname
            , engineer.experience, engineer.salary)
        {
            factory = engineer.factory;
        }

        public IPerson Create(IPerson person)
        {
            return new Engineer((Engineer)person);
        }

        public new Person BasePerson => new Person(name, surname);

        public new static Person GetSelf => IPersonCreate.CreateElement<Engineer>();

        public override string ToString()
        {
            return BasePerson.ToString();
        }
    }
}
