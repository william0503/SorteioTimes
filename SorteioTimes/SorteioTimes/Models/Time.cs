using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteioTimes.Models
{
    public class Time : BaseModel
    {
        public IList<string> Jogadores { get; set; }
        public int LimiteDeJogadores { get; set; }

        public bool TimeCompleto {
            get
            {
                return !(Jogadores.Count() < LimiteDeJogadores);
            }
        }

        public Time(int limiteDeJogadores)
        {
            Jogadores = new List<string>();
            LimiteDeJogadores = limiteDeJogadores;
        }

        public void AdicionarJogador(string jogador)
        {
            Jogadores.Add(jogador);
        }

        public void LimparTime()
        {
            Jogadores.Clear();
        }
    }
}
