using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static string[] inputLines;
    static int maxWidth;
    static long endings = 0;
    
    // Use a struct for state to avoid allocations
    struct State
    {
        public bool[] data;
        public int length;
        
        public State(int capacity)
        {
            data = new bool[capacity];
            length = 0;
        }
        
        public State(bool[] source, int len)
        {
            data = new bool[len];
            Array.Copy(source, data, len);
            length = len;
        }
        
        public bool Equals(State other)
        {
            if (length != other.length) return false;
            for (int i = 0; i < length; i++)
                if (data[i] != other.data[i]) return false;
            return true;
        }
        
        public override int GetHashCode()
        {
            int hash = length;
            for (int i = 0; i < length; i++)
                if (data[i]) hash ^= i.GetHashCode();
            return hash;
        }
    }

    static void Main()
    {
        inputLines = File.ReadAllLines("../../../input.txt");
        maxWidth = inputLines[0].Length;
        
        bool[] initial = new bool[maxWidth];
        for (int i = 0; i < maxWidth; i++)
            initial[i] = inputLines[0][i] == 'S';
        
        State initialState = new State(initial, maxWidth);
        RunState(initialState, 0);
        
        Console.WriteLine($"Total endings: {endings}");
    }

    static void RunState(State groundTruth, int index)
    {
        State current1 = new State(maxWidth);
        State current2 = new State(maxWidth);
        int ignoreIf = -1;
        
        string line = inputLines[index];
        
        for (int j = 0; j < maxWidth; j++)
        {
            if (groundTruth.data[j])
            {
                if (line[j] == '^')
                {
                    ignoreIf = j + 1;
                    if (current1.length > 0)
                        current1.length--;
                    current1.data[current1.length++] = true;
                    current1.data[current1.length++] = false;
                    
                    if (ignoreIf != j)
                    {
                        current2.data[current2.length++] = false;
                        current2.data[current2.length++] = true;
                    }
                }
                else
                {
                    current1.data[current1.length++] = true;
                    if (ignoreIf != j)
                        current2.data[current2.length++] = true;
                }
            }
            else
            {
                current1.data[current1.length++] = false;
                if (ignoreIf != j)
                    current2.data[current2.length++] = false;
            }
        }
        
        if (index + 1 == inputLines.Length)
        {
            endings++;
            if (endings % 100000 == 0)
                Console.WriteLine($"Found {endings} endings...");
            return;
        }
        
        if (current1.Equals(current2))
        {
            RunState(current1, index + 1);
        }
        else
        {
            RunState(current1, index + 1);
            if (current2.length > 0)
                RunState(current2, index + 1);
        }
    }
}