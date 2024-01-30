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
    public class RepositoryOneToMany
    {
        private Connection.Connection conn = new Connection.Connection();
        private readonly SqlConnection _sqlConnection;

        // => serve para substituir as chaves caso o método tenha apenas uma linha
        public RepositoryOneToMany()
         => _sqlConnection = conn.OpenConection(); //Realizando a conexão com o banco

        /* Realizando um select Inner join (um pra muitos) */
        public IEnumerable<Career> SelectOneToMany()
        {
            try
            {
                /* Nesse caso eu tenho uma lista de objetos CareerItem dentro do objeto Career então dentro do QUERY()
                  preciso informar para que ele consiga organizar da forma correta */

                //Criando a query
                var sql = @"
                SELECT 
                    [Career].[Id],
                    [Career].[Title],
                    [CareerItem].[CareerId],
                    [CareerItem].[Title]
                FROM 
                    [Career] 
                INNER JOIN 
                    [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
                ORDER BY
                    [Career].[Title]";

                //Lista externa que vai ser o retorno do método
                var careers = new List<Career>();

                /*No tipo do objeto dentro de QUERY() voce deve informar na seguinte ordem <TabelaPrincipal, TabelaDoJoin, TabelaPrincipal>
                     essa ordem se trata de as duas primeiras serem as tabelas que vão retornar na query e a terceira informando dentro de qual tabela vai ser o retorno
                    como nesse caso nosso objeto principal é o Career se passa ela na terceira posição*/

                var items = _sqlConnection.Query<Career, CareerItem, Career>( // lembrando que podem ser N objetos "<Career, CareerItem, Category, Career>" o importante é o ultimo ser sempre o Principal
                    sql,
                    (career, item) => //Aqui voce vai passar o dois objetos que vão ser adicionadas as tabelas
                    {
                        /*Aqui dentro voce possui os objetos das duas tabelas e pode fazer o tratamento que quiser neles */

                        //Aqui voce está verificando se o item já existe dentro da lista externa que voce criou "linha 43"
                        var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();

                        if (car == null)
                        {
                            //caso não exista 

                            //Voce cria o item que vai receber as duas tabelas primeira adicionando a tabela principal
                            car = career;
                            //Depois adicionando a tabela relacionada na sua respectiva variavel
                            car.Items.Add(item);
                            //e agora sim voce adiciona na lista que vai ser o retorno do método
                            careers.Add(car);
                        }
                        else
                        {
                            //Caso a carrer já exista voce adiciona apenas o Item da carreira 
                            car.Items.Add(item);
                        }

                        return career;
                    }, splitOn: "CareerId"); /*Nessa linha voce passa qual o campo que divide as duas tabelas, pois no select vai retornar como se fosse apenas
                                            * uma tabela, dai voce tem que passar o primeiro campo da segunda tabela que seria o campo Id nesse caso */


                return careers;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
