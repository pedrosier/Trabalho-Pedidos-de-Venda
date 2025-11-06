using System;

namespace Domain.Entities.Entities
{
    public delegate decimal FreteDelegate(decimal current);
    public delegate decimal PromocaoDelegate(decimal current);

    public class Pedido
    {
        private readonly decimal _baseSubtotal;

        public FreteDelegate Frete { get; }
        public PromocaoDelegate Promocao { get; }

        public Pedido(FreteDelegate frete, PromocaoDelegate promocao, decimal? baseSubtotal = null)
        {
            Frete = frete ?? throw new ArgumentNullException(nameof(frete));
            Promocao = promocao ?? throw new ArgumentNullException(nameof(promocao));
            _baseSubtotal = baseSubtotal ?? 100m;
        }

        // Template method
        public string Processar()
        {
            Validar();
            var subtotal = CalcularSubtotal();
            var afterFrete = Frete(subtotal);
            var afterPromocao = Promocao(afterFrete);
            var total = CalcularTotal(afterPromocao);
            return EmitirRecibo(total);
        }

        // Hooks
        protected virtual void Validar()
        {
            if (CalcularSubtotal() <= 0) throw new InvalidOperationException("Subtotal deve ser maior que zero.");
        }

        protected virtual decimal CalcularSubtotal() => _baseSubtotal;

        // Final calculation step (can be overridden if needed)
        protected virtual decimal CalcularTotal(decimal current) => current;

        protected virtual string EmitirRecibo(decimal total) => $"Recibo: {total:C}";
    }

    // Helper strategies (kept in same file per instruction)
    public static class Fretes
    {
        public static FreteDelegate Fixo(decimal valor) => _ => valor;
        public static FreteDelegate Percentual(decimal percentual) => current => current + (current * percentual);
    }

    public static class Promocoes
    {
        public static PromocaoDelegate Nenhuma() => current => current;
        public static PromocaoDelegate CupomPercentual(decimal percentual) => current => current - (current * percentual);
    }
}
