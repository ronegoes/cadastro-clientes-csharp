# cadastro-clientes-csharp
# 🧾 Sistema de Cadastro e Vendas em C#

Este é um sistema de console desenvolvido em **C#** com integração ao **PostgreSQL** que permite:

✅ Cadastrar clientes  
✅ Adicionar e gerenciar produtos (nome, preço, descrição, quantidade)  
✅ Atualizar ou deletar registros de clientes e produtos  
✅ Realizar vendas (com controle de estoque)  
✅ Gerar uma fatura da venda em **formato PDF**  
✅ Registrar cada venda no banco de dados

## 🛠️ Tecnologias utilizadas

- C# (.NET 8)
- PostgreSQL
- iTextSharp (PDF)
- Visual Studio

- 
## 🐘 Banco de Dados

O banco de dados utilizado é o **PostgreSQL**.  
Você pode ajustar a string de conexão diretamente no código (`Database.cs` ou `TelaDeVendas.cs`).

```csharp
"Host=localhost;Username=postgres;Password=senha;Database=SistemaCadastroCsharp"


## 💻 Funcionalidades

- Cadastro, edição, busca e exclusão de clientes
- Cadastro, edição, busca e exclusão de produtos
- Controle de estoque vinculado à venda
- Geração automática de PDF com os dados do cliente e venda
- Registro da venda em banco de dados

## 📂 Estrutura
cadastro-clientes-csharp/ ├── Cliente.cs ├── ClienteService.cs ├── Produto.cs ├── ProdutoServico.cs ├── TelaDeVendas.cs ├── Program.cs ├── Database.cs └── ...
