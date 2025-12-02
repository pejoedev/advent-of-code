// See https://aka.ms/new-console-template for more information
using System.IO;

long index = 50;
long amountOfZeros = 0;
foreach (string line in File.ReadLines("../../../input.txt"))
{
    long lastIndex = index;
    string character = line.Substring(0,1);
    string amountString = line.Substring(1,line.Length -1);
    long amount = Int64.Parse(amountString);
    if (amount == 0)
    {
        continue;
    }
    if (character == "L")
    {
        index -= amount;
    }
    else if (character == "R")
    {
        index += amount;
    }

    while (index > 100)
    {
        index -= 100;
        amountOfZeros++;
    }
    while (index < 0)
    {
        index += 100;
        if (lastIndex != 0)
        {
            amountOfZeros++;
        }
    }

    if (index == 100)
    {
        index = 0;
    }
    
    if (index == 0)
    {
        amountOfZeros++;
    }
    if (character == "L")
    {
        Console.WriteLine("Last Index: " + lastIndex + ", Line: " + line + ", Index: " + index + 
                          ", Amount: " + amountOfZeros + ", calc: " + lastIndex + " - " + amount + " = " + (lastIndex - amount) + (lastIndex - amount <= 0 ? ", upgrade = true": ""));
    }
    else if (character == "R")
    {
        Console.WriteLine("Last Index: " + lastIndex + ", Line: " + line + ", Index: " + index + 
                          ", Amount: " + amountOfZeros + ", calc: " + lastIndex + " + " + amount + " = " + (lastIndex + amount) + (lastIndex + amount >= 100 ? ", upgrade = true": ""));
    }
}