using OperationOOP.Core.Interfaces;
using System.ComponentModel;

namespace OperationOOP.Core.Models
{
    public class OliveTree :Tree, IHasFruit, INeedWater, INeedPrune
    {
        public OliveType Type { get; }
        public bool IsRipe { get; private set; }
        DateTime LastHarvest { get; set; }

        public OliveTree(
            int id,
            string name,
            int ageYears,
            DateTime lastWatered,
            DateTime lastPruned,
            DateTime lastHarvest,
            CareLevel careLevel,
            OliveType oliveType,
            bool isRipe)
            : base(id, name, ageYears, lastWatered, lastPruned, careLevel)
        {
            Type = oliveType;
            IsRipe = isRipe;
            LastHarvest = lastHarvest;

        }

        public void HarvestFruit()
        {
            if(IsRipe)
            {
                LastHarvest = DateTime.Now;
                Console.WriteLine("Harvest fruits");
                IsRipe = false;
            }
        }
        public void CheckRipeness()
        {
            var daysSinceHarvest = DateTime.Now - LastHarvest;

            if (AgeYears >= 5 && daysSinceHarvest.TotalDays >=365 ) 
            {
                IsRipe = true;
                Console.WriteLine("Olive tree: The lemons are ripe!");
            }
            else
            {
                IsRipe = false;
                Console.WriteLine("Olive tree: The lemons are not ripe yet.");
            }
        }


        public bool NeedsWater()
        {
            var timeSinceWatering = DateTime.Now - LastWatered;


            if (timeSinceWatering.TotalDays >= 14)
            {
                Console.WriteLine("Olive tree needs water");
                return true;
            }
            else
            {
                Console.WriteLine("Olive tree does not need water yet");
                return false;
            }
        }

        public bool NeedsPruning()
        {

            var timeSincePruning = DateTime.Now - LastWatered;


            if (timeSincePruning.TotalDays >= 360)
            {
                Console.WriteLine("Olive tree needs pruning");
                return true;
            }
            else
            {
                Console.WriteLine("Olive tree does not need pruning yet");
                return false;
            }
        }



        public void DisplayOliveTree()
        {
            Console.WriteLine($"Olive Tree: {Name} Age: {AgeYears} years");
            Console.WriteLine($"Olive Type: {Type} is currently fruiting: {CheckRipeness}");
            Console.WriteLine($"Care level: {Care}");
            Console.WriteLine($"Needs water: {NeedsWater()}");
        }

        public enum OliveType
        {
            Arbequina,
            Picual,
            Manzanilla,
            Picholine
        }
    }
}