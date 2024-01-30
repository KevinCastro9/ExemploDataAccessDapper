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
    public class RepositoryOneToOne
    {
        private Connection.Connection conn = new Connection.Connection();
        private readonly SqlConnection _sqlConnection;

        // => serve para substituir as chaves caso o método tenha apenas uma linha
        public RepositoryOneToOne()
         => _sqlConnection = conn.OpenConection(); //Realizando a conexão com o banco

        /* Realizando um select Inner join (um pra um)*/
        public IEnumerable<CareerItem> SelectOneToOne()
        {
            try
            {
                /* Nesse caso eu tenho o objeto Course dentro do objeto CareerItem então dentro do QUERY()
                  preciso informar para que ele consiga organizar da forma correta */

                //Criando a query
                var sql = "SELECT [CareerItem].[CareerId], [CareerItem].[CourseId], [CareerItem].[Title], [CareerItem].[Description], [Course].[Id], [Course].[Title], [Course].[Summary] FROM [CareerItem] INNER JOIN [Course] ON [CareerItem].[CourseId] = [Course].[Id]";

                /*No tipo do objeto dentro de QUERY() voce deve informar na seguinte ordem <TabelaPrincipal, TabelaDoInnerJoin, TabelaPrincipal>
                     essa ordem se trata de as duas primeiras serem as tabelas que vão retornar na query e a terceira informando dentro de qual tabela vai ser o retorno
                    como nesse caso nosso objeto principal é o CarrerItem se passa ela */
                return _sqlConnection.Query<CareerItem, Course, CareerItem>(
                    sql,
                    (careerItem, course) => //Aqui voce vai passar o dois objetos que vão ser adicionadas as tabelas
                    {
                        careerItem.Course = course; //Dai voce utiliza o objeto da tabela principal para informar em qual objeto vai ser adicionada a tabela relacionada
                        return careerItem;
                    }, splitOn: "Id"); /*Nessa linha voce passa qual o campo que divide as duas tabelas, pois no select vai retornar como se fosse apenas
                                            * uma tabela, dai voce tem que passar o primeiro campo da segunda tabela que seria o campo Id nesse caso */
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
