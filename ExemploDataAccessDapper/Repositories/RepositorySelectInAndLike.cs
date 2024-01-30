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
    public class RepositorySelectInAndLike
    {
        private Connection.Connection conn = new Connection.Connection();
        private readonly SqlConnection _sqlConnection;

        // => serve para substituir as chaves caso o método tenha apenas uma linha
        public RepositorySelectInAndLike()
         => _sqlConnection = conn.OpenConection(); //Realizando a conexão com o banco

        //Realizando um select na tabela Carrer utilizando o IN
        public IEnumerable<Career> SelectInCarrer(List<Guid> idList)
        {
            try
            {
                //Criando a query
                var query = @"SELECT * FROM [Career] WHERE [Id] IN @Id";

                return _sqlConnection.Query<Career>(query, new
                {
                    //Passando o atributo da query em forma de vetor
                    Id = new[]{
                    idList[0],
                    idList[1],
                }
                });
            }
            catch
            {
                return null;
            }
        }

        //Realizando um select na tabela Course utilizando o Like
        public IEnumerable<Course> SelectLikeCourse(string term)
        {
            try
            {
                //Criando a query
                var query = @"SELECT * FROM [Course] WHERE [Title] LIKE @exp";

                return _sqlConnection.Query<Course>(query, new
                {
                    //Passando a palavra que vai ser consultada e a localidade dela
                    exp = $"%{term}%"
                });
            }
            catch
            {
                return null;
            }
        }
    }
}
