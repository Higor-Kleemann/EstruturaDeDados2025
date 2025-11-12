int [] numeros = new int [] {1,52,34,56,7,2,3,8,9,10};
int numero=0;
bool encontrado = false;

Console.WriteLine("Informe um número para ser procurado no vetor: ");
numero = int.Parse(Console.ReadLine());

for(int i = 0; i < numeros.Length; i++)
{
    if(numeros[i] == numero)
    {
        Console.WriteLine($"Número encontrado na posição {i + 1}");
        encontrado = true;
    }
}

if(!encontrado)
{
    Console.WriteLine("O número não foi encontrado.");
}