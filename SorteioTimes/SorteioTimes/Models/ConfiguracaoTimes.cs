using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteioTimes.Models
{
    class ConfiguracaoTimes : BaseModel
    {
        public int NumeroTimes { get; set; }
        public int JogadoresPorTime { get; set; }

        public ConfiguracaoTimes()
        {
            NumeroTimes = 0;
            JogadoresPorTime = 0;
        }

        public ConfiguracaoTimes(int numeroTimes, int jogadoresPorTime)
        {
            NumeroTimes = numeroTimes;
            JogadoresPorTime = jogadoresPorTime;
        }
    }
}
