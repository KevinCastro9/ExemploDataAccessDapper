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
    public class RepositoryExecuteScalar
    {
        private Connection.Connection conn = new Connection.Connection();
        private readonly SqlConnection _sqlConnection;

        // => serve para substituir as chaves caso o método tenha apenas uma linha
        public RepositoryExecuteScalar()
         => _sqlConnection = conn.OpenConection(); //Realizando a conexão com o banco

        //Inserindo um item no banco com ExecuteScalar (Retornando o Id)
        public Guid InsertExecuteScalarCategory(Category category)
        {
            try
            {

                /*Criando a query 
                  Lembrar de adicionar o comando "OUTPUT inserted.[Id]" 
                  para que retorne o Id que foi inserido nessa query */
                var insertSql = "INSERT INTO [Category] OUTPUT inserted.[Id] VALUES (NEWID(), @title, @url, @summary, @order, @description, @featured)";

                //Executando a query e passando os parametros
                return _sqlConnection.ExecuteScalar<Guid>(insertSql, new
                {
                    category.Title,
                    category.Url,
                    category.Summary,
                    category.Order,
                    category.Description,
                    category.Featured
                });
            }
            catch (Exception ex)
            {
                return new Guid();
            }
        }
    }
}
