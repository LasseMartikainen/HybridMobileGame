﻿using HybridMobileGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace HybridMobileGame.ViewModels
{
    public class CreatureListViewModel:ObservableObject
    {
        private CreatureViewModel selectedCreature;

        public CreatureViewModel SelectedCreature
        {
            get => selectedCreature; 
            set => SetProperty(ref selectedCreature, value);
        }

        public ObservableCollection<CreatureViewModel> Creatures {  get; set; }

        public CreatureListViewModel() => Creatures = [];

        public async Task RefreshCreatures()
        {
            IEnumerable<Models.Creature> creaturesData = await Models.CreatureDatabase.GetCreatures();

            foreach (Creature creature in creaturesData)
            {
                Creatures.Add(new CreatureViewModel(creature));
            }
        }

        public void DeleteCreature(CreatureViewModel creature)
        {
            //Change the Ids of remaining creatures to avoid duplicates when adding new creatures
            foreach (var cr in Creatures)
            {
                if (cr.Id > creature.Id)
                {
                    cr.Id = cr.Id - 1;
                }
            }

            Creatures.Remove(creature);
        }

        public void AddCreature(CreatureViewModel newCreature) => Creatures.Add(newCreature);

        public async Task SaveCreatures()
        {
            await Models.CreatureDatabase.WriteCreatures(Creatures);
        }
    }
}
