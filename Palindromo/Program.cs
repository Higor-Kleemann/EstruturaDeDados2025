using System.Collections.Generic;

Console.WriteLine("Identificando um Palíndromo");
Console.WriteLine("Digite uma palavra: ");
string ?palavra = Console.ReadLine().ToLower();

char[] array = palavra!.ToCharArray();

Array.Reverse(array);
string palavraInvertida = new string(array);
if (palavra == palavraInvertida)
{
    Console.WriteLine("A palavra é um palíndromo.");
}
else
{
    Console.WriteLine("A palavra não é um palíndromo.");
}
Console.ReadLine();




