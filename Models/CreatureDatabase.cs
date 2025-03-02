using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.ObjectModel;

namespace HybridMobileGame.Models
{
    internal class CreatureDatabase
    {
        public async static Task<IEnumerable<Creature>> GetCreatures()
        {
            //Setup the file path
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "data.json");

            try
            {
                //Check if the file exists
                if (!File.Exists(filePath))
                {
                    var defaultCreatures = new List<Creature>(); //Default empty list
                    JsonSerializerOptions writeOptions = new JsonSerializerOptions
                    {
                        WriteIndented = true
                    };

                    //Serialize the created empty list to JSON string.
                    string defaultJson = JsonSerializer.Serialize(defaultCreatures, writeOptions);

                    //Write serialized JSON to file.
                    await File.WriteAllTextAsync(filePath, defaultJson);
                    return [];
                }
                else
                {
                    //Read file content as stream.
                    using FileStream stream = File.OpenRead(filePath);

                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    //Deserialize the JSON stream directly to result of type IEnumerable<Creature>
                    IEnumerable<Creature>? result = await JsonSerializer.DeserializeAsync<IEnumerable<Creature>>(stream, options);
                    Console.WriteLine(filePath + ": file read successfully.");

                    //Return the result or empty collection if null.
                    return result ?? Enumerable.Empty<Creature>();
                }
            }
            catch (Exception ex) 
            { 
            //Catches error and logs it.
            Console.WriteLine($"A read error occurred: {ex.Message}");
                return [];
            }

            /*using Stream stream = await FileSystem.OpenAppPackageFileAsync("data.json");


            JsonSerializerOptions options = new()
            {
                PropertyNameCaseInsensitive = true,
            };

            IEnumerable<Creature>? creatures = await JsonSerializer.DeserializeAsync<List<Creature>>(stream, options);

            return creatures ?? [];*/
        }

        /*Creature[] exampleCreatures = new Creature[2];

        public CreatureDatabase() 
        {
            exampleCreatures[0] = new Creature(1, "Human");
            exampleCreatures[1] = new Creature(2, "Orc");
        }
        public Creature[] GetCreatures() 
        { 
            return exampleCreatures; 
        }
        */

        public async static Task WriteCreatures(ObservableCollection<ViewModels.CreatureViewModel> creatures)
        {
            JsonSerializerOptions options = new()
            {
                WriteIndented = true //Makes JSON output more human-readable
            };

            //Serialize the items received as parameters to JSON string.
            string json = JsonSerializer.Serialize(creatures, options);

            //Setup file path.
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "data.json");

            try
            {
                //Write JSON string to a file
                using StreamWriter writer = new StreamWriter(filePath);
                await writer.WriteAsync(json);
            }

            catch (IOException ioEx)
            {
                //Handle I/O errors
                Console.WriteLine($"I/O error occurred: {ioEx.Message}");
            }
            catch (UnauthorizedAccessException uaEx)
            {
                //Handle permission related errors
                Console.WriteLine($"I/O error occurred: {uaEx.Message}");
            }
            catch (Exception ex)
            {
                //Handle other errors
                Console.WriteLine($"I/O error occurred: {ex.Message}");
            }
        }
    }
}
