using System;
using Hierarchy;
using Libriary;

namespace лаба14
{
    class Program
    {

        public static MyNewCollection colFirst = new MyNewCollection("Первая");
        public static Journal jColFirst = new Journal(colFirst.CollectionName);
        public static MyNewCollection colSecond = new MyNewCollection("Вторая");
        public static Journal jColSecond = new Journal(colSecond.CollectionName);

        public static void Action(ref int k)
        {
            string[] menu = { "Добавить элемент в коллекцию", "Удалить элемент из коллекции", "Присвоить новое значение элементу", "Назад" };
            while (true)
            {
                var sw = Use.Menu("Выберите действие:", menu);
                switch (sw)
                {
                    case 0:
                        colFirst.AddDefault();
                        colSecond.AddDefault();
                        Easy.Continue();
                        break;
                    case 1:
                        colFirst.Remove(1);
                        colSecond.Remove(1);
                        if (colFirst.Count == 0 || colSecond.Count == 0)
                        {
                            k = 3;
                            Easy.Continue();
                            return;
                        }
                        else
                            Easy.Continue();
                        break;
                    case 2:
                        Console.WriteLine("Очереди до иземенений: ");
                        colFirst.Show();
                        colSecond.Show();
                        colFirst[1] = Worker.GetSelf;
                        colSecond[1] = Engineer.GetSelf;
                        Console.WriteLine("Очереди после изменений: ");
                        colFirst.Show();
                        colSecond.Show();
                        Easy.Continue();
                        break;
                    case 3:
                        return;
                }
            }

        }

        static void Main(string[] args)
        {
            string[] menu = {"Пересоздать коллекции", "Показать коллекции", "Показать журнал", "Действия над коллекциями", "Выход"};
            int k = 0;

            colFirst.CollectionCountChanged += new CollectionHandler(jColFirst.CollectionCountChanged);
            colFirst.CollectionReferenceChanged += new CollectionHandler(jColFirst.CollectionReferenceChanged);
            colSecond.CollectionCountChanged += new CollectionHandler(jColSecond.CollectionCountChanged);
            colSecond.CollectionReferenceChanged += new CollectionHandler(jColSecond.CollectionReferenceChanged);

            colFirst.Filling();
            colSecond.Filling();

            while (true)
            {
                var sw = Use.Menu(k, "Выберите действие:", menu);
                switch (sw)
                {
                    case 1:
                        colFirst.Filling();
                        colSecond.Filling();
                        Easy.Continue();
                        k = 0;
                        break;
                    case 2:
                        colFirst.Show();
                        colSecond.Show();
                        Easy.Continue();
                        break;
                    case 3:
                        Console.WriteLine(jColFirst.ToString());
                        Console.WriteLine(jColSecond.ToString());
                        Easy.Continue();
                        break;
                    case 4:
                        Action(ref k);
                        break;
                    case 5: return;
                }
            }
        }
    }
}
