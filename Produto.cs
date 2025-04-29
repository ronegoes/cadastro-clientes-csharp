namespace cadastro1
{
    internal class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }

        public void Exibir()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Preço: R${Preco}");
            Console.WriteLine($"Descrição: {Descricao}");
            Console.WriteLine($"Quantidade em estoque: {Quantidade}");
            Console.WriteLine("****************");
        }
    }
}
