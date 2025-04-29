# Sistema de Cadastro de Clientes e Produtos em C#

Este é um sistema desenvolvido em C# para o cadastro de clientes e produtos, controle de estoque, e geração de vendas com emissão de PDF. Ele permite que o usuário registre clientes, adicione produtos ao estoque, realize vendas e registre essas informações em um banco de dados PostgreSQL. Além disso, gera um PDF com os detalhes da venda.

## Funcionalidades

- **Cadastro de Clientes:** Permite registrar clientes no sistema.
- **Cadastro de Produtos:** Permite adicionar produtos com informações como nome, quantidade e preço.
- **Gestão de Estoque:** Permite atualizar a quantidade dos produtos no estoque.
- **Venda de Produtos:** Realiza a venda de produtos, gerando um PDF da fatura de venda.
- **Relatórios:** Emite relatórios das vendas realizadas.
- **Armazenamento em Banco de Dados:** Utiliza o PostgreSQL para persistência dos dados.

## Tecnologias Utilizadas

- C#
- .NET 6
- PostgreSQL
- iTextSharp (para geração de PDF)

## Como Rodar o Sistema

### Pré-requisitos:

- **.NET SDK** instalado. Você pode baixar o SDK do .NET [aqui](https://dotnet.microsoft.com/download).
- **PostgreSQL** instalado e configurado. Você pode baixar o PostgreSQL [aqui](https://www.postgresql.org/download/).
- Uma IDE como o [Visual Studio](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/).

### Passos:

1. Clone o repositório:

   ```bash
   git clone https://github.com/ronegoes/cadastro-clientes-csharp.git
