using Dapper;
using ExemploDataAccessDapper.Connection;
using ExemploDataAccessDapper.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploDataAccessDapper.Repository
{
    public class RepositoryViews
    {
        private Connection.Connection conn = new Connection.Connection();
        private readonly SqlConnection _sqlConnection;

        // => serve para substituir as chaves caso o método tenha apenas uma linha
        public RepositoryViews()
         => _sqlConnection = conn.OpenConection(); //Realizando a conexão com o banco

        //Executando uma View 
        public IEnumerable<Course> ExecuteVwCourses()
        {
            try
            {
                //Criando a query
                var selectView = "SELECT * FROM [vwCourses]";

                //Quando o retorno da query é uma lista voce utiliza o "Query<>"
                return _sqlConnection.Query<Course>(selectView);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
