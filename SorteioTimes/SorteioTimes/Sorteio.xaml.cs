using SorteioTimes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace SorteioTimes
{
    public partial class Sorteio : ContentPage
    {
        private ConfiguracaoTimes _config;
        private IList<Time> _times;
        private Random rnd = new Random();
        private Time TimeProximos;
        private int[] numerosSorteados;
        public Sorteio()
        {
            InitializeComponent();
        }

        public Sorteio(ConfiguracaoTimes config)
        {
            InitializeComponent();

            _config = config;
            _times = new List<Time>();
            
            for (var x = 0; x < _config.NumeroTimes; x++)
                _times.Add(new Time(_config.JogadoresPorTime));

            if(_config.TotalProximosJogadores > 0)
                TimeProximos = new Time(_config.TotalProximosJogadores);

            numerosSorteados = new int[_config.JogadoresTotal];

            Config.Text = string.Format("Times: {0}, Jogadores por time: {1}, Próximos: {2}", _config.NumeroTimes, _config.JogadoresPorTime, _config.TotalProximosJogadores);            
        }

        public void DefinirTime(object sender, EventArgs args)
        {
            if (TimeProximos != null && !TimeProximos.TimeCompleto)
            {
                var numeroProximo = rnd.Next(1, _config.JogadoresTotal + 1);

                while (numerosSorteados.Contains(numeroProximo))
                    numeroProximo = rnd.Next(_config.JogadoresTotal + 1);
                
                numerosSorteados[numeroProximo - 1] = numeroProximo;
                
                var ehProximo = numeroProximo > _config.TotalJogadoresValidos;

                if (ehProximo)
                {
                    TimeProximos.AdicionarJogador(new Guid().ToString());
                    TimeDefinido.Text = string.Format("Próximo!");

                    if (_times.All(x => x.TimeCompleto && (TimeProximos == null || TimeProximos.TimeCompleto)))
                    {
                        Sortear.IsVisible = false;
                        TimesCompletos.IsVisible = true;

                    }

                    return;                 
                }
            }

            if (!_times.All(x => x.TimeCompleto))
            {
                var timeDefinido = rnd.Next(0, _config.NumeroTimes);

                while (_times[timeDefinido].TimeCompleto)
                    timeDefinido = rnd.Next(0, _config.NumeroTimes);

                _times[timeDefinido].AdicionarJogador(new Guid().ToString());

                TimeDefinido.Text = string.Format("Time {0}", timeDefinido + 1);
            }

            if (_times.All(x => x.TimeCompleto && (TimeProximos == null || TimeProximos.TimeCompleto)))
            {
                Sortear.IsVisible = false;                
                TimesCompletos.IsVisible = true;

            }
        }
    }
}
