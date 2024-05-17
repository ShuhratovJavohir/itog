using System;
public class Многочлен
{
    private int степень;
    private double[] коэффициенты;

    public Многочлен()
    {
        степень = 0;
        коэффициенты = new double[1] { 0 };
    }

    public Многочлен(Многочлен другой)
    {
        степень = другой.степень;
        коэффициенты = new double[степень + 1];
        for (int i = 0; i <= степень; i++)
        {
            коэффициенты[i] = другой.коэффициенты[i];
        }
    }

    public Многочлен(int степень, double[] коэффициенты)
    {
        this.степень = степень;
        this.коэффициенты = new double[степень + 1];
        for (int i = 0; i <= степень; i++)
        {
            this.коэффициенты[i] = коэффициенты[i];
        }
    }

    public double ВычислитьЗначение(double x)
    {
        double результат = 0;
        for (int i = 0; i <= степень; i++)
        {
            результат += коэффициенты[i] * System.Math.Pow(x, i);
        }
        return результат;
    }

    public static Многочлен operator *(Многочлен многочлен, double число)
    {
        Многочлен результат = new Многочлен(многочлен);
        for (int i = 0; i <= результат.степень; i++)
        {
            результат.коэффициенты[i] *= число;
        }
        return результат;
    }

    ~Многочлен()
    {
        // Освобождение ресурсов
    }
}

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            Многочлен многочлен = new Многочлен(2, new double[] { 1, 2, 3 });
            double значение = многочлен.ВычислитьЗначение(2);
            System.Console.WriteLine("Значение многочлена при x = 2: " + значение);

            Многочлен умноженныйМногочлен = многочлен * 2;
            значение = умноженныйМногочлен.ВычислитьЗначение(2);
            System.Console.WriteLine("Значение умноженного многочлена при x = 2: " + значение);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Произошла ошибка: " + ex.Message);
        }
    }
}