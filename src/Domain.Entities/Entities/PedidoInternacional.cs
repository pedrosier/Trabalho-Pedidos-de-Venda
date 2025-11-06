namespace Domain.Entities.Entities
{
    public sealed class PedidoInternacional : Pedido
    {
        public PedidoInternacional(FreteDelegate frete, PromocaoDelegate promocao, decimal? baseSubtotal = null)
            : base(frete, promocao, baseSubtotal)
        {
        }

        protected override decimal CalcularSubtotal()
        {
            // aplica taxa de importação de 20% sobre o subtotal
            var baseSubtotal = base.CalcularSubtotal();
            var taxaImportacao = baseSubtotal * 0.20m;
            return baseSubtotal + taxaImportacao;
        }

        protected override string EmitirRecibo(decimal total)
        {
            return $"Commercial Invoice (International): {total:C}";
        }
    }
}
