


/*Lembrar de instalar o Package/Pacote "Microsoft.Data.SqlClient" 
              e o Package/Pacote do Dapper*/


using ExemploDataAccessDapper.Models;
using ExemploDataAccessDapper.Repository;

Repository repository = new Repository();


//Console.WriteLine("----------------------- INSERT ------------------------------------------");

Category category = new Category();
category.Id = Guid.Parse("2d786b71-a360-4fda-a743-874aae14c4d9");
category.Title = "Test";
category.Url = "teste";
category.Summary = "teste";
category.Order = 1;
category.Description = "Test descricao";
category.Featured = true;

bool retornoInsert = repository.InsertCategory(category);

if (retornoInsert == true)
{
    Console.WriteLine("Inserido com sucesso!!");
}
else
{
    Console.WriteLine("Não foi possivel inserir!!");
}

//Console.WriteLine("----------------------- UPDATE ------------------------------------------");

category.Title = "TesteUpdate";


bool retornoUpdate = repository.UpdateCategory(category);

if (retornoUpdate == true)
{
    Console.WriteLine("Alterado com sucesso!!");
}
else
{
    Console.WriteLine("Não foi possivel alterar!!");
}

//Console.WriteLine("----------------------- DELETE ------------------------------------------");

bool retornoDelete = repository.DeleteCategory(category.Id);

if (retornoDelete == true)
{
    Console.WriteLine("Deletado com sucesso!!");
}
else
{
    Console.WriteLine("Não foi possivel deletar!!");
}


Console.WriteLine("----------------------- LIST SELECT ------------------------------------------");

var retornoListCategory = repository.SelectListCategory();

foreach (var item in retornoListCategory)
{
    Console.WriteLine($"{item.Id} - {item.Title}");
}

Console.WriteLine("----------------------- ID SELECT ------------------------------------------");

var retornoCategoryId = repository.SelectCategoryId(Guid.Parse("2d786b71-a360-4fda-a743-874aae14c4d9"));

if (retornoCategoryId != null )
{
    Console.WriteLine($"{retornoCategoryId.Id} - {retornoCategoryId.Title}");
}

