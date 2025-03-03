using System;

namespace OperationOOP.Core.Models
{
    public class LemonTree : FruitTree
    {
        
        public LemonType Type { get; }

        public LemonTree(
            int id, 
            string name, 
            int ageYears, 
            DateTime lastWatered, 
            DateTime lastPruned, 
            CareLevel careLevel, 
            bool isRipe, 
            LemonType lemonType)
            : base(id, name, ageYears, lastWatered, lastPruned, careLevel)
        {
            Type = lemonType;
            IsRipe = isRipe;
        }

        public void DisplayLemonTree()
        {
            Console.WriteLine($"Lemon Tree: {Name} Age: {AgeYears} years");
            Console.WriteLine($"Lemon type: {Type} is currently fruiting: {IsRipe}");
            Console.WriteLine($"Care level: {CareLevel}");
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
