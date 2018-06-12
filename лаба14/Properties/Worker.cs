using System;
using Libriary;

namespace Hierarchy
{
    //Производный от Person
    internal class Worker : Person
    {
        protected int experience;
        protected long salary;

        //Получение стажа
        public int GetExperience
        {
            get { return experience; }
            protected set { experience = value; }
        }

        //Получение зарплаты
        public long GetSalary
        {
            get { return salary; }
            protected set { salary = value; }
        }

        #region Конструкторы

        //Конструктор без параметров
        public Worker() : base()
        {
            experience = 0;
            salary = 0;
        }

        //Конструктор с параметрами
        public Worker(string Name, string Surname, int Experience, long Salary) : base(Name, Surname)
        {
            experience = Experience;
            salary = Salary;
        }

        //Создание от персоны
        public IPerson Create(IPerson person)
        {
            return new Worker((Worker)person);
        }

        //База
        public new Person BasePerson => new Person(name, surname);

        //Создание рабочего
        public new static Person GetSelf => IPersonCreate.CreateElement<Worker>();

        //Конструктор от рабочего
        public Worker(Worker worker) : base(worker.BasePerson)
        {
            experience = worker.experience;
            salary = worker.salary;
        }

        #endregion

        #region Ввод-Вывод

        //Вывод рабочего
        public override void Show()
        {
            Console.WriteLine(surname + " " + name + "\nСтаж: " + experience + "\nЗарплата: " + salary + " тыс. руб.\n");
        }

        //Ввод рабочего
        public new void Input()
        {
            string[] input = null;

            string inputFI = Easy.EnterName("Введите Фамилию и Имя рабочего, которого необходимо найти: ");

            Console.WriteLine("Введите стаж рабочего: ");
            int exp = Easy.ReadVGran(1, 50, "Стаж рабочего");

            Console.WriteLine("Введите зарплату рабочего: ");
            int money = Easy.ReadVGran(10000, 200000, "Зарплата рабочего");

            input = inputFI.Split(' ');

            name = input[1];
            surname = input[0];
            experience = exp;
            salary = money;
        }

        #endregion

        #region Override

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return BasePerson.ToString();
        }

        #endregion
    }
}
