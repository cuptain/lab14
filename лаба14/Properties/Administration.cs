using System;
using System.Text.RegularExpressions;
using Libriary;

namespace Hierarchy
{
    class Administration : Worker, ICloneable
    {
        protected string address;

        //Получение адреса
        public string GetAddress
        {
            get { return address; }
            protected set { address = value; }
        }

        //Конструктор без параметров
        public Administration() : base()
        {
            address = "";
        }

        //Конструктор с параметрами
        public Administration(string Name, string Surname, int Experience, long Salary, string Address) 
            : base (Name, Surname, Experience, Salary)
        {
            address = Address;
        }

        //Вывод администратора
        public override void Show()
        {
            Console.WriteLine(surname + " " + name + "\nСтаж: " + experience + "\nЗарплата: " + salary + " тыс. руб." + "\nРаботает в администрации по адресу: " + address + "\n");
        }

        //Ввод инженера
        public new void Input()
        {
            string[] input = null;
            string ad = "";

            string inputFI = Easy.EnterName("Введите Фамилию и Имя администратора, которого необходимо найти: ");

            Console.WriteLine("Введите стаж администратора: ");
            int exp = Easy.ReadVGran(1, 5, "Стаж инженера");

            Console.WriteLine("Введите зарплату администратора: ");
            int money = Easy.ReadVGran(50000, 200000, "Зарплата инженера");

            Regex regex = new Regex(@"(?<!\S)\b[у][л][.][ ][А-Я][а-я]+[,][ ][д][.][ ][1-9]\d*[а-я]*(?!\S)\b");
            bool ok = true;
            while (ok)
            {
                Console.Write("Введите адрес администрации, в которой работает сотрудник: ");
                ad = Console.ReadLine();
                if (regex.IsMatch(ad))
                {
                    ok = false;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода! Введите адрес в формате \"ул. *** д. **\"");
                }
            }

            input = inputFI.Split(' ');

            name = input[1];
            surname = input[0];
            experience = exp;
            salary = money;
            address = ad;
        }

        //Поверхностное копирование
        public Administration SurfaceCopying()
        {
            return (Administration)this.MemberwiseClone();
        }

        //Глубокое копирование
        public object Clone()
        {
            return new Administration(this.name, this.surname, this.experience, this.salary, this.address);
        }

        public Administration(Administration administration) : base(administration.name, administration.surname
            , administration.experience, administration.salary)
        {
            address = administration.address;
        }

        public IPerson Create(IPerson person)
        {
            return new Administration((Administration)person);
        }
        public new Person BasePerson => new Person(name, surname);

        public new static Person GetSelf => IPersonCreate.CreateElement<Administration>();

        public override string ToString()
        {
            return BasePerson.ToString();
        }
    }
}
