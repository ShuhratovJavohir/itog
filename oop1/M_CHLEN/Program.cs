using System;

public class M_CHLEN
{
    private double[] coefficients;

    public M_CHLEN(double[] coefficients)
    {
        this.coefficients = coefficients;
    }

    public double Calculate(double x)
    {
        double result = 0;
        for (int i = 0; i < coefficients.Length; i++)
        {
            result += coefficients[i] * Math.Pow(x, i);
        }
        return result;
    }
}

class Program
{
    static void Main()
    {
        //Создаем новый объект класса M_CHLEN
       M_CHLEN polynomial = new M_CHLEN(new double[] { 1, 2, 3 });


                  //Вычисляем значение многочлена для x = 2
                 double result = polynomial.Calculate(2);
        Console.WriteLine("Результат: " + result);
    }
}
