using Dapper;
using ExemploDataAccessDapper.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploDataAccessDapper.Repository
{
    public class RepositorySelectInAndLike
    {
        Connection.Connection conn = new Connection.Connection();
        public RepositorySelectInAndLike()
        {

        }

        //Realizando um select na tabela Carrer utilizando o IN
        public List<Career> SelectInCarrer(List<Guid> idList)
        {
            //Criando a query
            var query = @"SELECT * FROM [Career] WHERE [Id] IN @Id";

            //Realizando a conexão com o banco 
            using (var connection = conn.OpenConection())
            {

                var items = connection.Query<Career>(query, new
                {
                    //Passando o atributo da query em forma de vetor
                    Id = new[]{
                    idList[0],
                    idList[1],
                }
                });

                return (List<Career>)items;
            }
        }

        //Realizando um select na tabela Course utilizando o Like
        public List<Course> SelectLikeCourse(string term)
        {
            //Criando a query
            var query = @"SELECT * FROM [Course] WHERE [Title] LIKE @exp";

            //Realizando a conexão com o banco 
            using (var connection = conn.OpenConection())
            {
                var items = connection.Query<Course>(query, new
                {
                    //Passando a palavra que vai ser consultada e a localidade dela
                    exp = $"%{term}%"
                });

                return (List<Course>)items;
            }
        }
    }
}
