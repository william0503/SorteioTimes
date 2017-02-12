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

        public Time()
        {
            Jogadores = new List<string>();
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
