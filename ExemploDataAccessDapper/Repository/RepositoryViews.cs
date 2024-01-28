using Dapper;
using ExemploDataAccessDapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploDataAccessDapper.Repository
{
    public class RepositoryViews
    {
        Connection.Connection conn = new Connection.Connection();
        public RepositoryViews()
        {

        }

        //Executando uma View 
        public List<Course> ExecuteVwCourses()
        {
            try
            {
                //Criando a query
                var selectView = "SELECT * FROM [vwCourses]";

                //Realizando a conexão com o banco 
                using (var connection = conn.OpenConection())
                {
                    //Quando o retorno da query é uma lista voce utiliza o "Query<>"
                    return (List<Course>)connection.Query<Course>(selectView); ;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
