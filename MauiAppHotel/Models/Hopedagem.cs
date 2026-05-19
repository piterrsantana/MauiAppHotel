using System;

namespace MauiAppHotel.Models
{
    public class Hospedagem
    {
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
                TimeSpan diferenca = DataCheckOut - DataCheckIn;
                return diferenca.Days;
            }
        }

        // Propriedade calculada que realiza a conta matemática total da hospedagem
        public double ValorTotal
        {
            get
            {
                if (QuartoSelecionado == null) return 0;

                double valorAdultos = QuantidadeAdultos * QuartoSelecionado.ValorDiariaAdulto;
                double valorCriancas = QuantidadeCriancas * QuartoSelecionado.ValorDiariaCrianca;

                return (valorAdultos + valorCriancas) * QuantidadeDias;
            }
        }
    }
}