using System;

class JogoDaVelha
{
    static char[,] tabuleiro = {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
    };

    static char jogadorAtual = 'X';

    static void Main()
    {
        int jogadas = 0;
        bool jogoAtivo = true;

        while (jogoAtivo)
        {
            Console.Clear();
            MostrarTabuleiro();

            Console.WriteLine($"\nVez do jogador {jogadorAtual}. Escolha uma posição (1-9): ");
            string entrada = Console.ReadLine();

            if (!int.TryParse(entrada, out int posicao) || posicao < 1 || posicao > 9)
            {
                Console.WriteLine("Entrada inválida.");
                Console.ReadLine();
                continue;
            }

            if (!MarcarPosicao(posicao))
            {
                Console.WriteLine("Posição já ocupada.");
                Console.ReadLine();
                continue;
            }

            jogadas++;

            if (VerificarVencedor())
            {
                Console.Clear();
                MostrarTabuleiro();
                Console.WriteLine($"\nParabéns! Jogador {jogadorAtual} venceu!");
                jogoAtivo = false;
            }
            else if (jogadas == 9)
            {
                Console.Clear();
                MostrarTabuleiro();
                Console.WriteLine("\nEmpate!");
                jogoAtivo = false;
            }
            else
            {
                jogadorAtual = (jogadorAtual == 'X') ? 'O' : 'X';
            }
        }

        Console.WriteLine("\nFim de jogo.");
        Console.ReadLine();
    }

    static void MostrarTabuleiro()
    {
        Console.WriteLine(" Jogo da Velha \n");
        Console.WriteLine(" {0} | {1} | {2} ", tabuleiro[0, 0], tabuleiro[0, 1], tabuleiro[0, 2]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} ", tabuleiro[1, 0], tabuleiro[1, 1], tabuleiro[1, 2]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} ", tabuleiro[2, 0], tabuleiro[2, 1], tabuleiro[2, 2]);
    }

    static bool MarcarPosicao(int posicao)
    {
        int linha = (posicao - 1) / 3;
        int coluna = (posicao - 1) % 3;

        if (tabuleiro[linha, coluna] == 'X' || tabuleiro[linha, coluna] == 'O')
        {
            return false; // já ocupado
        }

        tabuleiro[linha, coluna] = jogadorAtual;
        return true;
    }

    static bool VerificarVencedor()
    {
        // Linhas
        for (int i = 0; i < 3; i++)
        {
            if (tabuleiro[i, 0] == jogadorAtual &&
                tabuleiro[i, 1] == jogadorAtual &&
                tabuleiro[i, 2] == jogadorAtual)
                return true;
        }

        // Colunas
        for (int i = 0; i < 3; i++)
        {
            if (tabuleiro[0, i] == jogadorAtual &&
                tabuleiro[1, i] == jogadorAtual &&
                tabuleiro[2, i] == jogadorAtual)
                return true;
        }

        // Diagonais
        if (tabuleiro[0, 0] == jogadorAtual &&
            tabuleiro[1, 1] == jogadorAtual &&
            tabuleiro[2, 2] == jogadorAtual)
            return true;

        if (tabuleiro[0, 2] == jogadorAtual &&
            tabuleiro[1, 1] == jogadorAtual &&
            tabuleiro[2, 0] == jogadorAtual)
            return true;

        return false;
    }
}
