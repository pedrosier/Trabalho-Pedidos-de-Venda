using Xunit;
using Domain.Entities.Entities;

namespace Domain.Tests.Tests
{
    public class PedidoInternacionalTests
    {
        [Fact]
        public void LSP_Processar_WorksForPedidoInternacional()
        {
            Pedido aceitaPedido = new PedidoInternacional(Fretes.Fixo(10m), Promocoes.Nenhuma(), 100m);
            var texto = aceitaPedido.Processar();
            Assert.Contains("Commercial Invoice (International)", texto);
        }

        [Fact]
        public void Composicao_TrocaFreteEPromocao_AlteraTotal()
        {
            var freteFixo = Fretes.Fixo(5m);
            var fretePercent = Fretes.Percentual(0.05m);
            var promoNenhuma = Promocoes.Nenhuma();
            var promoCupom = Promocoes.CupomPercentual(0.05m);

            var p1 = new PedidoInternacional(freteFixo, promoNenhuma, 200m);
            var p2 = new PedidoInternacional(fretePercent, promoNenhuma, 200m);
            var p3 = new PedidoInternacional(freteFixo, promoCupom, 200m);

            var t1 = p1.Processar();
            var t2 = p2.Processar();
            var t3 = p3.Processar();

            Assert.NotEqual(t1, t2);
            Assert.NotEqual(t1, t3);
        }
    }
}
