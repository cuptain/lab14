using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Libriary
{
    public class Easy
    //Всякое
    {
        public static int EnterInt()
        //Ввод целых чисел
        {
            int number;
            bool ok = false;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out number);
                if (!ok)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n Ввод неправильный, нужно ввести целое число. Повторите попытку:");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (!ok);
            return number;
        }

        public static int Choice(int max, int min, string error, string task = null)
        //Выбор с условиями
        {
            int choice;
            bool ok = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (task != null) Console.WriteLine(task);
                ok = int.TryParse(Console.ReadLine(), out choice);
                if (!ok | choice > max | choice < min)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n" + error);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (!ok | choice > max | choice < min);
            return choice;
        }

        public static int ReadInt()
        //ввод числа для красивых лаб
        {
            bool check = false;
            int inpNum;
            do
            {
                // Попытка перевести строку в число
                check = Int32.TryParse(Console.ReadLine(), out inpNum);
                // Если попытка неудачная:
                if (!check)
                    Console.WriteLine("Некорректный ввод. Попробуйте ещё раз");
            } while (!check);
            // Если попытка удачная:
            return inpNum;
        }

        public static string EnterName(string task = null)
        //ввод ФИО
        {
            string name = null;
            bool ok = false;
            string pattern = @"(?<!\S)\b[А-Я][А-я]+[ ]{1}[А-Я][А-я]+(?!\S)\b";
            Regex r = new Regex(pattern);
            do
            {
                Console.Write(task);
                name = Console.ReadLine();
                ok = r.IsMatch(name);
                if (!ok) { Console.WriteLine("Ошибка ввода. Введите фамилию и имя в формате \"Фамилия Имя\" :"); ok = false; }
            } while (!ok);
            return name;
        }

        public static int ReadNaturalNum(string name) 
        //ввод натурального числа
        {
            int inpNum;
            do
            {
                // Вводим целое число
                inpNum = ReadInt();
                // Проверка на натуральность
                if (inpNum <= 0)
                    Console.WriteLine(name + " должен(но) быть задан натуральным числом, попробуйте ещё раз:");
            } while (inpNum <= 0);
            return inpNum;
        }

        public static int ReadVGran(int min, int max, string name = null)
        {
            int chislo;
            do
            {
                chislo = ReadInt();
                if (chislo < min || chislo > max) Console.WriteLine(name + " должен быть больше, чем {0} и меньше, чем {1}. Попробуйте ещё раз:", min, max);
            } while (chislo < min || chislo > max);
            return chislo;
        }

        public static long ReadVGran(long min, long max, string name = null)
        {
            long chislo;
            do
            {
                chislo = ReadInt();
                if (chislo < min || chislo > max) Console.WriteLine(name + " должна быть больше, чем {0}. Попробуйте ещё раз:", min);
            } while (chislo < min || chislo > max);
            return chislo;
        }

        public static int ReadVGran(int min, string name = null)
        {
            int inpNum;
            do
            {
                inpNum = ReadInt();
                if (inpNum <= min)
                    Console.WriteLine(name + " должен(но) быть больше, чем {0}. Попробуйте ещё раз:", min);
            } while (inpNum <= min);
            return inpNum;
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }
    }

    public class OutputArrays
    //Вывод массивов
    {
        public static void OutputArray(int[] arr) //Вывод одномерного массива
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (arr.Length == 0) Console.WriteLine(" Массив пуст \n");
            else
            {
                Console.WriteLine(" Массив имеет вид:");
                for (int i = 0; i < arr.Length; i++)
                    Console.Write(" " + arr[i]);
                Console.WriteLine("\n");
                Console.WriteLine("  Общее кол-во элементов = {0}", arr.Length);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void OutputArray(int[][] arr) //Вывод рваного массива (целые числа)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (arr.Length == 0) Console.WriteLine(" Массив пуст \n");
            else
            {
                Console.WriteLine(" Массив имеет вид:");
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr[i].Length; j++)
                        Console.Write("{0,5}", arr[i][j]);
                    Console.WriteLine();
                }
                int sum = 0;
                for (int i = 0; i < arr.GetLength(0); i++)
                    foreach (int x in arr[i]) sum++;
                Console.WriteLine("\n");
                Console.WriteLine("  Общее кол-во элементов = {0}", sum);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void OutputArray(int[,] arr) //Вывод двумерного массива
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (arr.Length == 0) Console.WriteLine(" Массив пуст \n");
            else
            {
                Console.WriteLine(" Массив имеет вид:\n");
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                        Console.Write("{0,5}", arr[i, j]);
                    Console.WriteLine();
                }
                Console.WriteLine("\n  Общее кол-во элементов = {0}", arr.GetLength(0) * arr.GetLength(1));
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void OutputArray(char[][] arr) //Вывод рваного массива (символы)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (arr.Length == 0) Console.WriteLine(" Массив пуст \n");
            else
            {
                Console.WriteLine(" Массив имеет вид:\n");
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr[i].Length; j++)
                        Console.Write("{0} ", arr[i][j]);
                    Console.WriteLine();
                }
                int sum = 0;
                for (int i = 0; i < arr.GetLength(0); i++)
                    foreach (int x in arr[i]) sum++;
                Console.WriteLine("\n  Общее кол-во элементов = {0}", sum);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }

    public class ArrayFilling
    //Заполнение массивов
    {
        static Random rnd = new Random();

        public static void Random(int n, ref int[] arr, int begin = 0)
        //Заполнение одномерного массива рандомными целыми числами
        {
            for (int i = begin; i < n; i++)
            {
                arr[i] = rnd.Next(-100, 100);
            }
            Console.WriteLine();
        }

        public static void Random(int h, int w, ref int[,] arr, int hbegin = 0, int wbegin = 0)
        //Заполнение двумерного массива рандомными целыми числами
        {
            Random rnd = new Random();
            for (int i = hbegin; i < h; i++)
            {
                for (int j = wbegin; j < w; j++)
                    arr[i, j] = rnd.Next(-100, 100);
            }
            Console.WriteLine(); ;
        }

        public static void Hand(int n, ref int[] arr, int begin = 0)
        //Заполнение одномерного массива целыми числами с клавиатуры
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = begin; i < n; i++)
            {
                bool ok = false;
                Console.WriteLine("\n Введите {0}-й элемент массива", i + 1);
                do
                {
                    ok = int.TryParse(Console.ReadLine(), out arr[i]);
                    if (!ok)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n Ввод неправильный, нужно ввести целое число. Повторите попытку:");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                } while (!ok);
            }
            Console.WriteLine();
        }

        public static void Hand(int h, int w, ref int[,] mas, int hbegin = 0, int wbegin = 0)
        //Заполнение двумерного массива целыми числами с клавиатуры
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = hbegin; i < h; i++)
            {
                for (int j = wbegin; j < w; j++)
                {
                    bool ok = false;
                    Console.WriteLine("\n Введите {0}-й элемент массива, {1}-й строки", j + 1, i + 1);
                    do
                    {
                        ok = int.TryParse(Console.ReadLine(), out mas[i, j]);
                        if (!ok)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n Ввод неправильный, нужно ввести целое число. Повторите попытку:");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    } while (!ok);
                }
            }
            Console.WriteLine();
        }
    }

    public class CreatingArrays
    //Создание массивов
    {
        public static int EnterForArray()
        //Ввод параметров массива (строки/столбцы/номера)
        {
            bool ok;
            int number;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out number);
                if (number < 0) ok = false;
                if (!ok)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n Ошибка, ожидалось целое не отрицательное число. Попробуйте ещё раз:");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (!ok);
            Console.WriteLine();
            return number;
        }

        public static int AskSize()
        //Запрос длины одномерного массива
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Введите количество элементов в массиве:");
            int kolvo;
            do
            {
                kolvo = EnterForArray();
                if (kolvo == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n Извините, работа с пустым массивом невозможна. Введите число больше нуля:");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (kolvo < 1);
            return kolvo;
        }

        public static void AskSize(ref int high, ref int width)
        //Запрос кол-ва столбцов и строк для двумерного массива
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Введите количество строк в массиве:");
            do
            {
                high = EnterForArray();
                if (high == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n Извините, работа с пустым массивом невозможна. Введите число больше нуля:");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (high < 1);
            Console.WriteLine(" Введите количество столбцов в массиве:");
            do
            {
                width = EnterForArray();
                if (width == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n Извините, работа с пустым массивом невозможна. Введите число больше нуля:");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (width < 1);
        }

        public static int EnterSelection()
        //Выбор ввода
        {
            int k = 0;
            bool ok = true;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Выберите способ ввода массива:");
            Console.WriteLine("\n   1: Выполнить ввод вручную (с клавиатуры)");
            Console.WriteLine("   2: Создать массив с помощью датчика случайных чисел");
            do
            {
                ok = int.TryParse(Console.ReadLine(), out k);
                if ((k < 1) || (k > 2)) ok = false;
                if (!ok)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n Ввод неправильный. Повторите попытку.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (!ok);
            ok = false;
            return k;
        }

        public static int[] Create1()
        //Создание одномерного массива
        {
            int k, kolvo;
            kolvo = AskSize();
            int[] arr = new int[kolvo];
            k = EnterSelection();
            if (k == 1)
                ArrayFilling.Hand(kolvo, ref arr);
            else
                ArrayFilling.Random(kolvo, ref arr);
            OutputArrays.OutputArray(arr);
            return arr;
        }

        public static int[,] Create2()
        //Создание двумерного массива
        {
            int k, high = 0, width = 0;
            AskSize(ref high, ref width);
            int[,] arr = new int[high, width];
            k = EnterSelection();
            if (k == 1)
                ArrayFilling.Hand(high, width, ref arr);
            else
                ArrayFilling.Random(high, width, ref arr);
            OutputArrays.OutputArray(arr);
            return arr;
        }

        public static int [][] CreateIntRag()
        //Создание рваного массива
        {
            int column, strings, k, i, j;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Введите количество строк в массиве:");
            do
            {
                strings = EnterForArray();
                if (strings == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n Извините, работа с пустым массивом невозможна. Введите число больше нуля:");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (strings < 1);
            int[][] arr = new int[strings][];
            for (i = 0; i < strings; i++)
            {
                Console.WriteLine(" Введите количество столбцов в {0}-й строке массива:", i + 1);
                column = EnterForArray();
                arr[i] = new int[column];
            }
            k = EnterSelection();
            if (k == 1)
            {
                for (i = 0; i < strings; i++)
                    for (j = 0; j < arr[i].Length; j++)
                    {
                        bool ok = false;
                        Console.WriteLine("\n Введите {0}-й элемент массива, {1}-й строки", j + 1, i + 1);
                        do
                        {
                            ok = int.TryParse(Console.ReadLine(), out arr[i][j]);
                            if (!ok)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n Ввод неправильный, нужно ввести целое число. Повторите попытку:");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        } while (!ok);
                    }
            }
            else
            {
                Random rnd = new Random();
                for (i = 0; i < strings; i++)
                    for (j = 0; j < arr[i].Length; j++)
                        arr[i][j] = rnd.Next(-10, 10);
            }
            OutputArrays.OutputArray(arr);
            return arr;
        }

        public static char [][] CreateCharRag()
        //Создание рваного массива
        {
            int column, strings, k, i, j;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Введите количество строк в массиве:");
            do
            {
                strings = EnterForArray();
                if (strings == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n Извините, работа с пустым массивом невозможна. Введите число больше нуля:");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (strings < 1);
            char[][] arr = new char[strings][];
            for (i = 0; i < strings; i++)
            {
                Console.WriteLine(" Введите количество столбцов в {0}-й строке массива:", i + 1);
                column = EnterForArray();
                arr[i] = new char[column];
            }
            k = EnterSelection();
            if (k == 1)
            {
                for (i = 0; i < strings; i++)
                    for (j = 0; j < arr[i].Length; j++)
                    {
                        bool ok = false;
                        Console.WriteLine("\n Введите {0}-й элемент массива, {1}-й строки", j + 1, i + 1);
                        do
                        {
                            ok = char.TryParse(Console.ReadLine(), out arr[i][j]);
                            if (!ok)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n Ввод неправильный, нужно ввести целое число. Повторите попытку:");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        } while (!ok);
                    }
            }
            else
            {
                Random rnd = new Random();
                string chars = "$%#@!*абвгдеёжзийклмнопрстуфхцчшщъыьэюя1234567890?;:АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ^&";
                for (i = 0; i < strings; i++)
                    for (j = 0; j < arr[i].Length; j++)
                        arr[i][j] = chars[rnd.Next(0, chars.Length - 1)];
            }
            Console.WriteLine();
            OutputArrays.OutputArray(arr);
            return arr;
        }
    }

    public class FuncFor1Arrays
    //Функции для одномерных массивов
    {
        public static void DeleteNum(ref int[] arr)
        //Удаление элемента массива с заданным номером
        {
            if (arr.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n Массив пуст, операция невозможна.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                int i, num;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n Введите номер элемента, который хотите удалить:");
                do
                {
                    num = CreatingArrays.EnterForArray();
                    if ((num > arr.Length) || (num == 0))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n Ошибка, ожидался номер элемента, существующий в данном массиве. Попробуйте ещё раз:");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                while ((num > arr.Length) || (num == 0));
                int m = arr.Length - 1;
                int[] newarr = new int[m];
                for (i = 0; i < num - 1; i++)
                    newarr[i] = arr[i];
                for (i = num - 1; i < m; i++)
                    newarr[i] = arr[i + 1];
                arr = newarr;
            }
            OutputArrays.OutputArray(arr);
            Console.WriteLine();
        }

        public static int AddSelection()
        //Выбор способа добавления элементов
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Выберите способ, которым вы хотите добавить элементы:");
            Console.WriteLine("\n   1-Ввод с клавиатуры");
            Console.WriteLine("   2-Ввод с помощью датчика случайных чисел");
            int choice;
            bool ok;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out choice);
                if ((choice < 1) || (choice > 2)) ok = false;
                if (!ok)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n Ввод неправильный. Повторите попытку.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (!ok);
            ok = false;
            return choice;
        }

        public static void Add(ref int[] arr)
        //Добавление заданного кол-ва элементов с заданного номера
        {
            if (arr.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n Массив пуст, поэтому нужно добавлять элементы с номера '1'.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            int adds, num, k, j = 0, i = 0;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n Введите кол-во элементов, которое хотите добавить:");
            adds = CreatingArrays.EnterForArray();
            Console.WriteLine("\n Введите номер элемента, с которого нужно вставить элементы");
            do
            {
                num = CreatingArrays.EnterForArray();
                if ((num > arr.Length + 1) || (num < 1))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n Извините, такого номера в данном массиве не существует. Попробуйте ещё раз:");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while ((num > arr.Length + 1) || (num < 1));
            num--;
            int[] newarr = new int[arr.Length + adds];
            for (i = 0; i < num; i++)
                newarr[i] = arr[i];
            for (i = num; i < arr.Length; i++)
                newarr[i + adds] = arr[i];
            arr = newarr;
            k = AddSelection();
            if (k == 1)
                ArrayFilling.Hand(num + adds, ref arr, num);
            else
                ArrayFilling.Random(num + adds, ref arr, num);
            OutputArrays.OutputArray(arr);
            Console.WriteLine();
        }

        public static void Sdvig(ref int[] arr)
        //Сдвиг одномерного массива влево на заданное кол-во элементов
        {
            if (arr.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n Массив пуст, операция невозможна.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n На сколько элементов нужно сдвинуть массив?");
                int M = CreatingArrays.EnterForArray();
                for (int p = 0; p < M; p++)
                {
                    int mind = arr[0];
                    for (int i = 1; i < arr.Length; i++)
                    {
                        arr[i - 1] = arr[i];
                    }
                    arr[arr.Length - 1] = mind;
                }
            }
            OutputArrays.OutputArray(arr);
            Console.WriteLine();
        }

        public static void Sort(ref int[] arr)
        //Сортировка массива простым включением
        {
            if (arr.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n Массив пуст, операция невозможна.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                int[] result = new int[arr.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    int j = i;
                    while (j > 0 && result[j - 1] > arr[i])
                    {
                        result[j] = result[j - 1];
                        j--;
                    }
                    result[j] = arr[i];
                }
                arr = result;
            }
            OutputArrays.OutputArray(arr);
            Console.WriteLine();
        }

        public static void FindKey(ref int[] arr)
        //Поиск элемента с заданным значением в одномерном массиве
        {
            if (arr.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n Массив пуст, операция невозможна.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                bool ok, t = false;
                int key;
                Console.WriteLine("\n Введите значение элемента, который хотите найти:");
                do
                {
                    ok = int.TryParse(Console.ReadLine(), out key);
                    if (!ok)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n Ошибка, ожидалось целое число. Попробуйте ещё раз:");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                } while (!ok);
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == key)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n Найден элемент с заданным значением = {0}. Он находится под номером {1}.", arr[i], i + 1);
                        Console.WriteLine("\n Количество сравнений = " + (i + 1));
                        Console.WriteLine();
                        t = true;
                        break;
                    }
                }
                if (!t)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Элементов с заданным значением в этом массиве не существует");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            OutputArrays.OutputArray(arr);
            Console.WriteLine();
        }

        public static void Bin(ref int[] arr)
        //Бинарный поиск элемента с заданным значением в отсортированном массиве
        {
            if (arr.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n Массив пуст, операция невозможна.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                bool ok;
                int el, k = -2, u = 0;
                for (int i = 0; i < arr.Length; i++)
                    for (int j = i + 1; j < arr.Length - i; j++)
                        if (arr[i] > arr[j])
                            u++;
                if ((arr[arr.Length - 1] < arr[0]) || (u > 0))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n Невозможно выполнить поиск. Сначала отсортируйте массив.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine("\n Введите значение элемента, который хотите найти:");
                    do
                    {
                        ok = int.TryParse(Console.ReadLine(), out el);
                        if (!ok)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n Ошибка, ожидалось целое число. Попробуйте ещё раз:");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    } while (!ok);
                    if ((el < arr[0]) || (el > arr[arr.Length - 1]))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n Элемент с заданным значением на найден.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        int first = 0;
                        int last = arr.Length;
                        while (first < last)
                        {
                            int mid = first + (last - first) / 2;
                            if (el <= arr[mid])
                            {
                                last = mid;
                                k++;
                            }

                            else
                            {
                                first = mid + 1;
                                k++;
                            }
                        }

                        if (arr[last] == el)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n Найден элемент с заданным значением = {0}. Он находится под номером {1}.", el, last + 1);
                            Console.WriteLine("\n Количество сравнений = " + k);
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n Элемент с заданным значением на найден.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        Console.WriteLine();
                    }
                }
            }
            OutputArrays.OutputArray(arr);
            Console.WriteLine();
        }

        public static void DeleteKey(ref int[] arr)
        //Удаление элемента с заданным значением
        {
            if (arr.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Массив пуст, операция невозможна.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                int i, key, num = 0, flag = 0;
                bool ok;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" Введите значение элемента, который хотите удалить:");
                do
                {
                    ok = int.TryParse(Console.ReadLine(), out key);
                    if (!ok)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n Ошибка, ожидалось целое число. Попробуйте ещё раз:");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                } while (!ok);
                for (i = 0; i < arr.Length; i++)
                    if (arr[i] == key)
                    {
                        num = i;
                        flag++;
                    }
                if (flag > 0)
                {
                    int m = arr.Length - 1;
                    int[] newarr = new int[m];
                    for (i = 0; i < num; i++)
                        newarr[i] = arr[i];
                    for (i = num; i < m; i++)
                        newarr[i] = arr[i + 1];
                    arr = newarr;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n Элемента с заданным значением не существует.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.WriteLine();
            OutputArrays.OutputArray(arr);
            //Console.WriteLine();
        }

        public static string[] DeleteKey(string[] arr, string key)
        {
            int i, num = 0, flag = 0;
            for (i = 0; i < arr.Length; i++)
                if (arr[i].Contains(key))
                {
                    num = i;
                    flag++;
                }
            if (flag > 0)
            {
                int m = arr.Length - 1;
                string[] newarr = new string[m];
                for (i = 0; i < num; i++)
                    newarr[i] = arr[i];
                for (i = num; i < m; i++)
                    newarr[i] = arr[i + 1];
                arr = newarr;
            }
            return arr;
        }
    }

    public class FuncFor2Arrays
    //Функции для двумерных массивов
    {
        public static void AddString(ref int[,] arr)
        //Добавление строки в конец массива
        {
            int[,] newarr = new int[arr.GetLength(0) + 1, arr.GetLength(1)];
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    newarr[i, j] = arr[i, j];
            int k;
            k = FuncFor1Arrays.AddSelection();
            if (k == 1)
                ArrayFilling.Hand(arr.GetLength(0) + 1, arr.GetLength(1), ref newarr, arr.GetLength(0));
            else
                ArrayFilling.Random(arr.GetLength(0) + 1, arr.GetLength(1), ref newarr, arr.GetLength(0));
            arr = newarr;
            OutputArrays.OutputArray(arr);
            //Console.WriteLine();
        }

    }

    public class FuncForRagArrays
    //Функции для рваных массивов
    {
        public static void DeleteString(ref int[][] arr)
        //Удаление строк, содержащих нули
        {
            if (arr.GetLength(0) == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Массив пуст, операция невозможна.\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                int k, num = 0, kol = 0, flag = 0;
                int length = arr.GetLength(0);
                for (int i = 0; i < arr.GetLength(0); i++)
                    for (int j = 0; j < arr[i].Length; j++)
                        if (arr[i][j] == 0)
                        {
                            arr[i] = null;
                            kol++;
                            flag++;
                            break;
                        }
                while (kol != 0)
                {
                    length--;
                    int[][] newarr = new int[length][];
                    for (int i = 0; i < arr.GetLength(0); i++)
                        if (arr[i] == null)
                        {
                            kol--;
                            num = i;
                            break;
                        }
                    for (k = 0; k < num; k++)
                        newarr[k] = arr[k];
                    for (k = num; k < length; k++)
                        newarr[k] = arr[k + 1];
                    arr = newarr;
                }
                if (flag == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" В массиве нет строк, содержащих нули.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
                OutputArrays.OutputArray(arr);
            }
            //Console.WriteLine();
        }

        public static void DeleteString(ref char[][] arr)
        //Удаление первой строки с 3мя и более гласными
        {
            char[] glas = {'а', 'у', 'о', 'ы', 'и', 'э', 'я', 'ю', 'е', 'ё', 'А', 'У', 'О', 'Ы', 'И', 'Э', 'Я', 'Ю', 'Е', 'Ё' };
            if (arr.GetLength(0) == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Массив пуст, операция невозможна.\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                int k, num = -1, kol = 0;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr[i].Length; j++)
                        if (glas.Contains(arr[i][j]))
                            kol++;
                    if (kol >= 3)
                    {
                        num = i;
                        break;
                    }
                    else
                        kol = 0;
                }
                if (num > -1)
                {
                    char[][] newarr = new char[arr.GetLength(0) - 1][];
                    //Array.Copy(arr, 0, newarr, 0, num - 1);
                    //Array.Copy(arr, num, newarr, num, arr.GetLength(0) - num - 2);
                    for (k = 0; k < num; k++)
                        newarr[k] = arr[k];
                    for (k = num; k < arr.GetLength(0)-1; k++)
                        newarr[k] = arr[k + 1];
                    arr = newarr;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" В массиве нет строк, с тремя и более гласными.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
                OutputArrays.OutputArray(arr);
            }
            //Console.WriteLine();
        }
    }

    public class Strings
    //Функции для строк
    {
        public static string CreateString()
        //Создание строки
        {
            int k;
            string beginString = null;
            Random rnd = new Random();
            k = Easy.Choice(2, 1, "Ошибка. Выберите пункт из меню:", "Как вы хотите создать строку?" +
                "\n 1 - Ввести с клавиатуры\n 2 - С помощью случайного заполнения");
            if (k == 1)
            {
                Console.WriteLine("\n Введите строку:");
                beginString = Console.ReadLine();
            }
            else
            {
                string chars = "a bcde fgh ijklmn_opqr stuvwx yz12 34567890, ;:ABCD EFG HIJKLM NOPQRSRUV WX YZ.!? " +
                    "абв гдеёж з ийклм_нопрст уф хцчшщъыь эюя АБВГДЕ _ЁЖЗИЙК ЛМНО_ПРС ТУФХЦЧШЩЪЫ ЬЭ ЮЯ";
                int length = rnd.Next(10, 50);
                char[] symbols = new char[length];
                for (int i = 0; i < length; i++)
                    symbols[i] = chars[rnd.Next(0, chars.Length - 1)];
                string randomstring = new string (symbols);
                beginString = randomstring;
            }
            Console.WriteLine();
            OutputString(beginString);
            return beginString;
        }

        public static void OutputString(string stroka)
        //Вывод строки
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (stroka.Length == 0) Console.WriteLine(" В строке нет символов \n");
            else
            {
                Console.WriteLine(" Строка имеет вид:");
                Console.WriteLine(stroka + '\n');
                Console.WriteLine(" Общее кол-во элементов = {0}", stroka.Length);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void LongIdentify(string stroka)
        //поиск самого длинного идентификатора
        {
            string Copy = stroka;
            string[] ident = new string [0];
            string[] splits = {" ", ". ", "! ", "? ", ": ", "; ", ", "};
            string[] words = Copy.Split(splits, StringSplitOptions.None);
            string pattern = @"(?<!\S)\b[_A-zА-я][\dА-яA-z_]*(?!\S)\b";
            Regex reg = new Regex(pattern);
            for (int i = 0; i < words.Length; i++)
                if (reg.IsMatch(words[i]))
                {
                    int length = ident.Length;
                    Array.Resize(ref ident, length + 1);
                    ident[ident.Length - 1] = words[i];
                }
            Console.ForegroundColor = ConsoleColor.Green;
            if (ident.Length == 0)
            { if (stroka.Length == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("В строке нет символов => нет идентификаторов\n");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("В строке нет идентификаторов\n");
                }
            }
            else
            {
                int max = ident[0].Length;
                int num = 0;
                for (int i = 1; i < ident.Length; i++)
                    if (ident[i].Length > max)
                    {
                        max = ident[i].Length;
                        num = i;
                    }
                Console.WriteLine("Самый длинный найденный идентификатор: " + ident[num] + '\n');
            }
        }
    }   
}
