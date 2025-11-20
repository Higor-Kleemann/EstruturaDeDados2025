using System.Collections;

/*
A tabela hash é baseada no conceito de par chave - valor
a chave é a forma e se acessar o respectivo valor
e o por ser chave, deve ser única. 
*/

Hashtable ht = new Hashtable()
{
    {"Mauricio Gonzatto", "123"},
    {"Mauricio de Souza", "456"}
};

//Uma forma de adicionar um novo par 
ht ["Mauricio Mattar"] = "789";
ht.Add("Mauricio de Nassau", "666");

//Verificar se existem pares chave-valor na tabela hash
if(ht.Count > 0)
{
    //Percorrendo os pares armazenados
    foreach (DictionaryEntry entry in ht)
    {
        Console.WriteLine($"Chave: {entry.Key}, Valor: {entry.Value}");
    }
} else
{
    Console.WriteLine("Tabela Hash vazia");
}

// Vimos que ao adicionar uma chave repetida à HashTable o programa crasha e interrompe a execução.
// Para evitar esse comportamento fazemos uso da cláusula (sentença) try {} catch {}

try{
    ht.Add("Mauricio de Nassau", "666");
}

catch(ArgumentException ex2){
    Console.WriteLine("Não é possível adicionar chaves iguais.");
}

catch(Exception ex){
    Console.WriteLine("Erro desconhecido");
}

finally{
    Console.WriteLine("Agora vai! Segue em frente");
}

// Agora o usuário vai informar
Console.WriteLine("Informe a chave: ");
string key = Console.ReadLine();
Console.WriteLine("Informe o valor: ");
string value = Console.ReadLine();

try
{
    ht.Add(key, value);
    Console.WriteLine("Par chave-valor acionado!");

}
catch
{
    Console.WriteLine("Ops! Chave já existente.");
}

// Agora faremos uma busca na Tabela Hash
Console.WriteLine("O que procuras cabrón?");
string search = Console.ReadLine();

if (ht.Contains(search))
{
    Console.WriteLine($"Encontrado! {search}, {ht[search]}");
}
else
{
    Console.WriteLine("Non ecxiste!");
}

