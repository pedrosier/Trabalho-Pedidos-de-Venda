# Pedidos: Nacional vs Internacional

## 📋 Descrição

Solução da atividade "Pedidos de Venda" (Nacional vs Internacional). A classe base `Pedido` orquestra o ritual fixo (Validar → Calcular Total → Emitir Recibo) com ganchos `protected virtual` para especialização via herança. Políticas como frete e promoção são modeladas por composição usando delegates injetados, permitindo trocar comportamentos sem novas subclasses.

## ⚙️ Como Executar

Requisitos: .NET 9.0+
No diretório do repositório:

- `dotnet restore`
- `dotnet test src/Domain.Tests`

## 👥 Autor

Entrega adaptada para a atividade de POO.
