using ReadParseFileExercise.Models;
using ReadParseFileExercise.Processors;
using ReadParseFileExercise.Services.Classes;
using ReadParseFileExercise.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddScoped<IFileParser<string>, CSVParser<string>>();
builder.Services.AddScoped<IFileParser<Person>, JsonParser<Person>>();
var app = builder.Build();



app.MapGet("/", (IFileParser<Person> parser) =>
{
    try
    {
        var fileProcessor = new FileProcessor<Person>();
        var xmlFileName = "jsondummyfile.json";
        var filePath = Path.Combine(Environment.CurrentDirectory, xmlFileName);

        var data = fileProcessor.ProcessFile(parser, filePath);
     
        return Results.Ok(data);
    }
    catch (FileNotFoundException ex)
    {
        return Results.NotFound($"File not found: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.Problem($"An error occurred: {ex.Message}");
    }
});

app.Run();
