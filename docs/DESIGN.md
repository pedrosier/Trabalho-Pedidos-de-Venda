# DESIGN.md - Fases 1 e 2

## Fase 1 — Conceituação (Sem Código)

Ritual fixo de processamento de pedidos: Validar → Calcular Total → Emitir Recibo.
Pedidos Nacionais aplicam regras fiscais internas e emitem um recibo fiscal; Pedidos Internacionais consideram taxas de importação/câmbio e emitem commercial invoice. Como o fluxo (ritual) é o mesmo, utilizamos herança para especializar o comportamento do tipo de pedido (ganchos/overrides). Políticas como frete, embalagem, seguro e promoção são independentes e combináveis; por isso são modeladas por composição (delegates/estratégias) injetadas no pedido.

## Fase 2 — Design Orientado a Objetos (Sem Código)

A classe base `Pedido` é concreta e expõe o método `Processar()` que orquestra o ritual: `Validar()` → `CalcularSubtotal()` → aplicar eixos plugáveis (Frete, Promoção, etc.) → `CalcularTotal()` → `EmitirRecibo(total)`. Os pontos variáveis por tipo ficam como `protected virtual` hooks: `Validar()`, `CalcularSubtotal()` e `EmitirRecibo(decimal total)` para que folhas (`PedidoNacional`, `PedidoInternacional`) façam `override` sem alterar o ritual.

Regras LSP (aplicadas):

1. Substituibilidade: qualquer cliente que receba `Pedido` e invoque `Processar()` funciona igual com `PedidoNacional` ou `PedidoInternacional` sem `is`/downcast.
2. Invariantes preservadas: validações mínimas definidas na base não podem ser enfraquecidas nas derivadas — podem apenas ser fortalecidas (fail-fast).
3. Contratos de saída equivalentes: `Processar()` sempre retorna um recibo coerente com o total calculado e não lança exceções além das esperadas pela base.

Eixos plugáveis (delegates):

- `Frete: decimal -> decimal` — recebe o valor corrente (subtotal) e retorna o valor aplicado (pode ser valor fixo ou percentual aplicado).
- `Promocao: decimal -> decimal` — recebe o valor corrente e retorna o valor após aplicação da promoção (cupom percentual, desconto fixo, etc.).
  Esses delegates são injetados no construtor do `Pedido` e aplicados em sequência durante `Processar()` para garantir flexibilidade sem criar subclasses combinatórias.
