using System;

public class ComplexNumber
{
    private double real;
    private double imaginary;

    // Конструктор по умолчанию
    public ComplexNumber()
    {
        real = 0;
        imaginary = 0;
    }

    // Конструктор копирования
    public ComplexNumber(ComplexNumber other)
    {
        real = other.real;
        imaginary = other.imaginary;
    }

    // Конструктор с несколькими параметрами
    public ComplexNumber(double real, double imaginary)
    {
        this.real = real;
        this.imaginary = imaginary;
    }

    // Функции получения значений закрытых данных-членов
    public double GetReal() => real;
    public double GetImaginary() => imaginary;

    // Функции задания значений закрытым данным-членам
    public void SetReal(double real) => this.real = real;
    public void SetImaginary(double imaginary) => this.imaginary = imaginary;

    // Функция для операции (суммировать, отнимать, …) двух комплексных чисел
    public ComplexNumber Add(ComplexNumber other)
    {
        return new ComplexNumber(real + other.real, imaginary + other.imaginary);
    }

    // Деструктор
    ~ComplexNumber()
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
            ComplexNumber number1 = new ComplexNumber(1, 2);
            ComplexNumber number2 = new ComplexNumber(3, 4);
            ComplexNumber result = number1.Add(number2);

            System.Console.WriteLine("Result: {0} + {1}i", result.GetReal(), result.GetImaginary());
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Произошла ошибка: " + ex.Message);
        }
    }
}
