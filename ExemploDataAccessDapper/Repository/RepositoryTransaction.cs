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
    public class RepositoryTransaction
    {
        Connection.Connection conn = new Connection.Connection();
        public RepositoryTransaction()
        {

        }

        //Realizando um insert dentro de um Begin Transaction
        public bool InsertTransactionCategory(Category category)
        {
            try
            {
                var insertSql = @"INSERT INTO 
                    [Category] 
                VALUES(
                    @Id, 
                    @Title, 
                    @Url, 
                    @Summary, 
                    @Order, 
                    @Description, 
                    @Featured)";

                //Abrindo a conexão
                using (var connection = conn.OpenConection())
                {
                    //Lembrando que quando voce utiliza o Begin transaction é necessario abrir a conexao
                    connection.Open();

                    //Criando o Begin Transaction
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            //Executando o insert
                            var rows = connection.Execute(insertSql, new
                            {
                                category.Id,
                                category.Title,
                                category.Url,
                                category.Summary,
                                category.Order,
                                category.Description,
                                category.Featured
                            }, transaction);//informando que ele esta dentro de um Begin Transaction 

                            transaction.Commit(); //Mandando prosseguir e realizar o commit
                            connection.Close(); //Lembrar de fechar 
                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback(); //Mandando desfazer e realizar o RollBack
                            connection.Close(); //Lembrar de fechar 
                            return false;
                        }

                    }
                }
            }
            catch
            {
                return false;
            }         
        }
    }
}
