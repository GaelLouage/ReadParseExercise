using ReadParseFileExercise.Services.Classes;
using ReadParseFileExercise.Services.Interfaces;

namespace ReadParseFileExercise.Processors
{
    public class FileProcessor<T> where T : class
    {
        public async Task<List<T>> ProcessFile(IFileParser<T> parseData, string fileName)
        {
            var data = await parseData.ParseAsync(fileName);

            if (data is null)
            {
                return new List<T>(); 
            }
            return data;
        }
    }
}
