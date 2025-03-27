using System;

class Program
{
    static char[,] tabuleiro = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
    static char jogadorAtual = 'X';

    static void Main()
    {
        int jogadas = 0;
        bool jogoAtivo = true;

        while (jogoAtivo)
        {
            Console.Clear();
            ExibirTabuleiro();
            Console.WriteLine($"Vez do jogador {jogadorAtual}. Escolha uma posição:");

            if (int.TryParse(Console.ReadLine(), out int posicao) && posicao >= 1 && posicao <= 9)
            {
                if (MarcarJogada(posicao))
                {
                    jogadas++;

                    if (VerificarVitoria())
                    {
                        Console.Clear();
                        ExibirTabuleiro();
                        Console.WriteLine($"Jogador {jogadorAtual} venceu!");
                        jogoAtivo = false;
                    }
                    else if (jogadas == 9)
                    {
                        Console.Clear();
                        ExibirTabuleiro();
                        Console.WriteLine("Empate!");
                        jogoAtivo = false;
                    }
                    else
                    {
                        jogadorAtual = (jogadorAtual == 'X') ? 'O' : 'X';
                    }
                }
                else
                {
                    Console.WriteLine("Posição ocupada! Tente novamente.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida! Pressione Enter para tentar novamente.");
                Console.ReadLine();
            }
        }
    }

    static void ExibirTabuleiro()
    {
        Console.WriteLine(" Jogo da Velha ");
        Console.WriteLine($" {tabuleiro[0, 0]} | {tabuleiro[0, 1]} | {tabuleiro[0, 2]} ");
        Console.WriteLine("---|---|---");
        Console.WriteLine($" {tabuleiro[1, 0]} | {tabuleiro[1, 1]} | {tabuleiro[1, 2]} ");
        Console.WriteLine("---|---|---");
        Console.WriteLine($" {tabuleiro[2, 0]} | {tabuleiro[2, 1]} | {tabuleiro[2, 2]} ");
    }

    static bool MarcarJogada(int posicao)
    {
        int linha = (posicao - 1) / 3;
        int coluna = (posicao - 1) % 3;

        if (tabuleiro[linha, coluna] != 'X' && tabuleiro[linha, coluna] != 'O')
        {
            tabuleiro[linha, coluna] = jogadorAtual;
            return true;
        }
        return false;
    }

    static bool VerificarVitoria()
    {
        for (int i = 0; i < 3; i++)
        {
            if ((tabuleiro[i, 0] == jogadorAtual && tabuleiro[i, 1] == jogadorAtual && tabuleiro[i, 2] == jogadorAtual) ||
                (tabuleiro[0, i] == jogadorAtual && tabuleiro[1, i] == jogadorAtual && tabuleiro[2, i] == jogadorAtual))
            {
                return true;
            }
        }

        if ((tabuleiro[0, 0] == jogadorAtual && tabuleiro[1, 1] == jogadorAtual && tabuleiro[2, 2] == jogadorAtual) ||
            (tabuleiro[0, 2] == jogadorAtual && tabuleiro[1, 1] == jogadorAtual && tabuleiro[2, 0] == jogadorAtual))
        {
            return true;
        }

        return false;
    }
}
