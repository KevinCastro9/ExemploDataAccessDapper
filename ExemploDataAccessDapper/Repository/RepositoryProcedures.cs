using Dapper;
using ExemploDataAccessDapper.Connection;
using ExemploDataAccessDapper.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploDataAccessDapper.Repository
{
    public class RepositoryProcedures
    {
        Connection.Connection conn = new Connection.Connection();
        public RepositoryProcedures()
        {

        }

        //Executando uma procedure que não retorna valores
        public bool ExecuteSpDeleteStudent(Guid id)
        {
            try
            {
                /* Informando qual a Procedure que vai ser executada */
                var procedure = "[spDeleteStudent]";

                //Criando os parametros que a procedure recebe. Caso tenha mais de um apenas separar por virgula dentro das {}
                var pars = new { StudentId = id };

                using (var connection = conn.OpenConection())
                {
                    //Executando informando o CommandType que é o StoredProcedure 
                    var rows = connection.Execute(procedure, pars, commandType: CommandType.StoredProcedure);

                    if (rows > 0)
                    {
                        return true;
                    }

                    return false;
                }    
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Executando uma procedure que retorna valores
        public IEnumerable<dynamic> ExecutespGetCoursesByCategory(Guid id)
        {
            try
            {
                /* Informando qual a Procedure que vai ser executada */
                var procedure = "[spGetCoursesByCategory]";

                //Criando os parametros que a procedure recebe. Caso tenha mais de um apenas separar por virgula dentro das {}
                var pars = new { CategoryId = id };

                using (var connection = conn.OpenConection())
                {
                    /*Executando informando o CommandType que é o StoredProcedure 
                      a execução está sendo feita com o comando Query() sem passar qual objeto de retorno
                      então ele retorna um dynamic */
                    var courses = connection.Query(procedure, pars, commandType: CommandType.StoredProcedure);

                    return courses;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
