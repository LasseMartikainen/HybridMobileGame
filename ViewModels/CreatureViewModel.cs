﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using HybridMobileGame.Models;

namespace HybridMobileGame.ViewModels
{
    public class CreatureViewModel:ObservableObject
    {
        //CreatureDatabase ExampleDatabase = new CreatureDatabase();

        int CreatureId;
        String CreatureName;
        String CreatureImagePath;

        public int Id
        { 
            get {  return CreatureId; } 
            set => SetProperty(ref CreatureId, value);
        }

        public String Name
            { 
            get { return CreatureName; } 
            set => SetProperty(ref CreatureName, value);
        }

        public String ImagePath
        {
            get { return CreatureImagePath; }
            set => SetProperty(ref CreatureImagePath, value);
        }

        public CreatureViewModel(Creature creature)
        {
            CreatureId = creature.Id;
            CreatureName = creature.Name;
            CreatureImagePath = creature.ImagePath;
        }
    }
}
