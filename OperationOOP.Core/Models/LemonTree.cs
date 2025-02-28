using System;

namespace OperationOOP.Core.Models
{
    public class LemonTree : FruitTree
    {
        public DateTime LastWatered { get; set; }
        public DateTime LastPruned { get; set; }
        public LemonType Type { get; set; }



        public LemonTree(int id, string name, int ageYears, DateTime lastWatered, DateTime lastPruned, CareLevel careLevel, bool isRipe, LemonType lemonType)
       : base(id, name, ageYears, lastWatered, lastPruned, careLevel)
        {
            Id = id;
            Name = name;
            AgeYears = ageYears;
            Type = lemonType;
            IsRipe = isRipe;
            _maintenance = new TreeMaintenance(lastWatered, lastPruned, careLevel);

        }

        public void DisplayLemonTree()
        {
            Console.WriteLine($"Lemon Tree: {Name} Species: {Species} Age: {AgeYears} years");
            Console.WriteLine($"Lemon type: {Type} is currently fruiting: {IsRipe}");
            Console.WriteLine($"Care level: {CareLevel}");
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
