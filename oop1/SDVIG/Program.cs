using System;

public class SIS_SCHIS
{
    protected long number;

    public SIS_SCHIS(long number)
    {
        this.number = number;
    }

    public string ToBinary()
    {
        return Convert.ToString(number, 2);
    }

    public (int Zeros, int Ones) CountZerosAndOnes()
    {
        string binary = ToBinary();
        int zeros = binary.Split('0').Length - 1;
        int ones = binary.Split('1').Length - 1;
        return (zeros, ones);
    }
}

public class SDVIG : SIS_SCHIS
{
    public SDVIG(long number) : base(number) { }

    public long ShiftLeft(int positions)
    {
        return number << positions;
    }

    public long ShiftRight(int positions)
    {
        return number >> positions;
    }
}

class Program
{
    static void Main()
    {
        //Создаем новый объект класса SIS_SCHIS
       SIS_SCHIS num = new SIS_SCHIS(1024);
        Console.WriteLine("Двоичное представление: " + num.ToBinary());
        var (zeros, ones) = num.CountZerosAndOnes();
        Console.WriteLine("Количество нулей: " + zeros);
        Console.WriteLine("Количество единиц: " + ones);

        //Создаем новый объект класса SDVIG
       SDVIG numShift = new SDVIG(1024);
        Console.WriteLine("Сдвиг влево: " + numShift.ShiftLeft(1));
        Console.WriteLine("Сдвиг вправо: " + numShift.ShiftRight(1));
    }
}
