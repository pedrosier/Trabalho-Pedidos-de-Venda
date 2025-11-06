using System;
using Domain.Entities.Entities;

class Program
{
    static void Main()
    {
        var freteFixo10 = Fretes.Fixo(10m);
        var promoNenhuma = Promocoes.Nenhuma();

        var pedidoNac = new PedidoNacional(freteFixo10, promoNenhuma, 200m);
        var pedidoInt = new PedidoInternacional(freteFixo10, promoNenhuma, 200m);

        Console.WriteLine(pedidoNac.Processar());
        Console.WriteLine(pedidoInt.Processar());
    }
}
