
namespace lab1
{
    class Template<T>
    {
        private T[] TArray;
        private int ArrayLength;
        public Template(int n)
        {
            TArray = new T[n];
            ArrayLength = n;
        }
        public int GetArrayLength()
        {
            return ArrayLength;
        }
        public T GetElement(int n)
        {
            return TArray[n];
        }
        public T[] GetArray()
        {
            return TArray;
        }
        public T GetFromIndex(int index)
        {
            return TArray[index];
        }

        static public int operator ==(Template<T> template, T secondElement)
        {
            for (int i = 0; i < template.ArrayLength; i++)
            {
                if (Object.Equals(template.TArray[i], secondElement))
                    return i;
            }
            return -1;
        }

        static public int operator !=(Template<T> template, T secondElement)
        {
            for (int i = 0; i < template.ArrayLength; i++)
            {
                if (!Object.Equals(template.TArray[i], secondElement))
                    return i;
            }
            return -1;
        }

        static public bool templateMenu(Template<int> intArr, Template<char> charArr,
            Template<Workers> workerArr, Template<Dismissed> dismissArr)
        {
            while (true)
            {
                Console.WriteLine("Что делаем?\n" +
                                "1 - Добавить элемент в массив\n" +
                                "2 - Достать элемент из массивов\n" +
                                "3 - Найти элемент\n" +
                                "4 - Вывести минимальные элементы массива\n" +
                                "5 - Вывести максимальные элементы массива\n" +
                                "6 - Отсортировать массив\n" +
                                "7 - Вывести массивы\n" +
                                "8 - выход");

                if (int.TryParse(Console.ReadLine(), out int templateChoise))
                {
                    switch (templateChoise)
                    {
                        case 1:
                            Console.WriteLine("В каком массиве заменить элемент?\n" +
                                "1 - Массив чисел\n" +
                                "2 - Массив символов\n" +
                                "3 - Массив работников\n" +
                                "4 - Массив уволенных\n");
                            if (int.TryParse(Console.ReadLine(), out int Choise))
                            {
                                Console.WriteLine("Номер элемента - ");
                                int.TryParse(Console.ReadLine(), out int index1);
                                switch (Choise)
                                {
                                    case 1:
                                        Console.WriteLine("Введите число - ");
                                        int.TryParse(Console.ReadLine(), out int intElement);
                                        intArr.SetByIndex(index1, intElement);
                                        break;
                                    case 2:
                                        Console.WriteLine("Введите символ - ");
                                        char.TryParse(Console.ReadLine(), out char charElement);
                                        charArr.SetByIndex(index1, charElement);
                                        break;
                                    case 3:
                                        Workers film = new Workers();
                                        workerArr.SetByIndex(index1, film);
                                        break;
                                    case 4:
                                        Dismissed blockedFilm = new Dismissed();
                                        dismissArr.SetByIndex(index1, blockedFilm);
                                        break;
                                }
                            }
                            break;

                        case 2:

                            int.TryParse(Console.ReadLine(), out int index2);
                            if (CorrectImput.InRange(0, intArr.GetArrayLength() - 1, index2))
                            {
                                Console.WriteLine(intArr.GetFromIndex(index2));
                                Console.WriteLine(charArr.GetFromIndex(index2));
                                workerArr.GetElement(index2).Show();
                                dismissArr.GetElement(index2).Show();
                            }
                            else
                                Console.WriteLine("Неправильный номер элемента");
                            break;
                        case 3:
                            Console.WriteLine("В каком массиве найти элемент?\n" +
                              "1 - Массив чисел\n" +
                              "2 - Массив символов\n" +
                              "3 - Массив работников\n" +
                              "4 - Массив уволенных\n");
                            if (int.TryParse(Console.ReadLine(), out int findChoise))
                                switch (findChoise)
                                {
                                    case 1:
                                        Console.WriteLine("Введите число");
                                        int.TryParse(Console.ReadLine(), out int number);
                                        Console.WriteLine(intArr.findItem(intArr, number));
                                        break;
                                    case 2:
                                        Console.WriteLine("Введите символ");
                                        char.TryParse(Console.ReadLine(), out char symbol);
                                        Console.WriteLine(charArr.findItem(charArr, symbol));
                                        break;
                                    case 3:
                                        Console.WriteLine(workerArr.findItem(workerArr, new Workers()));
                                        break;
                                    case 4:
                                        Console.WriteLine(dismissArr.findItem(dismissArr, new Dismissed()));
                                        break;
                                }
                            break;
                        case 4:
                            Console.WriteLine("Цифра - " + intArr.min() + "\n" +
                                 "Символ - " + charArr.min() + "\n" +
                                 "Работник -");
                            workerArr.min().Show();
                            Console.WriteLine("Уволенные -");
                            dismissArr.min().Show();
                            break;
                        case 5:
                            Console.WriteLine("Цифра - " + intArr.max() + "\n" +
                             "Символ - " + charArr.max() + "\n" +
                             "Работник -");
                            workerArr.max().Show();
                            Console.WriteLine("Уволенные -");
                            dismissArr.max().Show();
                            break;  
                        case 6:
                            intArr.Sort();
                            charArr.Sort();
                            workerArr.Sort();
                            dismissArr.Sort();
                            Console.WriteLine("Все массивы отсортированны");
                            break;
                        case 7:
                            Template<int>.SeeArrays(intArr, charArr, workerArr, dismissArr);
                            break;
                        case 8:
                            return true;
                    }
                }
            }
        }
        public void SetByIndex(int index, T element)
        {
            if (TArray.Length == 0)
            {
                Console.WriteLine("Массив пуст");
                return;
            }
            if (CorrectImput.InRange(0, TArray.Length - 1, index))
                TArray[index] = element;
            else
                Console.WriteLine("номер элемента выходит за пределы массива");
        }

        public int findItem(Template<T> template, T obj)
        {
            return template == obj;
        }

        public void Sort()
        {
            List<T> list = new List<T>(TArray);
            list.Sort();
            TArray = list.ToArray();
        }

        public T max()
        {
            List<T> list = new List<T>(TArray);
            list.Sort();
            return list[list.Count - 1];
        }

        public T min()
        {
            List<T> list = new List<T>(TArray);
            list.Sort();
            return list[0];
        }

        static public void SeeArrays(Template<int> intArr, Template<char> charArr,
            Template<Workers> favoriteFilmArray, Template<Dismissed> dismissArr)
        {
            Console.Write("Числа - ");
            for (int i = 0; i < intArr.GetArrayLength(); i++)
            {
                Console.Write(intArr.GetFromIndex(i) + ", ");
            }
            Console.WriteLine("");

            Console.Write("Символы - ");
            for (int i = 0; i < charArr.GetArrayLength(); i++)
            {
                Console.Write(charArr.GetFromIndex(i) + ", ");
            }
            Console.WriteLine("");

            Console.WriteLine("Работники - ");
            for (int i = 0; i < favoriteFilmArray.GetArrayLength(); i++)
            {
                favoriteFilmArray.GetFromIndex(i).Show();
                Console.WriteLine("");
            }

            Console.WriteLine("Уволенные - ");
            for (int i = 0; i < dismissArr.GetArrayLength(); i++)
            {
                dismissArr.GetFromIndex(i).Show();
                Console.WriteLine("");
            }
        }
    }

}
