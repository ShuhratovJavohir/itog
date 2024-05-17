using System;
using System.Numerics;

public class KOMPLEKS
{
    protected Complex number;

    public KOMPLEKS(string complexNumber)
    {
        var parts = complexNumber.Split('+');
        var realPart = double.Parse(parts[0]);
        var imaginaryPart = double.Parse(parts[1].TrimEnd('i'));
        this.number = new Complex(realPart, imaginaryPart);
    }

    public Complex Add(KOMPLEKS other)
    {
        return this.number + other.number;
    }

    public Complex Subtract(KOMPLEKS other)
    {
        return this.number - other.number;
    }

    public Complex Multiply(KOMPLEKS other)
    {
        return this.number * other.number;
    }
}

public class URAVNENIE : KOMPLEKS
{
    public URAVNENIE(string complexNumber) : base(complexNumber) { }

    public Complex[] SolveQuadratic()
    {
        Complex a = 1;
        Complex b = -this.number;
        Complex c = 1;

        Complex discriminant = b * b - 4 * a * c;
        Complex sqrtDiscriminant = Complex.Sqrt(discriminant);

        Complex root1 = (-b + sqrtDiscriminant) / (2 * a);
        Complex root2 = (-b - sqrtDiscriminant) / (2 * a);

        return new Complex[] { root1, root2 };
    }
}

class Program
{
    static void Main()
    {
        //Создаем новые комплексные числа
                 KOMPLEKS num1 = new KOMPLEKS("1+2i");
        KOMPLEKS num2 = new KOMPLEKS("3+4i");

        //Выполняем операции и выводим результаты
                 Console.WriteLine("Сумма: " + num1.Add(num2));
        Console.WriteLine("Разность: " + num1.Subtract(num2));
        Console.WriteLine("Произведение: " + num1.Multiply(num2));

        //Создаем уравнение и решаем его
       URAVNENIE equation = new URAVNENIE("2+3i");
        Complex[] roots = equation.SolveQuadratic();
        Console.WriteLine("Корни уравнения: " + roots[0] + ", " + roots[1]);
    }
}