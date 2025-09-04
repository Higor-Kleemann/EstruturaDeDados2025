using System.Collections.Generic;

Console.WriteLine("Invertendo palavras com pilhas (Stacks)");
Console.WriteLine("Escreva uma palavra: ");
string palavra = Console.ReadLine();
Stack<char> chars = new Stack<char>();

foreach (var c in palavra)
{
    chars.Push(c);
}

string palavra_Invertida = string.Empty;

while (chars.Count > 0)
{
    char c = chars.Pop();
    palavra_Invertida += c;
}

if (palavra == palavra_Invertida)
{
    Console.WriteLine($"A palavra {palavra} é um palíndromo");
}
else
{
    Console.WriteLine($"A palavra {palavra} não é um palíndromo");
}