using System;

public class TryCatch
{
    public static void Main()
    {
        try
        {
            // Попытка выполнить код, который может вызвать исключение
            Console.WriteLine("Введите число:");
            string input = Console.ReadLine();
            int number = int.Parse(input);

            Console.WriteLine($"Вы ввели число: {number}");
        }
        catch (FormatException ex)
        {
            // Обработка исключения формата (например, если введен текст вместо числа)
            Console.WriteLine("Ошибка: Введенное значение не является числом.");
            Console.WriteLine($"Подробности: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Обработка любых других исключений
            Console.WriteLine("Произошла ошибка.");
            Console.WriteLine($"Подробности: {ex.Message}");
        }
        finally
        {
            // Код, который выполняется в любом случае, независимо от того, было исключение или нет
            Console.WriteLine("Завершение программы.");
        }
    }
}
