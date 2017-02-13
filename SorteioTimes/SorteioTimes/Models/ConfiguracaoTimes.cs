using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteioTimes.Models
{
    public class ConfiguracaoTimes : BaseModel
    {
        public int NumeroTimes { get; set; }
        public int JogadoresPorTime { get; set; }
        public int JogadoresTotal { get; set; }

        public int TotalJogadoresValidos
        {
            get { return NumeroTimes * JogadoresPorTime; }
        }

        public int TotalProximosJogadores
        {
            get { return JogadoresTotal - TotalJogadoresValidos; }
        }

        public ConfiguracaoTimes()
        {
            NumeroTimes = 0;
            JogadoresPorTime = 0;
        }

        public ConfiguracaoTimes(int numeroTimes, int jogadoresPorTime, int jogadoresTotal)
        {
            NumeroTimes = numeroTimes;
            JogadoresPorTime = jogadoresPorTime;
            JogadoresTotal = jogadoresTotal;
        }
    }
}
