// See https://aka.ms/new-console-template for more information
using BubbleSort;

Console.Write("\n\nOrdenação com BubbleSort");
/*
int[] arrNumbers = new int[] { 99, 50, -24, 0, 1 };
*/

string[] alfabeto = new string[] { "Darius", "Battle", "Annie", "Carlos", "Ednaldo" };
foreach (var x in alfabeto)
{
    Console.Write($"\n[{x}] ");
}

var alfabetoOrdered = BubbleSortOrder.Sort<string>(alfabeto);
Console.Write("\n\nVetor Ordenado:");
foreach (var x in alfabeto)
{
    Console.Write($"\n[{x}] ");
}