using System;

public class SIS_SCHIS
{
    protected double[] coefficients;

    public SIS_SCHIS(double[] coefficients)
    {
        this.coefficients = coefficients;
    }

    public string ToBinary()
    {
        return Convert.ToString((long)coefficients[0], 2);
    }

    public (int Zeros, int Ones) CountZerosAndOnes()
    {
        string binary = ToBinary();
        int zeros = binary.Split('0').Length - 1;
        int ones = binary.Split('1').Length - 1;
        return (zeros, ones);
    }
}

public class RESULT : SIS_SCHIS
{
    public RESULT(double[] coefficients) : base(coefficients) { }

    public double[] Derivative(int order)
    {
        double[] result = (double[])coefficients.Clone();

        for (int i = 0; i < order; i++)
        {
            for (int j = 0; j < result.Length - 1; j++)
            {
                result[j] = result[j + 1] * (j + 1);
            }
            Array.Resize(ref result, result.Length - 1);
        }

        return result;
    }

    public double CalculateDerivative(double x, int order)
    {
        double[] derivativeCoefficients = Derivative(order);
        double result = 0;

        for (int i = 0; i < derivativeCoefficients.Length; i++)
        {
            result += derivativeCoefficients[i] * Math.Pow(x, i);
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        //Создаем новый объект класса SIS_SCHIS
       SIS_SCHIS num = new SIS_SCHIS(new double[] { 1024 });
        Console.WriteLine("Двоичное представление: " + num.ToBinary());
        var (zeros, ones) = num.CountZerosAndOnes();
        Console.WriteLine("Количество нулей: " + zeros);
        Console.WriteLine("Количество единиц: " + ones);

        //Создаем новый объект класса RESULT
       RESULT numShift = new RESULT(new double[] { 1024 });
        Console.WriteLine("Производная первого порядка: " + numShift.CalculateDerivative(2, 1));
    }
}
