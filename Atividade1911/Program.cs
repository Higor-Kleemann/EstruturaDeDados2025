using System;
using System.Collections.Generic;
using System.Linq;

namespace GestaoEtiquetas
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,string> dicionarioRastreo = new Dictionary<string,string>();
            bool sair = false;

            Console.WriteLine("=== Sistema simples de Rastreio / Código de Barras ===");

            while(!sair)
            {
                Console.WriteLine();
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Inserir novo registro");
                Console.WriteLine("2 - Procurar por código de rastreio");
                Console.WriteLine("3 - Procurar por código da encomenda (barcode)");
                Console.WriteLine("4 - Listar todos os registros");
                Console.WriteLine("0 - Sair");
                Console.Write("Opcao: ");
                string op = Console.ReadLine();

                if(string.IsNullOrWhiteSpace(op)) { Console.WriteLine("Entrada vazia. Tentenovamente."); continue; }

                switch(op.Trim())
                {
                    case "1":
                        InserirRegistro(dicionarioRastreo);
                        break;
                    case "2":
                        BuscarPorRastreio(dicionarioRastreo);
                        break;
                    case "3":
                        BuscarPorBarcode(dicionarioRastreo);
                        break;
                    case "4":
                        ListarTodos(dicionarioRastreo);
                        break;
                    case "0":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Digite 0,1,2,3 ou 4.");
                        break;
                }
            }

            Console.WriteLine("Encerrando... Obrigado!");
        }

        static void InserirRegistro(Dictionary<string,string> dict)
        {
            Console.Write("Informe o codigo de rastreio: ");
            string rastreio = Console.ReadLine()?.Trim();

            if(string.IsNullOrWhiteSpace(rastreio))
            {
                Console.WriteLine("Código de rastreio inválido. Operação cancelada.");
                return;
            }

            if(dict.ContainsKey(rastreio))
            {
                Console.WriteLine($"Já existe um registro com o rastreio '{rastreio}'. Não será inserido novamente.");
                return;
            }

            Console.Write("Informe o codigo da encomenda (barcode): ");
            string barcode = Console.ReadLine()?.Trim();

            if(string.IsNullOrWhiteSpace(barcode))
            {
                Console.WriteLine("Código da encomenda inválido. Operação cancelada.");
                return;
            }

            
            if(dict.ContainsValue(barcode))
            {
                
                var ja = dict.FirstOrDefault(kvp => kvp.Value == barcode);
                if(!string.IsNullOrEmpty(ja.Key))
                {
                    Console.WriteLine($"ATENÇÃO: O barcode '{barcode}' já está associado ao rastreio '{ja.Key}'.");
                }
                else
                {
                    Console.WriteLine($"ATENÇÃO: O barcode '{barcode}' já está cadastrado.");
                }
                Console.WriteLine("Não será inserido para evitar duplicidade.");
                return;
            }

            // Tudo ok - insere
            dict.Add(rastreio, barcode);
            Console.WriteLine($"Registro inserido com sucesso: rastreio='{rastreio}', barcode='{barcode}'.");
        }

        
        static void BuscarPorRastreio(Dictionary<string,string> dict)
        {
            if(dict.Count == 0) { Console.WriteLine("Não há registros cadastrados."); return; }

            Console.Write("Digite o código de rastreio para buscar: ");
            string r = Console.ReadLine()?.Trim();
            if(string.IsNullOrWhiteSpace(r)) { Console.WriteLine("Entrada inválida."); return; }

            if(dict.TryGetValue(r, out string barcodeEncontrado))
            {
                Console.WriteLine("=== Resultado da busca ===");
                Console.WriteLine($"Rastreio: {r}");
                Console.WriteLine($"Codigo da encomenda (barcode): {barcodeEncontrado}");
            }
            else
            {
                Console.WriteLine($"Nenhum registro encontrado para o rastreio '{r}'.");
            }
        }

        static void BuscarPorBarcode(Dictionary<string,string> dict)
        {
            if(dict.Count == 0) { Console.WriteLine("Não há registros cadastrados."); return; }

            Console.Write("Digite o codigo da encomenda (barcode) para buscar: ");
            string b = Console.ReadLine()?.Trim();
            if(string.IsNullOrWhiteSpace(b)) { Console.WriteLine("Entrada inválida."); return; }

            var resultados = dict.Where(kvp => kvp.Value == b).ToList();

            if(resultados.Count == 0)
            {
                Console.WriteLine($"Nenhum registro encontrado para o barcode '{b}'.");
            }
            else
            {
                Console.WriteLine("=== Resultados encontrados ===");
                foreach(var item in resultados)
                {
                    Console.WriteLine($"Rastreio: {item.Key}  ->  barcode: {item.Value}");
                }
            }
        }

        static void ListarTodos(Dictionary<string,string> dict)
        {
            if(dict.Count == 0) { Console.WriteLine("Nenhum registro cadastrado."); return; }

            Console.WriteLine("=== Lista de todos os registros ===");
            foreach(var kvp in dict)
            {
                Console.WriteLine($"Rastreio: {kvp.Key}  |  Barcode: {kvp.Value}");
            }
        }
    }
}
