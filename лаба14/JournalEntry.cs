using Hierarchy;

namespace лаба14
{
    class JournalEntry //Элемент журнала
    {
        private string CollectionName { get; set; } //Имя коллекции
        private string TypeOfChange { get; set; } //Тип изменения
        private Person ChangedObject { get; set; } //Изменённый объект

        public JournalEntry(string name, string changes, Person person) //Конструктор с параметрами
        {
            TypeOfChange = changes;
            ChangedObject = person;
            CollectionName = name;
        }

        public override string ToString() //Вывод
        {
            return "Имя коллекции: " + CollectionName + "; Тип изменения: " + TypeOfChange + "; Измененный объект: " + ChangedObject.ToString();
        }
    }
}
