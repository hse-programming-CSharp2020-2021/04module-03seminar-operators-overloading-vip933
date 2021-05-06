using System;

/*
Источник: https://metanit.com/

Как известно, неотъемлемыми компонентами бутерброда являются хлеб и масло.
Допустим, у нас есть классы Bread, Butter, Sandwich.
Добавьте в один из классов оператор сложения, чтобы при объединении хлеба (Bread) и масла (Butter)
получался бутерброд (Sandwich), и, тем самым, компилировался и выполнялся без ошибок код в методе Main.
Обработайте ситуации, когда вес отрицательный (в этом случае должен быть выброшен ArgumentException).

Тестирование приложения выполняется путем запуска разных наборов тестов, например,
на вход может поступить строка (веса компонентов бутерброда, разделенные через пробел):
10 10
Программа должна вывести на экран:
20
Никаких дополнительных символов выводиться не должно.

Код метода Main можно подвергнуть изменениям, но вывод меняться не должен.
*/

namespace Task01
{
    class Bread
    {
        public int Weight { get; set; }
    }
    class Butter
    {
        public int Weight { get; set; }

        public static Sandwich operator +(Bread left, Butter right)
        {
            if (left.Weight < 0 || right.Weight < 0)
                throw new ArgumentException();
            return new Sandwich { Weight = left.Weight + right.Weight };
        }
    }
    class Sandwich
    {
        public int Weight { get; set; }
    }

    class MainClass
    {
        public static void Main()
        {
            Sandwich sandwich = null;
            string[] strs = Console.ReadLine().Split();
            try
            {
                Bread bread = new Bread { Weight = int.Parse(strs[0]) };
                Butter butter = new Butter { Weight = int.Parse(strs[1]) };
                sandwich = bread + butter;
                Console.WriteLine(sandwich.Weight);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
            }
            
        }
    }
}
