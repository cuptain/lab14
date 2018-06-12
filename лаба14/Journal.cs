using System;

namespace лаба14
{
    class Journal //Журнал
    {
        private JournalEntry[] journal = new JournalEntry[0]; //Массив элементов журнала

        private string NameColl { get; set; } //Имя коллекции

        public Journal(string name) //Конструктор с параметром
        {
            NameColl = name;
        }

        public void Add(JournalEntry je) //Добавление записи в журнал
        {
            Array.Resize(ref journal, journal.Length + 1);
            journal[journal.Length - 1] = je;
        }

        public override string ToString() //Вывод
        {
            string str = "\nЖурнал для коллекции " + NameColl + ":\n";
            int count = 0;
            foreach (var element in journal)
            {
                str = String.Concat(str, ++count, ". ", element.ToString(), "\n");
            }
            return str;
        }

        public void CollectionCountChanged(object sourse, CollectionHandlerEventArgs e) //Событие при изменении кол-ва элементов
        {
            JournalEntry je = new JournalEntry(e.CollectionName, e.TypeOfChange, e.ChangedObj);
            Add(je);
        }

        public void CollectionReferenceChanged(object sourse, CollectionHandlerEventArgs e) //Событие при изменении ссылок на элементы
        {
            JournalEntry je = new JournalEntry(e.CollectionName, e.TypeOfChange, e.ChangedObj);
            Add(je);
        }
    }
}
