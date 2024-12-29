using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace HybridMobileGame.Models
{
    internal class CreatureDatabase
    {
        public async static Task<IEnumerable<Creature>> GetCreatures()
        {
            using Stream stream = await FileSystem.OpenAppPackageFileAsync("data.json");


            JsonSerializerOptions options = new()
            {
                PropertyNameCaseInsensitive = true,
            };

            IEnumerable<Creature>? creatures = await JsonSerializer.DeserializeAsync<List<Creature>>(stream, options);

            return creatures ?? [];
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
    }
}
