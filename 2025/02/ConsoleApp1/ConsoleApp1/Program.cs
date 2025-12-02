// See https://aka.ms/new-console-template for more information
using System.IO;

int invalidTotal = 0;
string content = File.ReadAllText("../../../input.txt");
Console.WriteLine(content);
Console.WriteLine("Hello, World!");
string[] ranges = content.Split(",");
foreach (string range in ranges)
{
    string[] keys = range.Split("-");
    int key1 = Int32.Parse(keys[0]);
    int key2 = Int32.Parse(keys[1]);
    // Console.WriteLine(key1 + " != " + key2);
    for (int i = 0; i < key2 - key1 + 1; i++)
    {
        int lenght = $"{key1 + i}".Length;
        if (lenght % 2 != 0) continue;
        // Console.WriteLine(key1 + i);
        string firstHalf = $"{key1 + i}".Substring(0,lenght / 2);
        string secondHalf = $"{key1 + i}".Substring(lenght / 2,lenght / 2);
        if (firstHalf == secondHalf)
        {
            Console.WriteLine($"{firstHalf} + {secondHalf} = {firstHalf + secondHalf}");
            invalidTotal += (key1 + i);
        }
    }
}
Console.WriteLine("Total:  " + invalidTotal);

