using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo_SF
{
    internal class Program
    {
        static void Main(string[] args)
        {
               Jogo jogo = new Jogo();
            bool vezJogador1EscolherAtributo = true;


                jogo.DistribuirCartas();


                Console.WriteLine("Cartas do Jogador 1:");
                foreach (var carta in jogo.cartasJogador1)
                {
                    carta.ExibirInformacoes();
                }

                Console.WriteLine("\nCartas do Jogador 2:");
                foreach (var carta in jogo.cartasJogador2)
                {
                    carta.ExibirInformacoes();
                }

            while (jogo.cartasJogador1.Count > 0 && jogo.cartasJogador2.Count > 0)
            {
                Console.WriteLine($"\nVocê tem {jogo.cartasJogador1.Count} carta(s). Escolha uma carta para jogar (1 a {jogo.cartasJogador1.Count}): ");
                int cartaEscolhidaJogador1 = int.Parse(Console.ReadLine()) - 1;

                if (cartaEscolhidaJogador1 < 0 || cartaEscolhidaJogador1 >= jogo.cartasJogador1.Count)
                {
                    Console.WriteLine($"Jogador 1 só tem {jogo.cartasJogador1.Count} carta(s). Escolha uma carta válida!");
                    continue;
                }

                Console.WriteLine("\nEscolha um atributo para comparar (km/h, rpm, hp): ");
                    string atributoEscolhido = Console.ReadLine().ToLower();

                    jogo.JogarRodada(cartaEscolhidaJogador1, atributoEscolhido);

                    jogo.VerificarVitoria();
                }
        }
    }
}

