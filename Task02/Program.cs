using System;

/*
Источник: https://metanit.com/

Есть класс State, который представляет государство.
Добавьте в класс оператор сложения, который бы позволял объединять государства (складывается и площадь, и население).
А также операторы сравнения < и > для сравнения государств по плотности населения (число людей / площадь).
На вход программы поступает информация о двух странах. Необходимо вывести через пробел площадь и
население большей страны. Затем объединить эти две страны в одну и вывести через пробел её
площадь и население.
Обработайте ситуации, когда население и площадь отрицательны, а также случай, когда площадь равна 0
(в этом случае должен быть выброшен ArgumentException).

Тестирование приложения выполняется путем запуска разных наборов тестов, например,
на вход поступает две строки (первая строка - это площадь и население первой страны,
вторая строка - это площадь и население второй страны).
10 10
200 20
Программа должна вывести на экран:
200 20
210 30

Никаких дополнительных символов выводиться не должно.

Код метода Main можно подвергнуть изменениям, но вывод меняться не должен.
*/

namespace Task02
{
    class State
    {
        public decimal Population
        {
            get
            {
                return Population;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException();
                else
                    Population = value;
            }
        }
        public decimal Area
        {
            get
            {
                return Area;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException();
                else
                    Area = value;
            }
        }

        public static State operator +(State left, State right)
        {
            return new State { Area = left.Area + right.Area, Population = left.Population + right.Population };
        }

        public static bool operator <(State left, State right)
        {
            if (left.Population / left.Area > right.Population / right.Area)
                return true;
            else
                return false;
        }

        public static bool operator >(State left, State right)
        {
            if (left.Population / left.Area < right.Population / right.Area)
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return $"{Area} {Population}";
        }
    }

    class MainClass
    {
        public static void Main()
        {
            string[] strs = Console.ReadLine().Split();
            try
            {
                State state1 = new State { Area = int.Parse(strs[0]), Population = int.Parse(strs[1]) };
                strs = Console.ReadLine().Split();
                State state2 = new State { Area = int.Parse(strs[0]), Population = int.Parse(strs[1]) };

                if (state1 > state2)
                {
                    Console.WriteLine(state1);
                }
                else
                {
                    Console.WriteLine(state2);
                }

                State state3 = state1 + state2;
                Console.WriteLine(state3);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
            }
        }
    }
}
