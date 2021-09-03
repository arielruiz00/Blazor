using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using Web2021B.Data.Model;

namespace Web2021B.Data.Service
{
    public class ClienteService : IClienteService
    {
        //Connecction Sql Server
        private readonly SqlConnectionConfiguration _configuration;

        public ClienteService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> ClienteInsert(Cliente cliente)
        {

            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("IdCliente", cliente.IdCliente, DbType.Int32);
                parameters.Add("NombreCliente", cliente.NombreCliente, DbType.String);
                parameters.Add("ApellidoCliente", cliente.ApellidoCliente, DbType.String);

                const string query = @"INSERT INTO Cliente (IdCliente, NombreCliente, ApellidoCliente) VALUES (@IdCliente, @NombreCliente, @ApellidoCliente)";
                await conn.ExecuteAsync(query, new { cliente.IdCliente, cliente.NombreCliente, cliente.ApellidoCliente }, commandType: CommandType.Text);
            }

            return true;
        }

    }
}
