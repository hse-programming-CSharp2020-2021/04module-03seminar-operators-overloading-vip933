using System;

/*
Источник: https://metanit.com/

Класс Dollar представляет сумму в долларах, а Euro - сумму в евро.

Определите операторы преобразования от типа Dollar в Euro и наоборот.
Допустим, 1 евро стоит 1,14 долларов. При этом один оператор должен подразумевать явное,
и один - неявное преобразование. Обработайте ситуации с отрицательными аргументами
(в этом случае должен быть выброшен ArgumentException).

Тестирование приложения выполняется путем запуска разных наборов тестов, например,
на вход поступает две строки - количество долларов и количество евро.
10
100
Программа должна вывести на экран количество евро и долларов, соответственно,
с использованием перегруженных операторов (округлять до 2 знаков после запятой):
8,77
114,00

Никаких дополнительных символов выводиться не должно.

Код метода Main можно подвергнуть изменениям, но вывод меняться не должен.
*/

namespace Task05
{
    class Dollar
    {
        private decimal sum;
        public decimal Sum
        {
            get => sum;
            set
            {
                if (value < 0)
                    throw new ArgumentException();
                sum = value;
            }
        }

        public static implicit operator Dollar(Euro euro)
        {
            return new Dollar { Sum = euro.Sum * new decimal(1.14) };
        }

        public override string ToString() => $"{sum:f2}";
    }
    class Euro
    {
        private decimal sum;
        public decimal Sum
        {
            get => sum;
            set
            {
                if (value < 0)
                    throw new ArgumentException();
                sum = value;
            }
        }

        public static explicit operator Euro(Dollar dollar)
        {
            return new Euro { Sum = dollar.Sum / new decimal(1.14) };
        }

        public override string ToString() => $"{sum:f2}";
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ru-RU");
            try
            {
                Dollar dollar = new Dollar { Sum = int.Parse(Console.ReadLine()) };
                Euro euro = new Euro { Sum = int.Parse(Console.ReadLine()) };
                Console.WriteLine((Euro)dollar);
                Console.WriteLine((Dollar)euro);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
            }
        }
    }
}
