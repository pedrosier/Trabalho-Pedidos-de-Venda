using Xunit;
using Domain.Entities.Entities;

namespace Domain.Tests.Tests
{
    public class PedidoTests
    {
        [Fact]
        public void Processar_ReturnsRecibo_StringNotEmpty()
        {
            var pedido = new Pedido(Fretes.Fixo(10m), Promocoes.Nenhuma(), 100m);
            var result = pedido.Processar();
            Assert.False(string.IsNullOrWhiteSpace(result));
            Assert.Contains("Recibo", result);
        }

        [Fact]
        public void Processar_ValidatesSubtotal_ThrowsWhenZero()
        {
            var pedido = new Pedido(Fretes.Fixo(0m), Promocoes.Nenhuma(), 0m);
            Assert.Throws<System.InvalidOperationException>(() => pedido.Processar());
        }
    }
}
