


/*Lembrar de instalar o Package/Pacote "Microsoft.Data.SqlClient" 
              e o Package/Pacote do Dapper*/


using ExemploDataAccessDapper.Models;
using ExemploDataAccessDapper.Repository;

Repository repository = new Repository();
RepositoryProcedures repositoryProcedures = new RepositoryProcedures();

Category category1 = new Category();
Category category2 = new Category();

List<Category> categoryList = new List<Category>();


////Console.WriteLine("----------------------- INSERT ------------------------------------------");

//category1.Id = Guid.Parse("2d786b71-a360-4fda-a743-874aae14c4d9");
//category1.Title = "Test";
//category1.Url = "teste";
//category1.Summary = "teste";
//category1.Order = 1;
//category1.Description = "Test descricao";
//category1.Featured = true;

//bool retornoInsert = repository.InsertCategory(category1);

//if (retornoInsert == true)
//{
//    Console.WriteLine("Inserido com sucesso!!");
//}
//else
//{
//    Console.WriteLine("Não foi possivel inserir!!");
//}

////Console.WriteLine("----------------------- INSERT MULTIPLO ------------------------------------------");

//category2.Id = Guid.Parse("2d786b71-a360-4fda-a743-874aae14c4d8");
//category2.Title = "Test mult";
//category2.Url = "teste mult";
//category2.Summary = "teste mult";
//category2.Order = 1;
//category2.Description = "Test descricao mult";
//category2.Featured = true;

//categoryList.Add(category1);
//categoryList.Add(category2);

//bool retornoInsertMany = repository.InsertManyCategory(categoryList);

//if (retornoInsertMany == true)
//{
//    Console.WriteLine("Inserido com sucesso!!");
//}
//else
//{
//    Console.WriteLine("Não foi possivel inserir!!");
//}

//Console.WriteLine("----------------------- UPDATE ------------------------------------------");

//category1.Title = "TesteUpdate";


//bool retornoUpdate = repository.UpdateCategory(category1);

//if (retornoUpdate == true)
//{
//    Console.WriteLine("Alterado com sucesso!!");
//}
//else
//{
//    Console.WriteLine("Não foi possivel alterar!!");
//}

//Console.WriteLine("----------------------- UPDATE MULTIPLO ------------------------------------------");

//category1.Title = "TesteUpdate";

//category2.Title = "TesteMultUpdate";


//bool retornoManyUpdate = repository.UpdateManyCategory(categoryList);

//if (retornoManyUpdate == true)
//{
//    Console.WriteLine("Alterado com sucesso!!");
//}
//else
//{
//    Console.WriteLine("Não foi possivel alterar!!");
//}

//Console.WriteLine("----------------------- DELETE ------------------------------------------");

//bool retornoDelete = repository.DeleteCategory(category1.Id);

//if (retornoDelete == true)
//{
//    Console.WriteLine("Deletado com sucesso!!");
//}
//else
//{
//    Console.WriteLine("Não foi possivel deletar!!");
//}

//Console.WriteLine("----------------------- DELETE MULTIPLO ------------------------------------------");

//bool retornoManyDelete = repository.DeleteManyCategory(categoryList);

//if (retornoManyDelete == true)
//{
//    Console.WriteLine("Deletado com sucesso!!");
//}
//else
//{
//    Console.WriteLine("Não foi possivel deletar!!");
//}


//Console.WriteLine("----------------------- LIST SELECT ------------------------------------------");

//var retornoListCategory = repository.SelectListCategory();

//foreach (var item in retornoListCategory)
//{
//    Console.WriteLine($"{item.Id} - {item.Title}");
//}

//Console.WriteLine("----------------------- ID SELECT ------------------------------------------");

//var retornoCategoryId = repository.SelectCategoryId(Guid.Parse("2d786b71-a360-4fda-a743-874aae14c4d9"));

//if (retornoCategoryId != null )
//{
//    Console.WriteLine($"{retornoCategoryId.Id} - {retornoCategoryId.Title}");
//}

Console.WriteLine("----------------------- EXECUTE STORED PROCEDURES ------------------------------------------");

var retornoExecuteStoredProcedures = repositoryProcedures.ExecuteSpDeleteStudent(Guid.Parse("AFA1C4F8-CF5C-4972-BD92-5FBC37017F5D"));

if (retornoExecuteStoredProcedures == true)
{
    Console.WriteLine("Executado com sucesso!!");
}
else
{
    Console.WriteLine("Não foi possivel executadar!!");
}

