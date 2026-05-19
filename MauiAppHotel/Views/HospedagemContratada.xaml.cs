using System;
using Microsoft.Maui.Controls;
using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class HospedagemContratada : ContentPage
{
    // Construtor padrão exigido pelo framework
    public HospedagemContratada()
    {
        InitializeComponent();
    }

    // Construtor modificado para receber o modelo completo preenchido
    public HospedagemContratada(Hospedagem hospedagem)
    {
        InitializeComponent();

        // Passa o objeto diretamente para o Contexto de Vinculação (Data Binding)
        BindingContext = hospedagem;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Ok");
        }
    }
}