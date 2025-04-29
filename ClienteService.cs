using System;
using Npgsql;

namespace cadastro1
{
    public class ClienteService
    {
        public void CadastrarCliente(string nome, string cpf, string email, string tipo)
        {
            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = new NpgsqlCommand("INSERT INTO clientes (nome, cpf, email, tipo) VALUES (@nome, @cpf, @email, @tipo)", conn);
            cmd.Parameters.AddWithValue("nome", nome);
            cmd.Parameters.AddWithValue("cpf", cpf);
            cmd.Parameters.AddWithValue("email", email);
            cmd.Parameters.AddWithValue("tipo", tipo);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Cliente cadastrado com sucesso!\n");
        }

        public void ListarClientes()
        {
            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = new NpgsqlCommand("SELECT * FROM clientes", conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["id"]}");
                Console.WriteLine($"Nome: {reader["nome"]}");
                Console.WriteLine($"CPF: {reader["cpf"]}");
                Console.WriteLine($"Email: {reader["email"]}");
                Console.WriteLine($"Tipo: {reader["tipo"]}");
                Console.WriteLine("-----------------------------------");
            }
        }

        public Cliente BuscarClientePorCpf(string cpf)
        {
            Cliente cliente = null;

            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = new NpgsqlCommand("SELECT * FROM clientes WHERE cpf = @cpf", conn);
            cmd.Parameters.AddWithValue("cpf", cpf);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                cliente = new Cliente
                {
                    Id = (int)reader["id"],
                    Nome = reader["nome"].ToString(),
                    Cpf = reader["cpf"].ToString(),
                    Email = reader["email"].ToString(),
                    Tipo = reader["tipo"].ToString()
                };
            }

            return cliente;
        }

        public void EditarCliente(int id, string novoNome, string novoCpf, string novoEmail, string novoTipo)
        {
            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = new NpgsqlCommand("UPDATE clientes SET nome = @nome, cpf = @cpf, email = @email, tipo = @tipo WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("nome", novoNome);
            cmd.Parameters.AddWithValue("cpf", novoCpf);
            cmd.Parameters.AddWithValue("email", novoEmail);
            cmd.Parameters.AddWithValue("tipo", novoTipo);

            int rowsAffected = cmd.ExecuteNonQuery();
            Console.WriteLine(rowsAffected > 0 ? "Cliente atualizado com sucesso!\n" : "Cliente não encontrado.\n");
        }
        public void BuscarCliente(string nome)
        {
            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = new NpgsqlCommand("SELECT * FROM clientes WHERE LOWER(nome) LIKE @nome", conn);
            cmd.Parameters.AddWithValue("nome", "%" + nome.ToLower() + "%");

            using var reader = cmd.ExecuteReader();
            bool encontrado = false;

            while (reader.Read())
            {
                encontrado = true;
                Console.WriteLine($"ID: {reader["id"]}");
                Console.WriteLine($"Nome: {reader["nome"]}");
                Console.WriteLine($"CPF: {reader["cpf"]}");
                Console.WriteLine($"Email: {reader["email"]}");
                Console.WriteLine($"Tipo: {reader["tipo"]}");
                Console.WriteLine("-----------------------------------");
            }

            if (!encontrado)
                Console.WriteLine("Nenhum cliente encontrado.\n");
        }


        public void DeletarCliente(int id)
        {
            using var conn = Database.GetConnection();
            conn.Open();

            var cmd = new NpgsqlCommand("DELETE FROM clientes WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("id", id);

            int rowsAffected = cmd.ExecuteNonQuery();
            Console.WriteLine(rowsAffected > 0 ? "Cliente deletado com sucesso!\n" : "Cliente não encontrado.\n");
        }
    }
}
