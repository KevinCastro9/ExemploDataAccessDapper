using ExemploDataAccessDapper.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploDataAccessDapper.Connection
{
    public class Connection
    {
        //Criando a String de conexão
        private const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";
        public Connection() {}

        public SqlConnection OpenConection()
        {
            //Exemplo de Conexão com o banco de dados utilizando o Dapper

            /* Lembrar de instalar o Package/Pacote "Microsoft.Data.SqlClient" 
              e o Package/Pacote do Dapper */

            //Criando a conexão com o banco
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;

            return conn;
        }

    }
}
