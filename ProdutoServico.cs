using System;
using Npgsql;

namespace cadastro1
{
    internal class ProdutoServico
    {
        public void AdicionarProduto(string nome, decimal preco, int quantidade, string descricao)
        {
            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = new NpgsqlCommand("INSERT INTO produtos (nome, preco, quantidade, descricao) VALUES (@nome, @preco, @quantidade, @descricao)", conn);
            cmd.Parameters.AddWithValue("nome", nome);
            cmd.Parameters.AddWithValue("preco", preco);
            cmd.Parameters.AddWithValue("quantidade", quantidade);
            cmd.Parameters.AddWithValue("descricao", descricao);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Produto adicionado com sucesso!\n");
        }

        public void ListarProdutos()
        {
            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = new NpgsqlCommand("SELECT * FROM produtos", conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["id"]}");
                Console.WriteLine($"Nome: {reader["nome"]}");
                Console.WriteLine($"Preço: R${reader["preco"]}");
                Console.WriteLine($"Descrição: {reader["descricao"]}");
                Console.WriteLine($"Quantidade: {reader["quantidade"]}");
                Console.WriteLine("****************");
            }
        }

        public void BuscarProduto(string nome)
        {
            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = new NpgsqlCommand("SELECT * FROM produtos WHERE LOWER(nome) LIKE @nome", conn);
            cmd.Parameters.AddWithValue("nome", "%" + nome.ToLower() + "%");
            using var reader = cmd.ExecuteReader();

            bool encontrado = false;

            while (reader.Read())
            {
                encontrado = true;
                Console.WriteLine($"ID: {reader["id"]}");
                Console.WriteLine($"Nome: {reader["nome"]}");
                Console.WriteLine($"Preço: R${reader["preco"]}");
                Console.WriteLine($"Descrição: {reader["descricao"]}");
                Console.WriteLine($"Quantidade: {reader["quantidade"]}");
                Console.WriteLine("****************");
            }

            if (!encontrado)
                Console.WriteLine("Nenhum produto encontrado.\n");
        }

        public void AtualizarProduto(int id, string novoNome, decimal novoPreco, string novaDescricao, int novaQuantidade)
        {
            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = new NpgsqlCommand("UPDATE produtos SET nome = @nome, preco = @preco, descricao = @descricao, quantidade = @quantidade WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("nome", novoNome);
            cmd.Parameters.AddWithValue("preco", novoPreco);
            cmd.Parameters.AddWithValue("descricao", novaDescricao);
            cmd.Parameters.AddWithValue("quantidade", novaQuantidade);

            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine(rows > 0 ? "Produto atualizado com sucesso!\n" : "Produto não encontrado.\n");
        }

        public void DeletarProduto(int id)
        {
            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = new NpgsqlCommand("DELETE FROM produtos WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("id", id);

            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine(rows > 0 ? "Produto deletado com sucesso!\n" : "Produto não encontrado.\n");
        }
        public void RegistrarVenda(int clienteId, string nomeProduto, int quantidade, decimal precoUnitario)
        {
            try
            {
                using var conn = new NpgsqlConnection("Host=localhost;Username=postgres;Password=978564;Database=SistemaCadastroCsharp");
                conn.Open();

                var cmd = new NpgsqlCommand("INSERT INTO venda (cliente_id, produto_nome, quantidade, preco_unitario) VALUES (@cliente_id, @produto_nome, @quantidade, @preco_unitario)", conn);
                cmd.Parameters.AddWithValue("cliente_id", clienteId);
                cmd.Parameters.AddWithValue("produto_nome", nomeProduto);
                cmd.Parameters.AddWithValue("quantidade", quantidade);
                cmd.Parameters.AddWithValue("preco_unitario", precoUnitario);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Venda registrada com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao registrar venda: {ex.Message}");
            }
        }
        public void GerarRelatorioCsv()
        {
            try
            {
                using var conn = new NpgsqlConnection("Host=localhost;Username=postgres;Password=978564;Database=SistemaCadastroCsharp");
                conn.Open();

                var cmd = new NpgsqlCommand("SELECT v.id, c.nome, v.produto_nome, v.quantidade, v.preco_unitario, v.data FROM vendas v JOIN clientes c ON v.cliente_id = c.id", conn);
                using var reader = cmd.ExecuteReader();

                var caminhoCsv = Path.Combine(Directory.GetCurrentDirectory(), "relatorio_vendas.csv");
                using var writer = new StreamWriter(caminhoCsv);

                writer.WriteLine("ID,Cliente,Produto,Quantidade,Preço Unitário,Data");

                while (reader.Read())
                {
                    writer.WriteLine($"{reader.GetInt32(0)},{reader.GetString(1)},{reader.GetString(2)},{reader.GetInt32(3)},{reader.GetDecimal(4):C},{reader.GetDateTime(5):dd/MM/yyyy}");
                }

                Console.WriteLine($"Relatório CSV gerado com sucesso: {caminhoCsv}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gerar relatório CSV: {ex.Message}");
            }
        }


    }
}
