namespace AgenciaTurismo.Service
{
    public static class ReservaService
    {
        // Func que calcula o total da reserva
        public static readonly Func<int, decimal, decimal> CalcularTotal =
            (numeroDiarias, valorDiaria) => numeroDiarias * valorDiaria;
    }
}
