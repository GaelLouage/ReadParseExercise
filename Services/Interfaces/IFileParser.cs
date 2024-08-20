namespace ReadParseFileExercise.Services.Interfaces
{
    public interface IFileParser<T> where T : class
    {
         Task<List<T>> ParseAsync(string fileName);
    }
}
