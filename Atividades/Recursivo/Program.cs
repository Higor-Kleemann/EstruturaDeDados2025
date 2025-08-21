static void Main(string[] args)
    {
        int x = 3;
        fun2(x);
        Console.ReadKey();
    }

    static void fun2(int n)
    {
        if (n > 0)
        {
            fun2(n - 1);
            Console.Write($"{n} ");
        }
    }

    {
    int x = 5;
    Console.WriteLine($"O Fatorial de {x} é {factorial(x)}");
    Console.ReadKey();
    }

static int factorial(int number)
    {
        if (number == 1)
        {
            return (1);
        }
        else
        {
            return(number*factorial(number - 1)); 
        }
    }