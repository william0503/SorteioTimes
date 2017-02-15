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
            ValidarCampos();
        }

        public void ValidarCampos()
        {
            TudoPronto.IsVisible =
                  ((!AlterarQuantidadeTimes.IsToggled || !string.IsNullOrEmpty(NumeroTimes.Text))
                && !string.IsNullOrEmpty(JogadoresPorTime.Text)
                && !string.IsNullOrEmpty(JogadoresTotal.Text)
                && (!AlterarQuantidadeTimes.IsToggled || NumeroTimes.Text != "0")
                && JogadoresPorTime.Text != "0"
                && JogadoresTotal.Text != "0");
            //&& (Convert.ToInt32(JogadoresTotal.Text) < Convert.ToInt32(JogadoresPorTime.Text));
        }

        public void Avancar(object sender, EventArgs args)
        {
            
            var jogadoresPorTime = Convert.ToInt32(JogadoresPorTime.Text);
            var jogadoresTotal = Convert.ToInt32(JogadoresTotal.Text);

            if(jogadoresTotal< jogadoresPorTime)
            {
                DisplayAlert("Atenção", "O Total de jogadores não pode ser menor que o número de jogadores em cada equipe", "OK");
                return;
            }

            var numeroTimes = AlterarQuantidadeTimes.IsToggled ? Convert.ToInt32(NumeroTimes.Text) : Convert.ToInt32(jogadoresTotal / jogadoresPorTime);

            if ((numeroTimes * jogadoresPorTime) > jogadoresTotal)
            {
                DisplayAlert("Atenção", "O Total de jogadores não pode ser menor que o número de jogadores esperados nos times", "OK");
                return;
            }

            var config = new ConfiguracaoTimes(numeroTimes, jogadoresPorTime, jogadoresTotal);
            
            var sorteio = new Sorteio(config);
            
            Navigation.PushModalAsync(sorteio);
        }

        void AlterarQuantidadeTimes_Toggled(object sender, ToggledEventArgs e)
        {
            QuantidadeTimes.IsVisible = AlterarQuantidadeTimes.IsToggled;
            ValidarCampos();
        }
    }
}
