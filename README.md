# Sistema de Processamento de Pedidos de Venda (Nacional vs Internacional)

## 📋 Descrição

Este repositório implementa o processamento de pedidos de venda para tipos nacionais e internacionais, seguindo um ritual fixo (Validar → Calcular Total → Emitir Recibo). Utiliza herança para especializar variações por tipo de pedido (impostos e formato de recibo) via ganchos virtual na classe base `Pedido`, garantindo LSP. Para políticas independentes (frete e promoção), adota composição com delegates injetados, permitindo trocas sem subclasses. O foco é em domínio puro com testes unitários.

Disciplina: POO - Herança, Abstratas, Interfaces e Composição (2025).

## 🚀 Tecnologias Utilizadas

- .NET 8.0+
- C# 12
- xUnit

## 🏗️ Arquitetura

Arquitetura simples com domínio isolado:
- **src/Pedidos.Domain**: Classe base `Pedido` (concreta com `Processar()` orquestrando ritual), subclasses sealed `PedidoNacional` e `PedidoInternacional` (overrides em ganchos como `CalcularSubtotal()` e `EmitirRecibo()`), delegates para composição (ex.: `FreteDelegate: decimal → decimal`, `PromocaoDelegate: decimal → decimal`).
- **tests/Pedidos.Domain.Tests**: Testes para LSP (substituição sem downcast) e composição (troca de delegates como frete fixo/percentual e promoção nenhuma/cupom).

## ⚙️ Como Executar

### Pré-requisitos
- .NET SDK 8.0+

### Clonar e Restaurar
```
git clone https://github.com/pedrosier/Trabalho-Pedidos-de-Venda
dotnet restore
```

### Executar Testes
```
dotnet test
```

### Executar Programa
```
dotnet run --project .\src\Domain.App\Domain.App.csproj
```

Nota: Projeto focado em domínio; testes demonstram herança para ritual/especialização e composição para eixos plugáveis, evitando proliferação de subclasses.

## 👥 Aluno

Pedro Reis

## 📘 Informações da Disciplina

- **Curso:** Ciência da Computação
- **Disciplina:** Programação Orientada a Objetos
- **Orientador:** Prof. Dr. Everton Coimbra
