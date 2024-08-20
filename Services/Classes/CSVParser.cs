using ReadParseFileExercise.Services.Interfaces;

namespace ReadParseFileExercise.Services.Classes
{
    public class CSVParser<T> : IFileParser<T> where T : class
    {
        public async Task<List<T>> ParseAsync(string fileName)
        {
            if(File.Exists(fileName) is false)
            {
                throw new FileNotFoundException();
            }
            var fileReader = await File.ReadAllLinesAsync(fileName);
            var result = new List<T>();
            var splittedData = "";
            for (int i = 0; i < fileReader.Length; i++)
            {
                var splitter = fileReader[i].Split(',');
                for (int j = 0; j < splitter.Length; j++)
                {
                    // Convert item to type T and add it to the result list
                    T convertedItem = (T)Convert.ChangeType(splitter[j], typeof(T));
                     splittedData += $"{convertedItem} ";

                }
           
                result.Add((T)Convert.ChangeType(splittedData.TrimEnd(), typeof(T)));
                splittedData = null;
            }
            return result;
        }
    }
}
