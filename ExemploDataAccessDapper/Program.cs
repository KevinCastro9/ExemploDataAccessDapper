


/*Lembrar de instalar os Packages/Pacotes "Microsoft.Data.SqlClient" e "Dapper"*/


using ExemploDataAccessDapper.Models;
using ExemploDataAccessDapper.Repository;
using System.Collections.Generic;

Repository repository = new Repository();
RepositoryProcedures repositoryProcedures = new RepositoryProcedures();
RepositoryExecuteScalar repositoryExecuteScalar = new RepositoryExecuteScalar();
RepositoryViews repositoryViews = new RepositoryViews();
RepositoryOneToOne repositoryOneToOne = new RepositoryOneToOne();
RepositoryOneToMany repositoryOneToMany = new RepositoryOneToMany();
RepositoryQueryMultiple repositoryQueryMultiple = new RepositoryQueryMultiple();
RepositorySelectInAndLike repositorySelectInAndLike = new RepositorySelectInAndLike();
RepositoryTransaction repositoryTransaction = new RepositoryTransaction();

Category categoryAws = new Category();
categoryAws.Id = Guid.Parse("0851CC48-7299-4C52-BA19-80BEC48256A4");
categoryAws.Title = "AWS";
categoryAws.Url = "aws";
categoryAws.Summary = "Aprenda tudo sobre AWS.";
categoryAws.Order = 1;
categoryAws.Description = "descricao AWS";
categoryAws.Featured = true;

Category categoryAzure = new Category();
categoryAzure.Id = Guid.Parse("0851CC48-7299-4C52-BA19-80BEC48256A5");
categoryAzure.Title = "Azure";
categoryAzure.Url = "azure";
categoryAzure.Summary = "Aprenda tudo sobre Azure.";
categoryAzure.Order = 1;
categoryAzure.Description = "descricao Azure";
categoryAzure.Featured = true;

List<Category> categoryList = new List<Category>();
categoryList.Add(categoryAws);
categoryList.Add(categoryAzure);

//InsertCategory(categoryAws); 
//InsertMultiploCategory(categoryList); 
//UpdateCategory(categoryAws); 
//UpdateMultiploCategory(categoryList);
//DeleteCategory(categoryAws); 
//DeleteMultiploCategory(categoryList);

//ExecuteSpDeleteStudent(Guid.Parse("AFA1C4F8-CF5C-4972-BD92-5FBC37017F5D"));
//ExecuteSpGetCoursesByCategory(Guid.Parse("09CE0B7B-CFCA-497B-92C0-3290AD9D5142"));
//ExecuteScalar(categoryAws);
//ExecuteView();
//ExecuteOneToOne();
//ExecuteOneToMany();
//QueryMultiple();
//SelectLike("api");
//BeginTransaction(categoryAws);

//List<Guid> idList = new List<Guid>();
//idList.Add(Guid.Parse("4327ac7e-963b-4893-9f31-9a3b28a4e72b"));
//idList.Add(Guid.Parse("e6730d1c-6870-4df3-ae68-438624e04c72"));

//SelectIN(idList);
//SelectIdCategory(categoryAws.Id);
ListSelectCategory();

void InsertCategory(Category category)
{
    bool retornoInsert = repository.InsertCategory(category);

    if (retornoInsert == true)
        Console.WriteLine("Inserido com sucesso!!");
    else
        Console.WriteLine("Não foi possivel inserir!!");
}

void InsertMultiploCategory(List<Category> categories)
{
    bool retornoInsertMany = repository.InsertManyCategory(categories);

    if (retornoInsertMany == true)
        Console.WriteLine("Inserido com sucesso!!");
    else
        Console.WriteLine("Não foi possivel inserir!!");
}

void UpdateCategory(Category category)
{
    category.Title = "AWS update";
    bool retornoUpdate = repository.UpdateCategory(category);

    if (retornoUpdate == true)
        Console.WriteLine("Alterado com sucesso!!");
    else
        Console.WriteLine("Não foi possivel alterar!!");
}

void UpdateMultiploCategory(List<Category> categories)
{
    categories[0].Title = "AWS multi update";
    categories[1].Title = "Azure multi update";

    bool retornoManyUpdate = repository.UpdateManyCategory(categories);

    if (retornoManyUpdate == true)
        Console.WriteLine("Alterado com sucesso!!");
    else
        Console.WriteLine("Não foi possivel alterar!!");
}

void DeleteCategory(Category category)
{
    bool retornoDelete = repository.DeleteCategory(category.Id);

    if (retornoDelete == true)
        Console.WriteLine("Deletado com sucesso!!");
    else
        Console.WriteLine("Não foi possivel deletar!!");
}

void DeleteMultiploCategory(List<Category> categories)
{
    bool retornoManyDelete = repository.DeleteManyCategory(categories);

    if (retornoManyDelete == true)
        Console.WriteLine("Deletado com sucesso!!");
    else
        Console.WriteLine("Não foi possivel deletar!!");
}

void ListSelectCategory()
{
    var retornoListCategory = repository.SelectListCategory();

    foreach (var item in retornoListCategory)
        Console.WriteLine($"{item.Id} - {item.Title}");
}

void SelectIdCategory(Guid id) 
{
    var retornoCategoryId = repository.SelectCategoryId(id);

    if (retornoCategoryId != null)
        Console.WriteLine($"{retornoCategoryId.Id} - {retornoCategoryId.Title}");
}

void ExecuteSpDeleteStudent(Guid id) 
{
    //EXECUTE STORED PROCEDURES SEM RETORNO

    var retornoExecuteStoredProcedures = repositoryProcedures.ExecuteSpDeleteStudent(id);

    if (retornoExecuteStoredProcedures == true)
        Console.WriteLine("Executado com sucesso!!");
    else
        Console.WriteLine("Não foi possivel executadar!!");
}

void ExecuteSpGetCoursesByCategory(Guid id) 
{
    //EXECUTE STORED PROCEDURES COM RETORNO

    var retornoExecuteStoredProceduresReturn = repositoryProcedures.ExecuteSpGetCoursesByCategory(id);

    foreach (var item in retornoExecuteStoredProceduresReturn)
        Console.WriteLine($"{item.Id} - {item.Title}");
}

void ExecuteScalar(Category category)
{
    var retornoExecuteScalar = repositoryExecuteScalar.InsertExecuteScalarCategory(category);
    Console.WriteLine(retornoExecuteScalar);
}

void ExecuteView()
{
    var retornoView = repositoryViews.ExecuteVwCourses();

    foreach (var item in retornoView)
        Console.WriteLine($"{item.Id} - {item.Title}");
}

void ExecuteOneToOne()
{
    //Join um pra um (Duas tabelas, uma linha cada uma)

    var retornoOneToOne = repositoryOneToOne.SelectOneToOne();

    foreach (var item in retornoOneToOne)
        Console.WriteLine($"{item.Title} - Curso: {item.Course.Title}");
}

void ExecuteOneToMany()
{
    //Join um pra muitos (Duas tabelas, uma linha da tabela principal, uma lista da tabela relacionada)

    var retornoOneToMany = repositoryOneToMany.SelectOneToMany();

    foreach (var career in retornoOneToMany)
    {
        Console.WriteLine($"{career.Title}");
        foreach (var item in career.Items)
            Console.WriteLine($" - {item.Title}");
    }
}

void QueryMultiple()
    => repositoryQueryMultiple.SelectListCategoryAndSelectListCourse();

void SelectIN(List<Guid> listID)
{
    var retornoSelectIn = repositorySelectInAndLike.SelectInCarrer(listID);

    foreach (var item in retornoSelectIn)
        Console.WriteLine(item.Title);
}

void SelectLike(string palavra)
{
    var retornoSelectLike = repositorySelectInAndLike.SelectLikeCourse(palavra);

    foreach (var item in retornoSelectLike)
        Console.WriteLine(item.Title);
}

void BeginTransaction(Category category)
{
    bool retornoInsertBeginTransaction = repositoryTransaction.InsertTransactionCategory(category);

    if (retornoInsertBeginTransaction == true)
        Console.WriteLine("Inserido com sucesso!!");
    else
        Console.WriteLine("Não foi possivel inserir!!");
}