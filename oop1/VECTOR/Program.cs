using System;

public class MAT
{
    protected int[,] matrix;

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

public class VEKTOR : MAT
{
    private int[] vector;

    public VEKTOR(int[,] matrix, int[] vector) : base(matrix)
    {
        this.vector = vector;
    }

    public int[] Multiply()
    {
        int[] result = new int[vector.Length];
        for (int i = 0; i < vector.Length; i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                result[i] += vector[j] * matrix[j, i];
            }
        }
        return result;
    }
}

class Program
{
    static void Main()
    {
        //Создаем новую матрицу и вектор
                 int[,] matrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        int[] vector = new int[] { 1, 2, 3 };

        //Создаем экземпляр класса VEKTOR
                 VEKTOR vektor = new VEKTOR(matrix, vector);

        //Вызываем метод Multiply и выводим результат
                 int[] result = vektor.Multiply();
        Console.WriteLine("Результат умножения: " + string.Join(", ", result));
    }
}
