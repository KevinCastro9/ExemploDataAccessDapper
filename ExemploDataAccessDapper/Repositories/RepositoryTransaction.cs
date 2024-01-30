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
        private Connection.Connection conn = new Connection.Connection();
        private readonly SqlConnection _sqlConnection;

        // => serve para substituir as chaves caso o método tenha apenas uma linha
        public RepositoryTransaction()
         => _sqlConnection = conn.OpenConection(); //Realizando a conexão com o banco

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

                //Lembrando que quando voce utiliza o Begin transaction é necessario abrir a conexao
                _sqlConnection.Open();

                //Criando o Begin Transaction
                using (var transaction = _sqlConnection.BeginTransaction())
                {
                    try
                    {
                        //Executando o insert
                        var rows = _sqlConnection.Execute(insertSql, new
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
                        _sqlConnection.Close(); //Lembrar de fechar 
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); //Mandando desfazer e realizar o RollBack
                        _sqlConnection.Close(); //Lembrar de fechar 
                        return false;
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
