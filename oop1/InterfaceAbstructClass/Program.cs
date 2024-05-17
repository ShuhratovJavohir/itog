using System;

//Интерфейс
         public interface IAnimal
{
    void Speak();
}

//Абстрактный класс
         public abstract class Animal : IAnimal
{
    protected string name;

    public Animal(string name)
    {
        this.name = name;
    }

    public abstract void Speak();
}

//Класс, наследующий от абстрактного класса
         public class Dog : Animal
{
    public Dog(string name) : base(name) { }

    public override void Speak()
    {
        Console.WriteLine(name + " говорит: Гав!");
    }
}

class Program
{
    static void Main()
    {
        //Создаем новый объект класса Dog
       Dog myDog = new Dog("Бобик");

        //Вызываем метод Speak
                 myDog.Speak();
    }
}
