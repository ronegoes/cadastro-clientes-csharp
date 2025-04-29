using Npgsql;

namespace cadastro1
{
    public static class Database
    {
        private static string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=978564;Database=SistemaCadastroCsharp";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }
    }
}
