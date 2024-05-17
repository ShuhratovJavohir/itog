using System;

//Базовый класс
         public abstract class Animal
{
    public abstract void Speak();
}

//Производный класс
         public class Dog : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Гав!");
    }
}

//Еще один производный класс
         public class Cat : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Мяу!");
    }
}

class Program
{
    static void Main()
    {
        //Создаем объекты классов Dog и Cat
                 Animal myDog = new Dog();
        Animal myCat = new Cat();

        //Вызываем метод Speak для каждого объекта
                 myDog.Speak();
                 myCat.Speak();
             }
}
