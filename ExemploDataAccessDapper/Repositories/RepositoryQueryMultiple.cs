using Dapper;
using ExemploDataAccessDapper.Connection;
using ExemploDataAccessDapper.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ExemploDataAccessDapper.Repository
{
    public class RepositoryQueryMultiple
    {
        private Connection.Connection conn = new Connection.Connection();
        private readonly SqlConnection _sqlConnection;

        // => serve para substituir as chaves caso o método tenha apenas uma linha
        public RepositoryQueryMultiple()
         => _sqlConnection = conn.OpenConection(); //Realizando a conexão com o banco

        //Executando dois selects de um só vez
        public void SelectListCategoryAndSelectListCourse()
        {
            try
            {
                //Criando a query com multiplos selects
                var query = "SELECT * FROM [Category]; SELECT * FROM [Course]";

                //Nesse caso é necessario utilizar o "QueryMultiple()"
                using (var multi = _sqlConnection.QueryMultiple(query))
                {
                    //E dentro da variavel que voce criou voce pode ler os objetos dessa forma
                    var categories = multi.Read<Category>();
                    var courses = multi.Read<Course>();

                    foreach (var item in categories)
                    {
                        Console.WriteLine(item.Title);
                    }

                    foreach (var item in courses)
                    {
                        Console.WriteLine(item.Title);
                    }
                }
            }
            catch (Exception ex)
            {
               
            }
        }
    }
}
