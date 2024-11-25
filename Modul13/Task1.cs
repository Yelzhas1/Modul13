using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        // Путь к текстовому файлу
        string filePath = "C:\\Users\\Diana\\Documents\\Text1.txt";

        try
        {
            string text = File.ReadAllText(filePath);

            int[] numbers = Array.ConvertAll(text.ToCharArray(), c => (int)c);

            const int itemCount = 100000; 

            // 1. Тестируем List<T>
            List<int> list = new List<int>();
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            foreach (var num in numbers)
            {
                list.Insert(list.Count / 2, num);
            }
            stopwatch.Stop();
            Console.WriteLine($"List<T>: Вставка {numbers.Length} элементов заняла {stopwatch.ElapsedMilliseconds} ms");

            // 2. Тестируем LinkedList<T>
            LinkedList<int> linkedList = new LinkedList<int>();

            stopwatch.Reset();
            stopwatch.Start();
            var node = linkedList.First;
            foreach (var num in numbers)
            {
                if (node == null)
                {
                    linkedList.AddFirst(num);
                }
                else
                {
                    linkedList.AddAfter(node, num);
                    node = node.Next;
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"LinkedList<T>: Вставка {numbers.Length} элементов заняла {stopwatch.ElapsedMilliseconds} ms");

            Console.WriteLine("Тест завершен.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}

//List<T>: Вставка 933318 элементов заняла 25010 ms
//LinkedList<T>: Вставка 933318 элементов заняла 120 ms
//Тест завершен.