
using System;

 class Program
 {
     static void Main(string[] args)
     {
         Console.WriteLine("Generate equations for addition and subtraction:");
         var random = new Random();
         for (int i = 0; i < 5; i++)
         {
             int position1 = random.Next(1, 100);
             int position2 = random.Next(1, 100);
             Console.WriteLine($"{position1} + {position2} = {position1 + position2}");
             Console.WriteLine($"{position1} - {position2} = {position1 - position2}");
         }
    
     }
 }
