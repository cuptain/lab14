using System;
using System.Collections;

namespace лаба12
{
    public class MyQueue<T> : IEnumerable
    {
        public int Capacity { get; private set; }

        public int Count { get; private set; }

        internal QueueElement<T> QueueElement;

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

        public bool Contains(object queueElement)
        {
            foreach (var queue in this)
            {
                if (queue.Equals(queueElement))
                {
                    return true;
                }
            }

            return false;
        }

        public void Clear()
        {
            Count = 0;
            QueueElement = null;
        }

        public T Dequeue()
        {
            Count--;
            T data = QueueElement.Data;
            QueueElement = QueueElement.Next;
            return data;
        }

        public void Enqueue(T addElement)
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

        public T Peek()
        {
            return QueueElement.Data;
        }

        public T[] ToArray()
        {
            T[] array = new T[0];
            foreach (T add in this)
            {
                Array.Resize(ref array, array.Length + 1);
                array[array.Length - 1] = add;
            }

            return array;
        }

        public MyQueue<T> Clone()
        {
            MyQueue<T> newQueue = new MyQueue<T>(Capacity);
            foreach (T cloneElement in this)
            {
                newQueue.Enqueue(cloneElement);
            }

            return newQueue;
        }

        public void CopyTo(out T[] array, int arrayIndex)
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

    internal class QueueElement<T>
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

    internal class ClassEnumerator<T> : IEnumerator
    {
        private int _position = -1;
        private readonly MyQueue<T> _t;
        private QueueElement<T> currElement;

        public ClassEnumerator(MyQueue<T> t)
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
