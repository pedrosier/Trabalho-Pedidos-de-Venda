using Xunit;
using Domain.Entities.Entities;

namespace Domain.Tests.Tests
{
    public class PedidoNacionalTests
    {
        [Fact]
        public void LSP_Processar_WorksForPedidoNacional()
        {
            Pedido aceitaPedido = new PedidoNacional(Fretes.Fixo(10m), Promocoes.Nenhuma(), 150m);
            var texto = aceitaPedido.Processar();
            Assert.Contains("Recibo Fiscal (Nacional)", texto);
        }

        [Fact]
        public void Composicao_TrocaFreteEPromocao_AlteraTotal()
        {
            var freteFixo = Fretes.Fixo(10m);
            var fretePercent = Fretes.Percentual(0.10m);
            var promoNenhuma = Promocoes.Nenhuma();
            var promoCupom10 = Promocoes.CupomPercentual(0.10m);

            var p1 = new PedidoNacional(freteFixo, promoNenhuma, 100m);
            var p2 = new PedidoNacional(fretePercent, promoNenhuma, 100m);
            var p3 = new PedidoNacional(freteFixo, promoCupom10, 100m);

            var t1 = p1.Processar();
            var t2 = p2.Processar();
            var t3 = p3.Processar();

            Assert.NotEqual(t1, t2);
            Assert.NotEqual(t1, t3);
        }
    }
}
