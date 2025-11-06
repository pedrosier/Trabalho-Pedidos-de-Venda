namespace Domain.Entities.Entities
{
    public sealed class PedidoNacional : Pedido
    {
        public PedidoNacional(FreteDelegate frete, PromocaoDelegate promocao, decimal? baseSubtotal = null)
            : base(frete, promocao, baseSubtotal)
        {
        }

        protected override decimal CalcularSubtotal()
        {
            // regra padrão para nacional: usa base
            return base.CalcularSubtotal();
        }

        protected override string EmitirRecibo(decimal total)
        {
            return $"Recibo Fiscal (Nacional): {total:C}";
        }
    }
}
