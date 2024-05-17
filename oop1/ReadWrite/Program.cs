 using System;
 using System.IO;

 class Program
 {
     static void Main()
    {
         // Запись в файл
         File.WriteAllText("file.txt", "Hello, World!");

         // Чтение из файла
         string readText = File.ReadAllText("file.txt");
         Console.WriteLine(readText);
     }
 }