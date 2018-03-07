using System;
using tabuleiro;
using xadrez;

namespace xadrez_projeto
{
    class Program
    {
        static void Main(string[] args)
        {
            Tela.menuPrincipal();
            int opcao = 0;
            while (opcao != 1)
            {
                Console.Clear();
                Tela.menuPrincipal();
                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 2: AddHistorico.historicoDePartidas();
                        Console.ReadLine();
                        break;
                    case 3: Environment.Exit(0);
                        break;
                }
            }
            PartidaDeXadrez partida = new PartidaDeXadrez();
            while (!partida.terminada)
            {
                try
                {
                    Console.Clear();
                    Tela.imprimirPartida(partida);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                    partida.validarPosicaoDeOrigem(origem);
                    bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);
                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                    partida.validarPosicaoDeDestino(origem, destino);
                    partida.realizaJogada(origem, destino);
                }
                catch (tabuleiroException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
            Console.Clear();
            Tela.imprimirPartida(partida);            
            Console.ReadLine();
        }
    }
}
