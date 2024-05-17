using System;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            RationalNumber number1 = new RationalNumber(1, 2, 3);
            RationalNumber number2 = new RationalNumber(4, 5, 6);
            RationalNumber result = number1.Add(number2);

            Console.WriteLine("Result: {0} {1}/{2}", result.GetWholePart(), result.GetNumerator(), result.GetDenominator());
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}

public class RationalNumber
{
    private int wholePart;
    private int numerator;
    private int denominator;

    // Конструктор по умолчанию
    public RationalNumber()
    {
        wholePart = 0;
        numerator = 0;
        denominator = 1;
    }

    // Конструктор копирования
    public RationalNumber(RationalNumber other)
    {
        wholePart = other.wholePart;
        numerator = other.numerator;
        denominator = other.denominator;
    }

    // Конструктор с несколькими параметрами
    public RationalNumber(int wholePart, int numerator, int denominator)
    {
        this.wholePart = wholePart;
        this.numerator = numerator;
        SetDenominator(denominator); // Используем функцию задания знаменателя для обработки исключений
        Simplify();
    }

    // Функции получения значений закрытых данных-членов
    public int GetWholePart() => wholePart;
    public int GetNumerator() => numerator;
    public int GetDenominator() => denominator;

    // Функции задания значений закрытым данным-членам
    public void SetWholePart(int wholePart)
    {
        this.wholePart = wholePart;
    }

    public void SetNumerator(int numerator)
    {
        this.numerator = numerator;
        Simplify();
    }

    public void SetDenominator(int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        this.denominator = denominator;
        Simplify();
    }

    // Функция для операции (суммировать, отнимать, …) двух рациональных чисел
    public RationalNumber Add(RationalNumber other)
    {
        int totalNumerator = (wholePart * denominator + numerator) * other.denominator
                            + (other.wholePart * other.denominator + other.numerator) * denominator;
        int totalDenominator = denominator * other.denominator;

        RationalNumber result = new RationalNumber(0, totalNumerator, totalDenominator);
        result.Simplify();
        return result;
    }

    // Метод для упрощения дроби
    private void Simplify()
    {
        if (numerator >= denominator)
        {
            wholePart += numerator / denominator;
            numerator = numerator % denominator;
        }

        int gcd = GCD(numerator, denominator);
        numerator /= gcd;
        denominator /= gcd;
    }

    // Метод для вычисления наибольшего общего делителя
    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int t = b;
            b = a % b;
            a = t;
        }
        return a;
    }

    // Деструктор
    ~RationalNumber()
    {
        // Освобождение ресурсов
    }
}
