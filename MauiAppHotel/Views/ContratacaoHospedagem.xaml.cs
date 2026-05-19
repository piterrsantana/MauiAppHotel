using System.Data;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    App PropriedadesdoApp;

	public ContratacaoHospedagem()
	{
		InitializeComponent();
        PropriedadesdoApp = (App)Application.Current;
        pck_quarto.ItemsSource = PropriedadesdoApp.lista_quartos;

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkout.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        dtpck_checkout.MinimumDate = dtpck_checkin.Date?.AddDays(1);
        dtpck_checkout.MinimumDate = dtpck_checkin.Date?.AddMonths(6);
    }


    private async void Button_Clicked(object sender, EventArgs e)
    {
            await Navigation.PushAsync(new Sobre()); 
    }

    private async void Button_Clicked_2(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new HospedagemContratada());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Ok");
        }
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        DateTime data_selecionada_checkin = (DateTime)elemento.Date;

        dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
        dtpck_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);
    }
}