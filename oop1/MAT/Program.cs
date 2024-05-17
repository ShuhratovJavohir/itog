using System;
using System.IO;

public class MAT
{
    private int[,] matrix;

    public MAT(int[,] matrix)
    {
        this.matrix = matrix;
    }

    public int MaxElement()
    {
        int max = matrix[0, 0];
        foreach (int i in matrix)
        {
            if (i > max)
                max = i;
        }
        return max;
    }

    public int MinElement()
    {
        int min = matrix[0, 0];
        foreach (int i in matrix)
        {
            if (i < min)
                min = i;
        }
        return min;
    }

    public int SumOfRow(int row)
    {
        int sum = 0;
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            sum += matrix[row, i];
        }
        return sum;
    }
}

class Program
{
    static void Main()
    {
        //Создаем новую матрицу
                 int[,] matrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

        //Создаем экземпляр класса MAT
                 MAT mat = new MAT(matrix);

        //Вызываем методы класса MAT и выводим результаты
                 Console.WriteLine("Максимальный элемент: " + mat.MaxElement());
        Console.WriteLine("Минимальный элемент: " + mat.MinElement());
        Console.WriteLine("Сумма элементов первой строки: " + mat.SumOfRow(0));
    }
}
