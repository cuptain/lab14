using System;
using System.Collections;

namespace Hierarchy
{
    public class MyQueue<T> : IEnumerable
    {
        public int Capacity { get; private set; } //Вместимость

        public int Count { get; private set; } //Кол-во элементов

        internal QueueElement<T> QueueElement; //Элемент очереди

        public bool Add(T person, int index) //Добавить элемент
        {
            if (index <= Count)
            {
                if (Count == index)
                {
                    Enqueue(person);
                }
                else
                {
                    QueueElement<T> nextElement = this[index];
                    this[index - 1].Next = new QueueElement<T>(person);
                    this[index].Next = nextElement;
                }

                if (++Count == Capacity)
                {
                    Capacity *= 2;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Remove(int index) //Удалить элемент
        {
            if (index <= Count)
            {
                if (index == Count)
                {

                    this[index] = null;
                }
                else
                {
                    this[index - 1].Next = this[index].Next;
                }

                Count--;
                return true;
            }

            return false;
        } 

        public QueueElement<T> this[int index] //Индекс элементаы
        {
            get
            {
                if (index < Count)
                {
                    int count = 0;
                    foreach (var element in this)
                    {
                        if (count == index) return (QueueElement<T>)element;
                        count++;
                    }
                }
                else Console.WriteLine("Индекс неверен!");
                return null;
            }
            set
            {
                if (index < Count)
                {
                    QueueElement<T> root = QueueElement;
                    for (var count = 0; count <= Count; count++)
                    {
                        if (count == index)
                        {
                            root = value;
                            break;
                        }
                        else root = root.Next;
                    }
                }
                else Console.WriteLine("Индекс неверен!");
            }
        }

        #region Constructors

        //Пустой конструктор
        public MyQueue()
        {
            Capacity = 10;
        }

        //С заданным разрешением(ёмкостью)
        public MyQueue(int capacity)
        {
            Capacity = capacity;
        }

        //Элементы и емкости другой последовательность(not ready)
        public MyQueue(MyQueue<T> queue)
        {
            Capacity = queue.Capacity;
            Count = queue.Count;
            QueueElement = queue.QueueElement;
        }

        #endregion

        #region Methods

        public bool Contains(object queueElement) //Проверить содержание
        {
            foreach (var queue in this)
                if (queue.Equals(queueElement))
                    return true;
            return false;
        }

        public void Clear() //Очистить
        {
            Count = 0;
            QueueElement = null;
        }

        public T Dequeue() //Исключить из очереди
        {
            Count--;
            T data = QueueElement.Data;
            QueueElement = QueueElement.Next;
            return data;
        }

        public void Enqueue(T addElement) //Включить в очередь
        {
            Count++;
            Capacity *= Count == Capacity ? 2 : 1;
            QueueElement<T> add = new QueueElement<T>(addElement);
            QueueElement<T> beg = QueueElement;
            if (beg != null)
            {
                while (beg.Next != null)
                {
                    beg = beg.Next;
                }
                add.Next = beg.Next;
                beg.Next = add;
            }
            else
            {
                QueueElement = add;
            }
        }

        public T Peek() //Возвращает значение элемента
        {
            return QueueElement.Data;
        }

        public T[] ToArray() //Преобразование в массив
        {
            T[] array = new T[0];
            foreach (T add in this)
            {
                Array.Resize(ref array, array.Length + 1);
                array[array.Length - 1] = add;
            }

            return array;
        }

        public MyQueue<T> Clone() //Клонирование
        {
            MyQueue<T> newQueue = new MyQueue<T>(Capacity);
            foreach (T cloneElement in this)
            {
                newQueue.Enqueue(cloneElement);
            }

            return newQueue;
        }

        public void CopyTo(out T[] array, int arrayIndex) //Копирование
        {
            array = new T[arrayIndex];
            int i = 0;
            foreach (T addElement in this)
            {
                array[i] = addElement;
                i++;
                if (i == arrayIndex)
                {
                    return;
                }
            }
        }

        #endregion

        public IEnumerator GetEnumerator() 
        {
            return new ClassEnumerator<T>(this);
        }
    }

    public class QueueElement<T> //Класс элемента
    {
        public T Data; //информационное поле 
        public QueueElement<T> Next; //адресное поле 

        public QueueElement() //конструктор без параметров 
        {
            Data = default(T);
            Next = null;
        }

        public QueueElement(T d) //конструктор с параметрами 
        {
            Data = d;
            Next = null;
        }

        public override bool Equals(object obj)
        {
            QueueElement<T> queue = (QueueElement<T>)obj;
            return (Data.Equals(queue.Data));
        }

        public override string ToString()
        {
            return Data + " ";
        }
    }

    public class ClassEnumerator<T> : IEnumerator
    {
        private int _position = -1; //Начальная позиция
        private readonly MyQueue<T> _t; //Очередь
        private QueueElement<T> currElement; //Текущий элемент

        public ClassEnumerator(MyQueue<T> t) //Конструктор с параметрами
        {
            _t = t;
            currElement = _t.QueueElement;
        }

        // Перемещение вперёд
        public bool MoveNext()
        {
            if (_position == -1)
            {
                _position++;
                return true;
            }

            if (currElement.Next != null)
            {
                _position++;
                currElement = currElement.Next;
                return true;
            }

            return false;
        }

        // Возврат в начало
        public void Reset()
        {
            _position = -1;
        }

        // Текущий элемент
        public object Current => currElement.Data;
    }
}
