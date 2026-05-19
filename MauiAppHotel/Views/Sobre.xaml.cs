using System;
using Microsoft.Maui.Controls;

namespace MauiAppHotel.Views;

public partial class Sobre : ContentPage
{
    public Sobre()
    {
        // Esta linha é obrigatória para conectar o XAML com este arquivo C#
        InitializeComponent();
    }

    // Certifique-se de que o nome do método é exatamente "Button_Clicked"
    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Fecha a tela atual e retorna para a tela anterior
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Ok");
        }
    }
}