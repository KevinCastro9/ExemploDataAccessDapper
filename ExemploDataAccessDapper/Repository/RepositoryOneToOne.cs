using Dapper;
using ExemploDataAccessDapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploDataAccessDapper.Repository
{
    public class RepositoryOneToOne
    {
        Connection.Connection conn = new Connection.Connection();
        public RepositoryOneToOne()
        {

        }

        /* Realizando um select Inner join (um pra um)*/
        public List<CareerItem> SelectOneToOne()
        {
            try
            {
                /* Nesse caso eu tenho o objeto Course dentro do objeto CareerItem então dentro do QUERY()
                  preciso informar para que ele consiga organizar da forma correta */

                //Criando a query
                var sql = "SELECT [CareerItem].[CareerId], [CareerItem].[CourseId], [CareerItem].[Title], [CareerItem].[Description], [Course].[Id], [Course].[Title], [Course].[Summary] FROM [CareerItem] INNER JOIN [Course] ON [CareerItem].[CourseId] = [Course].[Id]";

                //Realizando a conexão com o banco 
                using (var connection = conn.OpenConection())
                {
                    /*No tipo do objeto dentro de QUERY() voce deve informar na seguinte ordem <TabelaPrincipal, TabelaDoInnerJoin, TabelaPrincipal>
                     essa ordem se trata de as duas primeiras serem as tabelas que vão retornar na query e a terceira informando dentro de qual tabela vai ser o retorno
                    como nesse caso nosso objeto principal é o CarrerItem se passa ela */

                    var items = connection.Query<CareerItem, Course, CareerItem>(
                        sql,
                        (careerItem, course) => //Aqui voce vai passar o dois objetos que vão ser adicionadas as tabelas
                        {           
                            careerItem.Course = course; //Dai voce utiliza o objeto da tabela principal para informar em qual objeto vai ser adicionada a tabela relacionada
                            return careerItem;
                        }, splitOn: "Id"); /*Nessa linha voce passa qual o campo que divide as duas tabelas, pois no select vai retornar como se fosse apenas
                                            * uma tabela, dai voce tem que passar o primeiro campo da segunda tabela que seria o campo Id nesse caso */


                    return (List<CareerItem>)items;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
