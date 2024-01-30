


/*Lembrar de instalar os Packages/Pacotes "Microsoft.Data.SqlClient" e "Dapper"*/


using ExemploDataAccessDapper.Models;
using ExemploDataAccessDapper.Repository;

Repository repository = new Repository();
RepositoryProcedures repositoryProcedures = new RepositoryProcedures();
RepositoryExecuteScalar repositoryExecuteScalar = new RepositoryExecuteScalar();
RepositoryViews repositoryViews = new RepositoryViews();
RepositoryOneToOne repositoryOneToOne = new RepositoryOneToOne();
RepositoryOneToMany repositoryOneToMany = new RepositoryOneToMany();
RepositoryQueryMultiple repositoryQueryMultiple = new RepositoryQueryMultiple();
RepositorySelectInAndLike repositorySelectInAndLike = new RepositorySelectInAndLike();
RepositoryTransaction repositoryTransaction = new RepositoryTransaction();

Category category1 = new Category();
Category category2 = new Category();

List<Category> categoryList = new List<Category>();

category1.Id = Guid.Parse("0851CC48-7299-4C52-BA19-80BEC48256A4");
category1.Title = "Test";
category1.Url = "teste";
category1.Summary = "teste";
category1.Order = 1;
category1.Description = "Test descricao";
category1.Featured = true;

category2.Id = Guid.Parse("2D786B71-A360-4FDA-A743-874AAE14C4D8");
category2.Title = "Test mult";
category2.Url = "teste mult";
category2.Summary = "teste mult";
category2.Order = 1;
category2.Description = "Test descricao mult";
category2.Featured = true;

categoryList.Add(category1);
categoryList.Add(category2);

//Console.WriteLine("----------------------- INSERT ------------------------------------------");

//bool retornoInsert = repository.InsertCategory(category1);

//if (retornoInsert == true)
//    Console.WriteLine("Inserido com sucesso!!");
//else
//    Console.WriteLine("Não foi possivel inserir!!");

//Console.WriteLine("----------------------- INSERT MULTIPLO ------------------------------------------");

//bool retornoInsertMany = repository.InsertManyCategory(categoryList);

//if (retornoInsertMany == true)
//    Console.WriteLine("Inserido com sucesso!!");
//else
//    Console.WriteLine("Não foi possivel inserir!!");

//Console.WriteLine("----------------------- UPDATE ------------------------------------------");

//category1.Title = "TesteUpdate";

//bool retornoUpdate = repository.UpdateCategory(category1);

//if (retornoUpdate == true)
//    Console.WriteLine("Alterado com sucesso!!");
//else
//    Console.WriteLine("Não foi possivel alterar!!");

//Console.WriteLine("----------------------- UPDATE MULTIPLO ------------------------------------------");

//category1.Title = "TesteUpdate";
//category2.Title = "TesteMultUpdate";

//bool retornoManyUpdate = repository.UpdateManyCategory(categoryList);

//if (retornoManyUpdate == true)
//    Console.WriteLine("Alterado com sucesso!!");
//else
//    Console.WriteLine("Não foi possivel alterar!!");

//Console.WriteLine("----------------------- DELETE ------------------------------------------");

//bool retornoDelete = repository.DeleteCategory(category1.Id);

//if (retornoDelete == true)
//    Console.WriteLine("Deletado com sucesso!!");
//else
//    Console.WriteLine("Não foi possivel deletar!!");

//Console.WriteLine("----------------------- DELETE MULTIPLO ------------------------------------------");

//bool retornoManyDelete = repository.DeleteManyCategory(categoryList);

//if (retornoManyDelete == true)
//    Console.WriteLine("Deletado com sucesso!!");
//else
//    Console.WriteLine("Não foi possivel deletar!!");

//Console.WriteLine("----------------------- LIST SELECT ------------------------------------------");

//var retornoListCategory = repository.SelectListCategory();

//foreach (var item in retornoListCategory)
//    Console.WriteLine($"{item.Id} - {item.Title}");

//Console.WriteLine("----------------------- ID SELECT ------------------------------------------");

//var retornoCategoryId = repository.SelectCategoryId(Guid.Parse("AF3407AA-11AE-4621-A2EF-2028B85507C4"));

//if (retornoCategoryId != null)
//    Console.WriteLine($"{retornoCategoryId.Id} - {retornoCategoryId.Title}");

//Console.WriteLine("----------------------- EXECUTE STORED PROCEDURES SEM RETORNO ------------------------------------------");

//var retornoExecuteStoredProcedures = repositoryProcedures.ExecuteSpDeleteStudent(Guid.Parse("AFA1C4F8-CF5C-4972-BD92-5FBC37017F5D"));

//if (retornoExecuteStoredProcedures == true)
//    Console.WriteLine("Executado com sucesso!!");
//else
//    Console.WriteLine("Não foi possivel executadar!!");

//Console.WriteLine("----------------------- EXECUTE STORED PROCEDURES COM RETORNO  ------------------------------------------");

//var retornoExecuteStoredProceduresReturn = repositoryProcedures.ExecutespGetCoursesByCategory(Guid.Parse("09CE0B7B-CFCA-497B-92C0-3290AD9D5142"));

//foreach (var item in retornoExecuteStoredProceduresReturn)
//    Console.WriteLine($"{item.Id} - {item.Title}");

//Console.WriteLine("----------------------- EXECUTE SCALAR  ------------------------------------------");

//var retornoExecuteScalar = repositoryExecuteScalar.InsertExecuteScalarCategory(category1);

//Console.WriteLine(retornoExecuteScalar);

//Console.WriteLine("----------------------- EXECUTE VIEW ------------------------------------------");

//var retornoView = repositoryViews.ExecuteVwCourses();

//foreach (var item in retornoView)
//    Console.WriteLine($"{item.Id} - {item.Title}");

//Console.WriteLine("----------------------- EXECUTE ONE TO ONE  ------------------------------------------");

//var retornoOneToOne = repositoryOneToOne.SelectOneToOne();

//foreach (var item in retornoOneToOne)
//    Console.WriteLine($"{item.Title} - Curso: {item.Course.Title}");

//Console.WriteLine("----------------------- EXECUTE ONE TO MANY  ------------------------------------------");

//var retornoOneToMany = repositoryOneToMany.SelectOneToMany();

//foreach (var career in retornoOneToMany)
//{
//    Console.WriteLine($"{career.Title}");
//    foreach (var item in career.Items)
//        Console.WriteLine($" - {item.Title}");
//}

//Console.WriteLine("----------------------- QUERY MULTIPLE  ------------------------------------------");

//repositoryQueryMultiple.SelectListCategoryAndSelectListCourse();

//Console.WriteLine("----------------------- SELECT IN  ------------------------------------------");

//List<Guid> idList = new List<Guid>();
//idList.Add(Guid.Parse("4327ac7e-963b-4893-9f31-9a3b28a4e72b"));
//idList.Add(Guid.Parse("e6730d1c-6870-4df3-ae68-438624e04c72"));

//var retornoSelectIn = repositorySelectInAndLike.SelectInCarrer(idList);

//foreach (var item in retornoSelectIn)
//    Console.WriteLine(item.Title);

//Console.WriteLine("----------------------- SELECT LIKE  ------------------------------------------");

//var retornoSelectLike = repositorySelectInAndLike.SelectLikeCourse("api");

//foreach (var item in retornoSelectLike)
//    Console.WriteLine(item.Title);

//Console.WriteLine("----------------------- BEGIN TRANSACTION ------------------------------------------");

//bool retornoInsertBeginTransaction = repositoryTransaction.InsertTransactionCategory(category1);

//if (retornoInsertBeginTransaction == true)
//    Console.WriteLine("Inserido com sucesso!!");
//else
//    Console.WriteLine("Não foi possivel inserir!!");

var retornoListCategorytest = repository.SelectListCategory();

foreach (var item in retornoListCategorytest)
    Console.WriteLine($"{item.Id} - {item.Title}");