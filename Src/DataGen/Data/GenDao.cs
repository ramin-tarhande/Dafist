using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace DataGen.Data
{
    class GenDao
    {
        private readonly string connectionString;
        public GenDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int? GetMaxMySourceId()
        {
            var sqlText = "Select max(Id1) from MySource";
            using (var connection = OpenConnection())
            {
                var r=connection.Query<int?>(sqlText);
                return r.FirstOrDefault();
            }
        }

        public int? GetMaxCommentId()
        {
            var sqlText = "Select max(Id) from Comment";
            using (var connection = OpenConnection())
            {
                var r = connection.Query<int?>(sqlText);
                return r.FirstOrDefault();
            }
        }

        public async Task Insert(MySource r)
        {
            var sqlText = @"INSERT INTO MySource(Id1,Id2,Title,Description,IdU) VALUES(@Id1,@Id2,@Title,@Description,@IdU)";
            using (var connection = OpenConnection())
            {
                await connection.ExecuteAsync(sqlText,new {r.Id1,r.Id2,r.Title,r.Description,r.IdU});
            }
        }

        public async Task Insert(Comment r)
        {
            var sqlText = @"INSERT INTO Comment(Id,Text,CategoryId,MoodId,AuthorId) VALUES(@Id,@Text,@CategoryId,@MoodId,@AuthorId)";
            using (var connection = OpenConnection())
            {
                await connection.ExecuteAsync(sqlText, new { r.Id, r.Text,r.CategoryId, r.MoodId, r.AuthorId });
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
