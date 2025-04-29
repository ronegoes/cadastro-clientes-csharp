using System;

namespace cadastro1
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Tipo { get; set; }

        public void ExibirDados()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"CPF: {Cpf}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Tipo: {Tipo}");
            Console.WriteLine("-----------------------------------");
        }
    }
}
