var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/sabrina", () => "Sabrina Helena! ");
app.MapGet("/f", () => 
    {
        return "Fun��o an�nima";
    });

app.MapGet("/ok", () =>
{
    return Results.Ok("ok!");
});

app.MapGet("/{nome}", (string nome) =>
{
    return Results.Ok($"Hello {nome}!");
});

app.MapPost("/", (User user) => { return Results.Ok(user); });  
W


app.Run();

//classes
public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
}
