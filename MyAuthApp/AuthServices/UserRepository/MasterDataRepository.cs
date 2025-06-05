using AuthIservices.Entities;
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
    public class MasterDataRepository : IMasterDataRepositoy
    {
        private readonly string _connectionString; //

        public MasterDataRepository(IConfiguration configuration) // Added constructor
        {
            _connectionString = configuration.GetConnectionString("MyDb");
        }

       

        public List<ModulesList> GetModulesLists ()
        {
            List<ModulesList> list = new List<ModulesList>();
            DataTable dt = new DataTable();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("[dbo].[GetModuleListTypes]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            foreach (DataRow dataRow in dt.Rows)
            {
                ModulesList mdl = new ModulesList
                {
                    ModuleListTypeId = Convert.ToInt32(dataRow["ModuleListTypeId"]),
                    ModuleListTypeName = Convert.ToString(dataRow["ModuleListTypeName"])
                };

                list.Add(mdl);
            }

            return list;
        }
    }
}
