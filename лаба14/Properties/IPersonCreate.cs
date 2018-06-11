using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hierarchy
{
    internal static class IPersonCreate
    {
        //Рандомное имя
        static string[] random_name = ("Василий Давид Иосиф Алексей Дмитрий Михаил Исаак Марсель Анатолий Александр Егор Валентин Никита Марк Игнат " +
                                       "Пётр Даниил Артём Андрей Кирилл Илья Валерий Станислав Георгий Григорий Сергей Максим Вадим").Split(' ');

        //Рандомная фамилия
        static string[] random_se_name = ("Панин Василюк Нуреев Мочалкин Кричалкин Штоль Коваль Пульт Штора Соль Нечаев Нескаромный Котыченко Баженов Жданов " +
                                          "Боярский Лазарев Троекуров Ашанин Соколовский Шнуров Алексеев Толкин Субботин Баранов Костин Машин Петин Путин Колончаев").Split(' ');

        //Рандомный адрес
        static string[] random_address = {"ул. Сивкова, д. 2","ул. Клюшкина, д. 45","ул. Садовая, д. 3","ул. Пореченкова, д. 56а",
                                         "ул. Докторская, д. 98о", "ул. Колбасная, д. 123","ул. Сырная, д. 7", "ул. Водная, д. 87","ул. Любимая, д. 34б",
                                         "ул. Домодедовская, д. 1","ул. Пронинская, д. 57","ул. Виноградовая, д. 77","ул. Стахановская, д. 99"};

        //Переменная для рандома
        private static readonly Random Rnd = new Random();


        //Создать массив
        public static IPerson[] CreateArray(int size)
        {
            var person = new IPerson[size];
            var i = 0;
            while (i < person.Length)
            {
                var check = Rnd.Next(1, 4);
                IPerson persona;
                if (check == 1)
                {
                    persona = new Worker(random_name[Rnd.Next(0, random_name.Length)],
                                          random_se_name[Rnd.Next(0, random_se_name.Length)],
                                          Rnd.Next(1, 50), Rnd.Next(10, 21) * 1000);
                }
                else
                {
                    if (check == 2)
                        persona = new Engineer(random_name[Rnd.Next(0, random_name.Length)],
                                                random_se_name[Rnd.Next(0, random_se_name.Length)],
                                                Rnd.Next(1, 50), Rnd.Next(10, 21) * 1000, Rnd.Next(1, 100));
                    else
                        persona = new Administration(random_name[Rnd.Next(0, random_name.Length)],
                                              random_se_name[Rnd.Next(0, random_se_name.Length)],
                                              Rnd.Next(1, 50), Rnd.Next(10, 21) * 1000, random_address[Rnd.Next(0, random_address.Length)]);
                }

                if (Contains(persona, person))
                {
                }
                else
                {
                    person[i] = persona;
                    i++;
                }
            }

            return person;
        }

        public static bool Contains(IPerson element, IPerson[] array)
        {
            foreach (var person in array)
            {
                if (person == null) return false;
                if (string.Compare(person.ToString(), element.ToString(),
                                   StringComparison.Ordinal) == 0)
                    return true;
            }

            return false;
        }

        public static IPerson CreateElement<T>()
        {
            if (typeof(T) == typeof(Administration))
                return new Administration(random_name[Rnd.Next(0, random_name.Length)],
                                              random_se_name[Rnd.Next(0, random_se_name.Length)],
                                              Rnd.Next(1, 5), Rnd.Next(50, 200) * 1000, random_address[Rnd.Next(0, random_address.Length)]);

            if (typeof(T) == typeof(Engineer))
                return new Engineer(random_name[Rnd.Next(0, random_name.Length)],
                                                random_se_name[Rnd.Next(0, random_se_name.Length)],
                                                Rnd.Next(1, 5), Rnd.Next(5, 100) * 1000, Rnd.Next(1, 100));

            return new Worker(random_name[Rnd.Next(0, random_name.Length)],
                                          random_se_name[Rnd.Next(0, random_se_name.Length)],
                                          Rnd.Next(1, 50), Rnd.Next(10, 30) * 1000);
        }

        public static void Show<T>(T element)
        {
            if (typeof(T) == typeof(Administration))
            {
                var teacher = element as Administration;
                teacher.Show();
            }
            else
            {
                if (typeof(T) == typeof(Engineer))
                {
                    var associate = element as Engineer;
                    associate.Show();
                }
                else
                {
                    var student = element as Worker;
                    student.Show();
                }
            }
        }
    }
}
