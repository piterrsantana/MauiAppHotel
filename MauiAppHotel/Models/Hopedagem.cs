using System;

namespace MauiAppHotel.Models
{
    public class Hospedagem
    {
        //Aqui definimos as variáveis para calcular o valor da hospedagem e entregar na tela final.
        public Quarto QuartoSelecionado { get; set; }
        public int QuantidadeAdultos { get; set; }
        public int QuantidadeCriancas { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }

        // Propriedade calculada para obter a quantidade de dias da estadia
        public int QuantidadeDias
        {
            get
            {
                TimeSpan diferenca = DataCheckOut - DataCheckIn; //Aqui calculamos quantos dias de estadia. Dia de saída menos o dia de entrada.
                return diferenca.Days; //Dias de estadia
            }
        }

        // Propriedade calculada que realiza a conta matemática total da hospedagem.
        public double ValorTotal
        {
            get
            {
                if (QuartoSelecionado == null) return 0; //Se não for selecionado nenhum quarto o valor exibido será 0.

                double valorAdultos = QuantidadeAdultos * QuartoSelecionado.ValorDiariaAdulto; //Calculo de qual valor para o total de Adultos no quarto selecionado.
                double valorCriancas = QuantidadeCriancas * QuartoSelecionado.ValorDiariaCrianca; //Calculo de qual valor para o total de Crianças no quarto selecionado.

                return (valorAdultos + valorCriancas) * QuantidadeDias; // Resultado final =  soma do preço para os adultos e ciranças multiplicado pelo nº de dias de estadia.
            }
        }
    }
}