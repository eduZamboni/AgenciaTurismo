using System;

namespace AgenciaTurismo.Service
{
    public delegate decimal CalculateDelegate(decimal valor);

    public class DescontoHelper
    {
        public static decimal AplicarDesconto(decimal valor)
        {
            return valor * 0.9m;
        }
    }
}