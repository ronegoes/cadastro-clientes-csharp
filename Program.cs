using System;
using cadastro1;
using Npgsql;

class Program
{
    static void Main(string[] args)
    {
        ClienteService clienteService = new ClienteService();
        ProdutoServico produtoService = new ProdutoServico(); // INSTÂNCIA CORRETA

        bool sair = false;

        while (!sair)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== Desenvolvido por: Roneii Gomes da silva ===");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("=== (65)9-8455-8815) ===");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("=== roneiigomessilva@gmail.com ===");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Sistema de Cadastro de Clientes e Produtos ===");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1 - Cadastrar Cliente");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("2 - Listar Clientes");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("3 - Buscar Cliente");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("4 - Editar Cliente");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("5 - Deletar Cliente");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("6 - Adicionar Produto");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("7 - Listar Produtos");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("8 - Buscar Produto");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("9 - Atualizar Produto");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("10 - Deletar Produto"); 
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("11 - Iniciar Venda");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("0 - Sair");
            Console.ResetColor();           
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Escolha uma opção: ");
            Console.ResetColor();
            int opcao = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (opcao)
            {
                case 1:
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("CPF: ");
                    string cpf = Console.ReadLine();
                    Console.Write("Email: ");
                    string email = Console.ReadLine();
                    Console.Write("Tipo: ");
                    string tipo = Console.ReadLine();
                    clienteService.CadastrarCliente(nome, cpf, email, tipo);
                    break;

                case 2:
                    clienteService.ListarClientes();
                    break;

                case 3:
                    Console.Write("Digite o nome do cliente para buscar: ");
                    string nomeClienteBusca = Console.ReadLine();
                    clienteService.BuscarCliente(nomeClienteBusca);
                    break;

                case 4:
                    Console.Write("Digite o ID do cliente a editar: ");
                    int idEditar = int.Parse(Console.ReadLine());
                    Console.Write("Novo Nome: ");
                    string novoNome = Console.ReadLine();
                    Console.Write("Novo CPF: ");
                    string novoCpf = Console.ReadLine();
                    Console.Write("Novo Email: ");
                    string novoEmail = Console.ReadLine();
                    Console.Write("Tipo: ");
                    string novoTipo = Console.ReadLine();
                    clienteService.EditarCliente(idEditar, novoNome, novoCpf, novoEmail, novoTipo);
                    break;

                case 5:
                    Console.Write("Digite o ID do cliente a deletar: ");
                    int idDeletarCliente = int.Parse(Console.ReadLine());
                    clienteService.DeletarCliente(idDeletarCliente);
                    break;

                case 6:
                    Console.Write("Nome do Produto: ");
                    string nomeProduto = Console.ReadLine();
                    Console.Write("Preço: ");
                    decimal preco = decimal.Parse(Console.ReadLine());
                    Console.Write("Quantidade: ");
                    int quantidade = int.Parse(Console.ReadLine());
                    Console.Write("Descrição: ");
                    string descricao = Console.ReadLine();
                    produtoService.AdicionarProduto(nomeProduto, preco, quantidade, descricao);
                    break;

                case 7:
                    produtoService.ListarProdutos();
                    break;

                case 8:
                    Console.Write("Digite o nome do produto para buscar: ");
                    string nomeProdutoBusca = Console.ReadLine();
                    produtoService.BuscarProduto(nomeProdutoBusca);
                    break;

                case 9:
                    Console.Write("Digite o ID do produto para atualizar: ");
                    int idAtualizar = int.Parse(Console.ReadLine());
                    Console.Write("Novo Nome: ");
                    string novoNomeProduto = Console.ReadLine();
                    Console.Write("Novo Preço: ");
                    decimal novoPreco = decimal.Parse(Console.ReadLine());
                    Console.Write("Nova Descrição: ");
                    string novaDescricao = Console.ReadLine();
                    Console.Write("Nova Quantidade: ");
                    int novaQuantidade = int.Parse(Console.ReadLine());
                    produtoService.AtualizarProduto(idAtualizar, novoNomeProduto, novoPreco, novaDescricao, novaQuantidade);
                    break;

                case 10:
                    Console.Write("Digite o ID do produto para deletar: ");
                    int idDeletarProduto = int.Parse(Console.ReadLine());
                    produtoService.DeletarProduto(idDeletarProduto);
                    break;
                case 11:
                    TelaDeVendas tela = new TelaDeVendas();
                    tela.IniciarVenda();
                    break;



                case 0:
                    sair = true;
                    break;

                default:
                    Console.WriteLine("Opção inválida!\n");
                    break;
            }
        }

        Console.WriteLine("Sistema encerrado.");
    }
}
