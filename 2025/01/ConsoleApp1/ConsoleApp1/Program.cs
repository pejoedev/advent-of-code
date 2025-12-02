// See https://aka.ms/new-console-template for more information
using System.IO;

long index = 50;
long amountOfZeros = 0;
foreach (string line in File.ReadLines("../../../input.txt"))
{
    Console.WriteLine(line);
    string character = line.Substring(0,1);
    string amountString = line.Substring(1,line.Length -1);
    long amount = Int64.Parse(amountString);
    if (character == "L")
    {
        index -= amount;
    }
    else
    {
        index += amount;
    }
    index = index % 100;
    if (index < 0)
    {
        index += 100;
    }
    if (index >= 100)
    {
        index -= 100;
    }
    
    if (index == 0)
    {
        amountOfZeros++;
    }
    Console.WriteLine("Index: " + index + ", Amount: " + amountOfZeros);
}
