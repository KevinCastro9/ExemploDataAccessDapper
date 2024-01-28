using Dapper;
using ExemploDataAccessDapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploDataAccessDapper.Repository
{
    public class RepositoryExecuteScalar
    {
        Connection.Connection conn = new Connection.Connection();
        public RepositoryExecuteScalar()
        {

        }

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
                using (var connection = conn.OpenConection())
                {
                    var id = connection.ExecuteScalar<Guid>(insertSql, new
                    {
                        category.Title,
                        category.Url,
                        category.Summary,
                        category.Order,
                        category.Description,
                        category.Featured
                    });

                    return id;
                }
            }
            catch (Exception ex)
            {
                return new Guid();
            }
        }
    }
}
