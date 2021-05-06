using System;

/*
Источник: https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/operators/operator-overloading

Работа была частично взята из моего домашнего задания в системе Яндекс контест, ниу ВШЭ. Работа называлась Контест 11.
Автор: Максим Лейпунский.

Fraction - упрощенная структура, представляющая рациональное число.
Необходимо перегрузить операции:
+ (бинарный)
- (бинарный)
*
/ (в случае деления на 0, выбрасывать DivideByZeroException)

Тестирование приложения выполняется путем запуска разных наборов тестов, например,
на вход поступает две строки, содержацие числители и знаменатели двух дробей, разделенные /, соответственно.
1/3
1/6
Программа должна вывести на экран сумму, разность, произведение и частное двух дробей, соответственно,
с использованием перегруженных операторов (при необходимости, сокращать дроби):
1/2
1/6
1/18
2

Обратите внимание, если дробь имеет знаменатель 1, то он уничтожается (2/1 => 2). Если дробь в числителе имеет 0, то 
знаменатель также уничтожается (0/3 => 0).
Никаких дополнительных символов выводиться не должно.

Код метода Main можно подвергнуть изменениям, но вывод меняться не должен.
*/

public readonly struct Fraction
{
    private readonly int num;
    private readonly int den;

    public Fraction(int numerator, int denominator)
    {
        num = numerator;
        den = denominator;
    }

    public static Fraction Parse(string input)
    {
        string[] c = input.Split('/');
        if (c.Length == 1)
            return new Fraction(int.Parse(c[0]), 1);
        int numerator = int.Parse(c[0]);
        int denomenator = int.Parse(c[1]);
        return Simplify(new Fraction(numerator, denomenator));
    }

    public override string ToString()
    {
        if (den == 1)
            return num.ToString();
        if (den < 0)
            return -num+ "/" + -den;
        return num + "/" + den;
    }

    public static Fraction operator +(Fraction left, Fraction right)
    {
        int numLeft = left.num;
        int denLeft = left.den;
        int numRight = right.num;
        int denRight = right.den;
        numLeft *= denRight;
        numRight *= denLeft;
        denLeft = denRight *= denLeft;
        return Simplify(new Fraction(numRight + numLeft, denLeft));
    }

    public static Fraction operator -(Fraction left, Fraction right)
    {
        int numLeft = left.num;
        int denLeft = left.den;
        int numRight = right.num;
        int denRight = right.den;
        numLeft *= denRight;
        numRight *= denLeft;
        denLeft = denRight *= denLeft;
        return Simplify(new Fraction(numLeft - numRight, denLeft));
    }

    public static Fraction operator *(Fraction left, Fraction right)
    {
        return Simplify(new Fraction(left.num * right.num, left.den * right.den));
    }

    public static Fraction operator /(Fraction left, Fraction right)
    {
        if (right.den == 0)
            throw new DivideByZeroException();
        return Simplify(new Fraction(left.num * right.den, left.den * right.num));
    }

    private static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    private static Fraction Simplify(Fraction rational)
    {
        int gcd = GCD(rational.num, rational.den);
        return new Fraction(rational.num/ gcd, rational.den / gcd);
    }
}

public static class OperatorOverloading
{
    public static void Main()
    {
        try
        {
            Fraction fraction1 = Fraction.Parse(Console.ReadLine());
            Fraction fraction2 = Fraction.Parse(Console.ReadLine());
            Console.WriteLine(fraction1 + fraction2);
            Console.WriteLine(fraction1 - fraction2);
            Console.WriteLine(fraction1 * fraction2);
            Console.WriteLine(fraction1 / fraction2);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("error");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("zero");
        }
    }
}
