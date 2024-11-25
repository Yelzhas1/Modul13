using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Путь к текстовому файлу
        string filePath = "C:\\Users\\Diana\\Documents\\Text2.txt";

        try
        {
            string text = File.ReadAllText(filePath);

            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

            string[] words = noPunctuationText.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            words = words.Select(w => w.ToLower()).ToArray();

            var wordCounts = words.GroupBy(word => word)
                                  .Select(group => new { Word = group.Key, Count = group.Count() })
                                  .OrderByDescending(word => word.Count)
                                  .Take(10);            

            Console.WriteLine("Топ 10 наиболее часто встречающихся слов:");
            foreach (var word in wordCounts)
            {
                Console.WriteLine($"Слово: {word.Word}, Количество: {word.Count}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}

//Топ 10 наиболее часто встречающихся слов:
//Слово: и, Количество: 6026
//Слово: не, Количество: 3902
//Слово: в, Количество: 3525
//Слово: он, Количество: 2625
//Слово: что, Количество: 2412
//Слово: на, Количество: 2401
//Слово: с, Количество: 2036
//Слово: она, Количество: 1634
//Слово: а, Количество: 1574
//Слово: как, Количество: 1536