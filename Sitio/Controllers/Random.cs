using System;

class Program
{
    static void Main(string[] args)
    {
        int n = 10; 

        Console.WriteLine("Secuencia de Fibonacci:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(Fibonacci(i) + " ");
        }
    }

    static int Fibonacci(int n)
    {
        if (n <= 1)
        {
            return n;
        }
        else
        {
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}