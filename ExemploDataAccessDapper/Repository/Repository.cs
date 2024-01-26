using Dapper;
using ExemploDataAccessDapper.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExemploDataAccessDapper.Connection;


namespace ExemploDataAccessDapper.Repository
{
    public class Repository
    {
        Connection.Connection conn = new Connection.Connection();
        public Repository() 
        {
            
        }

        public bool InsertCategory(Category category)
        {
            try
            {
                //Criando a query
                var insertSql = "INSERT INTO [Category] VALUES (@id, @title, @url, @summary, @order, @description, @featured)";

                //Executando a query e passando os parametros
                using (var connection = conn.OpenConection())
                {
                    var rows = connection.Execute(insertSql, new
                    {
                        category.Id,
                        category.Title,
                        category.Url,
                        category.Summary,
                        category.Order,
                        category.Description,
                        category.Featured
                    });

                    if (rows > 0)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch(Exception ex) 
            {
                return false;
            }          
        }

        public bool UpdateCategory(Category category)
        {
            try
            {
                //Criando a query  
                var updateSql = "UPDATE [Category] SET [Title] = @title, [Url] = @url, [Summary] = @summary, [Order] = @order, [Description] = @description, [Featured] = @featured WHERE [Id] = @id";

                //Realizando a conexão com o banco 
                using (var connection = conn.OpenConection())
                {
                    //Executando a query e passando os parametros
                    var rows = connection.Execute(updateSql, new
                    {
                        category.Id,
                        category.Title,
                        category.Url,
                        category.Summary,
                        category.Order,
                        category.Description,
                        category.Featured
                    });

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

        public bool DeleteCategory(Guid id)
        {
            try
            {
                //Criando a query
                var deleteSql = "DELETE FROM [Category] WHERE [Id] = @id";

                //Realizando a conexão com o banco 
                using (var connection = conn.OpenConection())
                {
                    //Executando a query
                    var rows = connection.Execute(deleteSql, new {id});

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

        public List<Category> SelectListCategory()
        {
            try
            {
                //Criando a query
                var selectListSql = "SELECT [Id], [Title], [Url], [Summary], [Order], [Description], [Featured]  FROM [Category]";

                //Realizando a conexão com o banco 
                using (var connection = conn.OpenConection())
                {
                    //Quando o retorno da query é uma lista voce utiliza o "Query<>"
                    return (List<Category>)connection.Query<Category>(selectListSql);;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Category SelectCategoryId(Guid id)
        {
            try
            {
                //Criando a query
                var selectListSql = "SELECT [Id], [Title], [Url], [Summary], [Order], [Description], [Featured]  FROM [Category] WHERE [Id] = @id";

                //Realizando a conexão com o banco 
                using (var connection = conn.OpenConection())
                {
                    //Quando o retorno da query é uma lista voce utiliza o "Query<>"
                    return connection.QueryFirst<Category>(selectListSql, new { id });
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
