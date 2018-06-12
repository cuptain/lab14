using System;
using Hierarchy;

namespace лаба14
{
    public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args); //Делегат событий

    public class CollectionHandlerEventArgs : EventArgs //Класс событий
    {
        public string CollectionName { get; private set; } //Имя коллекции

        public string TypeOfChange { get; private set; } //Тип изменения

        public Person ChangedObj { get; private set; } //Изменённый объект

        public CollectionHandlerEventArgs(string name, string changes, Person _object) //Конструктор с параметрами
        {
            CollectionName = name;
            TypeOfChange = changes;
            ChangedObj = _object;
        }

        public override string ToString() //Вывод
        {
            return "В коллекции: \"" + CollectionName + "\" произошло изменение типа: " + TypeOfChange + " с объектом: " + ChangedObj.ToString();
        }
    }

    class MyNewCollection : MyQueue<Person>
    {
        public string CollectionName { get; private set; } //Имя коллекции

        public event CollectionHandler CollectionCountChanged; //Событие изменения кол-ва элементов
        public event CollectionHandler CollectionReferenceChanged; //Собатие изменения ссылок

        public MyNewCollection(string name) : base() //Конструктор с параметром
        {
            CollectionName = name;
        }

        public void Filling() //Заполнение коллекции
        {
            var count = Capacity;
            for (int i = 0; i < count; i++)
            {
                switch (i % 3)
                {
                    case 0:
                        this.Enqueue(Worker.GetSelf);
                        break;
                    case 1:
                        this.Enqueue(Administration.GetSelf);
                        break;
                    case 2:
                        this.Enqueue(Engineer.GetSelf);
                        break;
                }
                if (CollectionCountChanged != null)
                {
                    OnCollectionCountChanged(this, new CollectionHandlerEventArgs(CollectionName, "добавление", base[i].Data));
                }
            }
        }

        public virtual void OnCollectionCountChanged(object source, CollectionHandlerEventArgs args) //Собатие изменения кол-ва элементов
        {
            if (CollectionCountChanged != null)
                CollectionCountChanged(source, args);
        }

        public virtual void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs args) //Событие изменения ссылок на элементы
        {
            if (CollectionReferenceChanged != null)
                CollectionReferenceChanged(source, args);
        }

        public new Person this[int index] //Изменение ссылки
        {
            get => base[index].Data;
            set
            {
                base[index].Data = value;
                OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs(CollectionName, "изменение ссылки", base[index].Data));
            }
        }

        public void AddDefault() //Добавить слйчайный элемент
        {
            Console.WriteLine("Текущая очередь:");
            Show();
            Console.WriteLine("\n");

            Random rnd = new Random();
            int index = rnd.Next(1, base.Capacity - 7);
            if (Add(Worker.GetSelf, index))
            {
                OnCollectionCountChanged(this, new CollectionHandlerEventArgs(CollectionName, "добавление", base[index - 1].Data));
            }
            else
            {
                Console.WriteLine("Индекс неверен!");
            }
            Console.WriteLine("\nОчередь после изменений:");
            Show();
        }

        public new void Remove(int index) //Удаление элемента
        {
            Console.WriteLine("Текущая очередь:");
            Show();
            Console.WriteLine("\n");

            MyQueue<Person> clone = Clone();

            if (base.Remove(index))
                OnCollectionCountChanged(this, new CollectionHandlerEventArgs(CollectionName, "удаление", clone[index - 1].Data));
            else
                Console.WriteLine("Индекс неверен!");

            if (Count == 0)
                Console.WriteLine("Очередь пуста");
            else
            {
                Console.WriteLine("\nОчередь после изменений:");
                Show();
            }
        }

        public void Show() //Вывод коллекции
        {
            Console.WriteLine("\nНазвание коллекции: " + CollectionName + "\n");
            foreach (QueueElement<Person> person in this)
            {
                person.Data.Show();
            }
        }
    }
}
