using Newtonsoft.Json;
using ReadParseFileExercise.Services.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace ReadParseFileExercise.Services.Classes
{
    public class JsonParser<T> : IFileParser<T> where T : class
    {
        public async Task<List<T>> ParseAsync(string fileName)
        {
            if (File.Exists(fileName) is false)
            {
                throw new FileNotFoundException();
            }
            try
            {
                var fileContent = await File.ReadAllTextAsync(fileName);
                var result = JsonConvert.DeserializeObject<List<T>>(fileContent);

                if (result == null)
                {
                    return new List<T>();
                }
                return result;
            }
            catch (Exception ex)
            {
                return new List<T>();
            }
        }
    }
}
