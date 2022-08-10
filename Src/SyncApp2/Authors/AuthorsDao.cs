using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace SyncApp2.Authors
{
    public class AuthorsDao
    {
        private readonly string connectionString;
        public AuthorsDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        internal Author LoadAuthor(int id)
        {
            const string sqlText = @"Select * from Author where Id=@id";
            using (var connection = OpenConnection())
            {
                return connection.Query<Author>(sqlText, new { id }).FirstOrDefault();
            }
        }

        SqlConnection OpenConnection()
        {
            var c = new SqlConnection(connectionString);
            c.Open();
            return c;
        }
    }
}
