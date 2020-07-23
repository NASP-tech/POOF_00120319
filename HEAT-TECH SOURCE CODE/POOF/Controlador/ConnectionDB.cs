using System.Data;
using Npgsql;

namespace POOF.Controlador
{
    public static class ConnectionDB
    {
        private static string cadenaC = "Server=Localhost;" +
                                        "Port=5432;" +
                                        "UserId=postgres;" +
                                        "Password=natalia.99;" +
                                        "Database=HEATTECHPOOF;";

        public static DataTable ExecuteQuery(string consulta)
        {
            var conn = new NpgsqlConnection(cadenaC);
            var ds = new DataSet();

            conn.Open();
            var da = new NpgsqlDataAdapter(consulta, conn);
            da.Fill(ds);
            conn.Close();

            return ds.Tables[0];
        }

        public static int EjecutaEscalar(string consulta)
        {
            var conn = new NpgsqlConnection(cadenaC);
            
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand(consulta, conn);
            int count = (int)command.ExecuteScalar();
            conn.Close();

            return count;
        }

        public static void ExecuteNonQuery(string comando)
        {
            var conn = new NpgsqlConnection(cadenaC);

            conn.Open();
            var comm = new NpgsqlCommand(comando, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}