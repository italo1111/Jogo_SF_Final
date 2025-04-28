using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo_SF
{
    internal class Jogo
    {
        public List<Piloto> cartasJogador1 { get; private set; }
        public List<Piloto> cartasJogador2 { get; private set; }
        private List<Piloto> todasCartas;

        public Jogo()
        {
            cartasJogador1 = new List<Piloto>();
            cartasJogador2 = new List<Piloto>();
            todasCartas = new List<Piloto>();


            todasCartas.Add(new Piloto("Ayrton Senna", 355, 17200, 830));
            todasCartas.Add(new Piloto("Lewis Hamilton", 350, 17000, 940));
            todasCartas.Add(new Piloto("Max Verstappen", 340, 16800, 960));
            todasCartas.Add(new Piloto("Lando Norris", 340, 16900, 870));
            todasCartas.Add(new Piloto("Sergio Pérez", 335, 16700, 880));
            todasCartas.Add(new Piloto("Charles Leclerc", 335, 16500, 870));
            todasCartas.Add(new Piloto("Fernando Alonso", 330, 16400, 880));
            todasCartas.Add(new Piloto("Oscar Piastri", 330, 16500, 870));
        }


        public void DistribuirCartas()
        {
            Random random = new Random();
            List<Piloto> cartasDisponiveis = new List<Piloto>(todasCartas);


            for (int i = 0; i < cartasDisponiveis.Count; i++)
            {
                int j = random.Next(i, cartasDisponiveis.Count);
                Piloto temp = cartasDisponiveis[i];
                cartasDisponiveis[i] = cartasDisponiveis[j];
                cartasDisponiveis[j] = temp;
            }


            cartasJogador1.Add(cartasDisponiveis[0]);
            cartasJogador1.Add(cartasDisponiveis[1]);
            cartasJogador1.Add(cartasDisponiveis[2]);
            cartasJogador1.Add(cartasDisponiveis[3]);

            cartasJogador2.Add(cartasDisponiveis[4]);
            cartasJogador2.Add(cartasDisponiveis[5]);
            cartasJogador2.Add(cartasDisponiveis[6]);
            cartasJogador2.Add(cartasDisponiveis[7]);
        }


        public void JogarRodada(int cartaEscolhidaJogador1, string atributoEscolhido)
        {
            Piloto cartaJogador1 = cartasJogador1[cartaEscolhidaJogador1];


            Piloto cartaJogador2 = MelhorCartaParaComparar(atributoEscolhido);

            Console.WriteLine($"\nJogador 1 jogou a carta {cartaJogador1.Nome} - km/h: {cartaJogador1.KmPorHora} - rpm: {cartaJogador1.Rpm} - hp: {cartaJogador1.Hp}");
            Console.WriteLine($"Jogador 2 jogou a carta {cartaJogador2.Nome} - km/h: {cartaJogador2.KmPorHora} - rpm: {cartaJogador2.Rpm} - hp: {cartaJogador2.Hp}");

            int resultadoJogador1 = 0;
            int resultadoJogador2 = 0;


            switch (atributoEscolhido)
            {
                case "km/h":
                    resultadoJogador1 = cartaJogador1.KmPorHora;
                    resultadoJogador2 = cartaJogador2.KmPorHora;
                    break;
                case "rpm":
                    resultadoJogador1 = cartaJogador1.Rpm;
                    resultadoJogador2 = cartaJogador2.Rpm;
                    break;
                case "hp":
                    resultadoJogador1 = cartaJogador1.Hp;
                    resultadoJogador2 = cartaJogador2.Hp;
                    break;
                default:
                    Console.WriteLine("Atributo inválido!");
                    return;
            }


            if (resultadoJogador1 > resultadoJogador2)
            {
                Console.WriteLine($"{cartaJogador1.Nome} venceu a rodada e leva a carta de {cartaJogador2.Nome}");
                cartasJogador1.Add(cartaJogador2);
                cartasJogador2.RemoveAt(cartasJogador2.IndexOf(cartaJogador2));
            }
            else if (resultadoJogador1 < resultadoJogador2)
            {
                Console.WriteLine($"{cartaJogador2.Nome} venceu a rodada e leva a carta de {cartaJogador1.Nome}");
                cartasJogador2.Add(cartaJogador1);
                cartasJogador1.RemoveAt(cartasJogador1.IndexOf(cartaJogador1));
            }
            else
            {
                Console.WriteLine("Empate na rodada!");
            }
        }


        public Piloto MelhorCartaParaComparar(string atributoEscolhido)
        {
            Piloto melhorCarta = cartasJogador2[0];

            foreach (var carta in cartasJogador2)
            {
                switch (atributoEscolhido)
                {
                    case "km/h":
                        if (carta.KmPorHora > melhorCarta.KmPorHora)
                            melhorCarta = carta;
                        break;
                    case "rpm":
                        if (carta.Rpm > melhorCarta.Rpm)
                            melhorCarta = carta;
                        break;
                    case "hp":
                        if (carta.Hp > melhorCarta.Hp)
                            melhorCarta = carta;
                        break;
                }
            }

            return melhorCarta;
        }


        public void VerificarVitoria()
        {
            if (cartasJogador1.Count == 8)
            {
                Console.WriteLine("\nJogador 1 venceu o jogo!");
            }
            else if (cartasJogador2.Count == 8)
            {
                Console.WriteLine("\nJogador 2 venceu o jogo!");
            }
        }
    }
}
