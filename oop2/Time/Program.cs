using System;

public class Time
{
    private int hours;
    private int minutes;
    private int seconds;

    // Конструктор по умолчанию
    public Time()
    {
        hours = 0;
        minutes = 0;
        seconds = 0;
    }

    // Конструктор копирования
    public Time(Time other)
    {
        hours = other.hours;
        minutes = other.minutes;
        seconds = other.seconds;
    }

    // Конструктор с несколькими параметрами
    public Time(int hours, int minutes, int seconds)
    {
        this.hours = hours;
        this.minutes = minutes;
        this.seconds = seconds;
    }

    // Функции получения значений закрытых данных-членов
    public int GetHours() => hours;
    public int GetMinutes() => minutes;
    public int GetSeconds() => seconds;

    // Функции задания значений закрытым данным-членам
    public void SetHours(int hours) => this.hours = hours;
    public void SetMinutes(int minutes) => this.minutes = minutes;
    public void SetSeconds(int seconds) => this.seconds = seconds;

    // Функция для операции (суммировать, отнимать, …) двух времени.
    public Time Add(Time other)
    {
        int totalSeconds = seconds + other.seconds;
        int totalMinutes = minutes + other.minutes + totalSeconds / 60;
        int totalHours = hours + other.hours + totalMinutes / 60;
        return new Time(totalHours % 24, totalMinutes % 60, totalSeconds % 60);
    }

    // Деструктор
    ~Time()
    {
        // Освобождение ресурсов
    }
}

class Program
{
    static void Main(string[] args)
    {
        Time time1 = new Time(10, 30, 0);
        Time time2 = new Time(2, 45, 0);
        Time sum = time1.Add(time2);
        Console.WriteLine($"Hours: {sum.GetHours()}, Minutes: {sum.GetMinutes()}, Seconds: {sum.GetSeconds()}");
    }
}
