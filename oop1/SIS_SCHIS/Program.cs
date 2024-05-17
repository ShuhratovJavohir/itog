using System;

public class SIS_SCHIS
{
    private string binaryRepresentation;

    // Метод для преобразования десятичного числа в двоичное
    public void ConvertToBinary(int decimalNumber)
    {
        binaryRepresentation = Convert.ToString(decimalNumber, 2);
        Console.WriteLine($"Двоичное представление числа {decimalNumber}: {binaryRepresentation}");
    }

    // Метод для определения количества нулей и единиц в двоичном числе
    public void CountZerosAndOnes(out int zeros, out int ones)
    {
        zeros = 0;
        ones = 0;

        foreach (char c in binaryRepresentation)
        {
            if (c == '0')
            {
                zeros++;
            }
            else if (c == '1')
            {
                ones++;
            }
        }
    }
}

public class Program
{
    public static void Main()
    {
        SIS_SCHIS converter = new SIS_SCHIS();

        
        int decimalNumber = 42;
        converter.ConvertToBinary(decimalNumber);

        int zeros, ones;
        converter.CountZerosAndOnes(out zeros, out ones);

        Console.WriteLine($"Количество нулей: {zeros}");
        Console.WriteLine($"Количество единиц: {ones}");
    }
}
