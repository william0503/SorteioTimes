using SorteioTimes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SorteioTimes
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void ValidarCampos(object sender, TextChangedEventArgs e)
        {
                TudoPronto.IsVisible = 
                      (!string.IsNullOrEmpty(NumeroTimes.Text) 
                    && !string.IsNullOrEmpty(JogadoresPorTime.Text)
                    && !string.IsNullOrEmpty(JogadoresTotal.Text)
                    && NumeroTimes.Text != "0" 
                    && JogadoresPorTime.Text != "0"
                    && JogadoresTotal.Text != "0");
        }

        public void Avancar(object sender, EventArgs args)
        {
            var numeroTimes = Convert.ToInt32(NumeroTimes.Text);
            var jogadoresPorTime = Convert.ToInt32(JogadoresPorTime.Text);
            var jogadoresTotal = Convert.ToInt32(JogadoresTotal.Text);

            var config = new ConfiguracaoTimes(numeroTimes, jogadoresPorTime, jogadoresTotal);

            var sorteio = new Sorteio(config);
            
            Navigation.PushModalAsync(sorteio);
        }
    }
}
