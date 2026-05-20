using System;
using Microsoft.Maui.Controls;
using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    App PropriedadesdoApp;

    // Construtor da Tela (Executa ao abrir a página)
    public ContratacaoHospedagem()
    {
        InitializeComponent();
        PropriedadesdoApp = (App)Application.Current;
        pck_quarto.ItemsSource = PropriedadesdoApp.lista_quartos;

        // Define as regras iniciais de data
        dtpck_checkin.MinimumDate = DateTime.Now; //Impede escolha de datas no passado.
        dtpck_checkout.MinimumDate = DateTime.Now.AddDays(1);//Exige pelo menos um dia de estadia. Saida somente um dia depois de Hoje
        dtpck_checkout.MaximumDate = DateTime.Now.AddMonths(6); //Limite para escolha de data. Maximo 6 meses o que protege preços desatualizados
    }

    private async void Button_Clicked(object sender, EventArgs e)//Ao clicar no Botão "Sobre", o App será direcionado para a página sobre.
    {
        await Navigation.PushAsync(new Sobre());
    }

    // Botão Avançar
    private async void Button_Clicked_2(object sender, EventArgs e) //Ao clicar no Botão "Sobre", o App será direcionado para a página sobre.
    {
        try //Proteção para o App não trvar enquanto realiza processos. "Tente" isso, "Se der erro" faça isso.
        {
            // Validação: Verifica se o usuário escolheu um quarto antes de avançar
            if (pck_quarto.SelectedItem == null)//Se não escolher nenhum quarto Avise: ....
            {
                await DisplayAlert("Ops", "Por favor, selecione uma acomodação.", "Ok");
                return;
            }

            // Monta o objeto de hospedagem com os dados da tela
            Hospedagem hospedagemContratada = new Hospedagem
            {
                QuantidadeAdultos = Convert.ToInt32(stp_adultos.Value), //Resgata os valores escolhidos pelo o usuário, converte em nº e armazena
                QuantidadeCriancas = Convert.ToInt32(stp_crianca.Value),
                DataCheckIn = (DateTime)dtpck_checkin.Date,
                DataCheckOut = (DateTime)dtpck_checkout.Date,
                QuartoSelecionado = (Quarto)pck_quarto.SelectedItem //Guarda o tipo de quarto com os preços escolhidos pelo usuário
            };

            // Envia o objeto criado para o construtor da próxima página
            await Navigation.PushAsync(new HospedagemContratada(hospedagemContratada));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Ok");
        }
    }

    // Atualiza dinamicamente os limites do checkout ao mudar o check-in
    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)//Método para proteger o período determinado de escolha em 6 meses.
    {
        DatePicker elemento = sender as DatePicker;
        DateTime data_selecionada_checkin = (DateTime)elemento.Date;

        dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
        dtpck_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);
    }
}