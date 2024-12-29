using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridMobileGame.Models
{
    internal class CreatureDatabase
    {
        Creature[] exampleCreatures = new Creature[2];

        public CreatureDatabase() 
        {
            exampleCreatures[0] = new Creature(1, "Human");
            exampleCreatures[1] = new Creature(2, "Orc");
        }
        public Creature[] GetCreatures() 
        { 
            return exampleCreatures; 
        }

    }
}
