using AuthIservices.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServices.UserRepository
{
    public class DiaryRepository:IDiaryRepository
    {


        private readonly string _connectionString;

        public DiaryRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MyDb");
        }

        public int CreateNote(DiaryEntry diary)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Title", diary.Title);
                parameters.Add("@Content", diary.Content);
                parameters.Add("@UserId", diary.UserId);
                parameters.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("[dbo].[CreateNote]", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("@Id");

                
            }
        }
    }
}
