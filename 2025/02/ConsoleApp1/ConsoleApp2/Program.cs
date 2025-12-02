// See https://aka.ms/new-console-template for more information
using System.IO;

long invalidTotal = 0;
string content = File.ReadAllText("../../../input.txt");
Console.WriteLine(content);
Console.WriteLine("Hello, World!");
string[] ranges = content.Split(",");
foreach (string range in ranges)
{
    string[] keys = range.Split("-");
    long key1 = Int64.Parse(keys[0]);
    long key2 = Int64.Parse(keys[1]);
    // Console.WriteLine(key1 + " != " + key2);
    for (int i = 0; i < key2 - key1 + 1; i++)
    {
        // checking each key
        int lengthOfKey = $"{key1 + i}".Length;
        for (int j = 1; j < lengthOfKey + 1; j++)
        {
            // checking the key at different scanning sizes
            if (lengthOfKey % j != 0 || lengthOfKey == j) continue;
            // Console.WriteLine("Checking for a length of " + j);
            string firstHalf = $"{key1 + i}".Substring(0,j);
            bool isValid = true;
            for (int k = 1; k < (lengthOfKey / j); k++)
            {
                // checking the key at each index with a certain length
                if (!isValid) continue;
                if ($"{key1 + i}".Substring(k * j, j) != firstHalf)
                {
                    isValid = false;
                    // Console.WriteLine($"Failed at {key1 + i} with {firstHalf} as key, {$"{key1 + i}".Substring(k, j)} != '{firstHalf}'");
                    break;
                    // try a longer num
                }
                // Console.WriteLine("Need to check this again at index " + (k * j));
            }

            if (isValid)
            {
                Console.WriteLine($"Found: {key1 + i}");
                invalidTotal += key1 + i;
                break;
            }
        }
    }
}
Console.WriteLine("Total: " + invalidTotal);