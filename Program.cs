
using Dapper;
using Microsoft.Data.SqlClient;

const string connectionSql = "SERVER=WIN-OUQUEA1T4SV;Database=Blog;Encrypt=False;Integrated Security=True";


using(var connection = new SqlConnection(connectionSql))
{
    Creat(connection);
    Update(connection);
    Read(connection);
    Delete(connection);
}

static void Creat(SqlConnection connection){

    var script = "insert into [Category] values(@Nome, @Slug)";

    var p = new Category();
    p.Slug = "Dor no olhor"; 
    p.Name = "Anthony";

    var raws = connection.Execute(script, new{p.Name, p.Slug});
    Console.WriteLine(raws); 
}

static void Read(SqlConnection connection){
    var raws = connection.Query<Category>("SELECT * From [Category]");
    foreach(var p in raws)
    {
        Console.WriteLine($"{p.Id}|{p.Name}|{p.Slug}");
    }
}

static void Update(SqlConnection connection){
    var script = "UPDATE [Category] SET [Slug]=@Slug WHERE [id]=@Id";
    var raws = connection.Execute(script, new {Id = 1, Slug = "dor no olho"});
}

static void Delete(SqlConnection connection){
    var script = "DELETE FROM Category WHERE id = @Id";
    var raws = connection.Execute(script, new{ id = 1});
}

class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Slug { get; set; }
}