using OperationOOP.Core.Interfaces;
using System;
using System.ComponentModel;

namespace OperationOOP.Core.Models
{
    public class LemonTree : Tree, IHasFruit, INeedPrune, INeedWater
    {
        
        public DateTime LastHarvest { get; private set; }
        public LemonType Type { get; }
        public bool IsRipe { get; private set; }

        public LemonTree(
            int id,
            string name,
            int ageYears,
            DateTime lastWatered,
            DateTime lastPruned,
            DateTime lastHarvest,
            CareLevel careLevel,
            LemonType lemonType,
            bool isRipe)
           
            : base(id, name, ageYears, lastWatered, lastPruned, careLevel)
        {
            Type = lemonType;
            IsRipe = isRipe;
           
            LastHarvest = lastHarvest;

        }
        public void HarvestFruit()
        {
            if (IsRipe)
            {
                LastHarvest = DateTime.Now;
                Console.WriteLine("Harvest fruits");
                IsRipe = false;
            }
        }

        public void CheckRipeness()
        {
            var daysSinceHarvest = DateTime.Now - LastHarvest;

            if (AgeYears >= 1 && daysSinceHarvest.TotalDays >= 365)
            {
                IsRipe = true;
                Console.WriteLine("Lemon tree: The lemons are ripe!");
            }
            else
            {
                IsRipe = false;
                Console.WriteLine("Lemon tree: The lemons are not ripe yet.");
            }
        }


        public bool NeedsWater()
        {
            var timeSinceWatering = DateTime.Now - LastWatered;

           
            if (timeSinceWatering.TotalDays >= 7)
            {
                Console.WriteLine("Lemon tree needs water");
                return true;
            }
            else
            {
                Console.WriteLine("Lemon tree does not need water yet");
                return false; 
            }
        }

        public bool NeedsPruning()
        {
              
            var timeSincePruning = DateTime.Now - LastWatered;


            if (timeSincePruning.TotalDays >= 180)
            {
                Console.WriteLine("Lemon tree needs pruning");
                return true;
            }
            else
            {
                Console.WriteLine("Lemon tree does not need pruning yet");
                return false;
            }
        }
        

        public void DisplayLemonTree()
        {
            Console.WriteLine($"Lemon Tree: {Name} Age: {AgeYears} years");
            Console.WriteLine($"Lemon type: {Type} is currently fruiting: {((IHasFruit)this).CheckRipeness}");
            Console.WriteLine($"Needs water: {NeedsWater()}");
        }

        public enum LemonType
        {
            Eureka,
            Lisbon,
            Meyer,
            Ponderosa
        }

    }
}
