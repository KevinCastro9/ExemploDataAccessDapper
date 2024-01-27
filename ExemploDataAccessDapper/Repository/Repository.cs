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

        //Inserindo um item no banco
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

        //Inserindo diversos itens de uma vez no banco
        public bool InsertManyCategory(List<Category> categorys)
        {
            try
            {
                //Criando a query
                var insertSql = "INSERT INTO [Category] VALUES (@id, @title, @url, @summary, @order, @description, @featured)";

                //Executando a query e passando os parametros
                using (var connection = conn.OpenConection())
                {
                    var rows = connection.Execute(insertSql, new[] {
                        new
                    {
                        categorys[0].Id,
                        categorys[0].Title,
                        categorys[0].Url,
                        categorys[0].Summary,
                        categorys[0].Order,
                        categorys[0].Description,
                        categorys[0].Featured
                    },
                    new
                    {
                        categorys[1].Id,
                        categorys[1].Title,
                        categorys[1].Url,
                        categorys[1].Summary,
                        categorys[1].Order,
                        categorys[1].Description,
                        categorys[1].Featured
                    }
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

        //Alterando um item no banco
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

        //Alterando diversos itens de uma vez no banco
        public bool UpdateManyCategory(List<Category> categorys)
        {
            try
            {
                //Criando a query  
                var updateSql = "UPDATE [Category] SET [Title] = @title, [Url] = @url, [Summary] = @summary, [Order] = @order, [Description] = @description, [Featured] = @featured WHERE [Id] = @id";

                //Realizando a conexão com o banco 
                using (var connection = conn.OpenConection())
                {
                    //Executando a query e passando os parametros
                    var rows = connection.Execute(updateSql, new[] {
                        new
                        {
                            categorys[0].Id,
                            categorys[0].Title,
                            categorys[0].Url,
                            categorys[0].Summary,
                            categorys[0].Order,
                            categorys[0].Description,
                            categorys[0].Featured
                        },
                        new
                        {
                            categorys[1].Id,
                            categorys[1].Title,
                            categorys[1].Url,
                            categorys[1].Summary,
                            categorys[1].Order,
                            categorys[1].Description,
                            categorys[1].Featured
                        }
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

        //Deletando um item no banco
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

        //Deletando diversos itens de uma vez no banco
        public bool DeleteManyCategory(List<Category> categorys)
        {
            try
            {
                //Criando a query
                var deleteSql = "DELETE FROM [Category] WHERE [Id] = @id";

                //Realizando a conexão com o banco 
                using (var connection = conn.OpenConection())
                {
                    //Executando a query
                    var rows = connection.Execute(deleteSql, new[] { new { categorys[0].Id }, new { categorys[1].Id } });

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

        //Selecionando uma lista no banco
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

        //Selecionando um item no banco
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
