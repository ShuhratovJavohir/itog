//Базовый класс
         public class Animal
{
    public string Name { get; set; }

    public void Eat()
    {
        Console.WriteLine(Name + " ест.");
    }
}

//Производный класс
         public class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine(Name + " гавкает.");
    }
}

class Program
{
    static void Main()
    {
       // Создаем новый объект класса Dog
       Dog myDog = new Dog();
        myDog.Name = "Бобик";

        //Вызываем методы класса Dog и базового класса Animal
                 myDog.Eat();
        myDog.Bark();
    }
}
