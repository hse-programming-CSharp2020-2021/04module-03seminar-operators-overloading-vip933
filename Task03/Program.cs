using System;

/*
Источник: https://metanit.com/

Дан класс Clock, который хранит количество часов.
В программе мы можем из целого (int) числа минут получить целое число часов (Clock) и, наоборот,
из целого числа часов (Clock) - целое количество минут (int) (возможна потеря точности).
Добавьте в класс Clock оператор для неявного преобразования от типа целого числа минут
к типу Clock - числу часов, и оператор явного преобразования от типа Clock к типу
int-овому числу минут.
Обработайте ситуации, когда число часов отрицательно (в этом случае должен быть выброшен ArgumentException).

Тестирование приложения выполняется путем запуска разных наборов тестов, например,
на вход поступает две строки - целое число минут и целое число часов.
650
10
Программа должна вывести на экран число часов Clock и целое число минут (int)
с использованием перегруженных операторов:
10
600

Никаких дополнительных символов выводиться не должно.

Код метода Main можно подвергнуть изменениям, но вывод меняться не должен.
*/

namespace Task03
{
    class Clock
    {
        private int hours;
        public int Hours
        {
            get => hours;
            set
            {
                if (value < 0)
                    throw new ArgumentException();
                hours = value;
            }
        }

        public static explicit operator int(Clock clock)
        {
            return clock.Hours * 60;
        }

        public static implicit operator Clock(int minutes)
        {
            if (minutes < 0)
                throw new ArgumentException();
            return new Clock { Hours = minutes / 60 };
        }

        public override string ToString() => hours.ToString();
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Clock clock = null;
            int minute = int.Parse(Console.ReadLine());
            try
            {
                clock = new Clock { Hours = int.Parse(Console.ReadLine()) };
                Console.WriteLine((Clock)minute);
                Console.WriteLine((int)clock);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
            }
        }
    }
}
