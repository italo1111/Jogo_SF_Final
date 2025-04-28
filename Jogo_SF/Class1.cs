using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo_SF
{
    internal class Piloto
    {
        public string Nome { get; set; }
        public int KmPorHora { get; set; }
        public int Rpm { get; set; }
        public int Hp { get; set; }

        public Piloto(string nome, int kmPorHora, int rpm, int hp)
        {
            Nome = nome;
            KmPorHora = kmPorHora;
            Rpm = rpm;
            Hp = hp;
        }


        public void ExibirInformacoes()
        {
            Console.WriteLine($"{Nome} - km/h: {KmPorHora} - rpm: {Rpm} - hp: {Hp}");
        }
    }
}
