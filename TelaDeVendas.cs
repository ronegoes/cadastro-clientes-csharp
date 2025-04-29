using System;
using System.IO;
using Npgsql;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace cadastro1
{
    public class TelaDeVendas
    {
        // Método para buscar cliente por CPF
        public Cliente BuscarClientePorCpf(string cpf)
        {
            Cliente cliente = null;

            try
            {
                using var conn = new NpgsqlConnection("Host=localhost;Username=postgres;Password=978564;Database=SistemaCadastroCsharp");
                conn.Open();

                var cmd = new NpgsqlCommand("SELECT id, nome, cpf, email, tipo FROM clientes WHERE cpf = @cpf", conn);
                cmd.Parameters.AddWithValue("cpf", cpf);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    cliente = new Cliente
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Cpf = reader.GetString(2),
                        Email = reader.GetString(3),
                        Tipo = reader.GetString(4)
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao buscar cliente: " + ex.Message);
            }

            return cliente;
        }
        public void RegistrarVenda(int clienteId, string nomeProduto, int quantidade, decimal precoUnitario)
        {
            try
            {
                using var conn = new NpgsqlConnection("Host=localhost;Username=postgres;Password=978564;Database=SistemaCadastroCsharp");
                conn.Open();

                var cmd = new NpgsqlCommand(@"
            INSERT INTO venda (cliente_id, produto_nome, quantidade, preco_unitario) 
            VALUES (@cliente_id, @produto_nome, @quantidade, @preco_unitario)", conn);

                cmd.Parameters.AddWithValue("cliente_id", clienteId);
                cmd.Parameters.AddWithValue("produto_nome", nomeProduto);
                cmd.Parameters.AddWithValue("quantidade", quantidade);
                cmd.Parameters.AddWithValue("preco_unitario", precoUnitario);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Venda registrada com sucesso no banco de dados.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao registrar venda: " + ex.Message);
            }
        }


        // Método principal para iniciar a venda
        public void IniciarVenda()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("CPF do cliente: ");
            Console.ResetColor();
            string cpf = Console.ReadLine();

            

            Cliente cliente = BuscarClientePorCpf(cpf);

            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                return;
            }

            Console.Write("Nome do Produto: ");
            string nomeProduto = Console.ReadLine();

            Console.Write("Quantidade: ");
            if (!int.TryParse(Console.ReadLine(), out int quantidade))
            {
                Console.WriteLine("Quantidade inválida.");
                return;
            }

            Console.Write("Preço Unitário: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal preco))
            {
                Console.WriteLine("Preço inválido.");
                return;
            }
            GerarPdfVenda(cliente.Id, cliente.Nome, cliente.Cpf, nomeProduto, quantidade, preco);
            RegistrarVenda(cliente.Id, nomeProduto, quantidade, preco); // <- Adicione esta linha

            // GerarPdfVenda(cliente.Id, cliente.Nome, cliente.Cpf, nomeProduto, quantidade, preco);
        }

        // Método para gerar PDF da venda com iTextSharp 5
        public void GerarPdfVenda(int idCliente, string nomeCliente, string cpfCliente, string nomeProduto, int quantidade, decimal precoUnitario)
        {
            string caminhoPdf = Path.Combine(Directory.GetCurrentDirectory(), $"venda_cliente_{idCliente}.pdf");

            try
            {
                using (var fs = new FileStream(caminhoPdf, FileMode.Create))
                {
                    var doc = new Document();
                    var writer = PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    var fonteNegrito = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                    var fonteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 12);

                    doc.Add(new Paragraph("Fatura de Venda", fonteNegrito));
                    doc.Add(new Paragraph($"Cliente: {nomeCliente}", fonteNormal));
                    doc.Add(new Paragraph($"CPF: {cpfCliente}", fonteNormal));
                    doc.Add(new Paragraph($"Produto: {nomeProduto}", fonteNormal));
                    doc.Add(new Paragraph($"Quantidade: {quantidade}", fonteNormal));
                    doc.Add(new Paragraph($"Preço Unitário: {precoUnitario:C}", fonteNormal));
                    doc.Add(new Paragraph($"Valor Total: {(quantidade * precoUnitario):C}", fonteNormal));

                    doc.Close();
                }

                Console.WriteLine("PDF gerado com sucesso: " + caminhoPdf);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("PDF gerado com sucesso: " + caminhoPdf);
                Console.ResetColor();

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro ao gerar PDF: " + ex.Message);
                Console.ResetColor();

            }
        }
    
        private void MensagemColorida(string texto, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(texto);
            Console.ResetColor();
        }

    }
}
