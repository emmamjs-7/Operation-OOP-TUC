using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models
{
    public class LemonTree : FruitTree
    {
        public LemonType Type { get; set; }

        public LemonTree(string name, string species, int ageYears, DateTime lastWatered,
            DateTime lastPruned, CareLevel careLevel, bool isRipe, string lemonType)
        {
            Name = name;
            Species = species;
            AgeYears = ageYears;
            LastWatered = lastWatered;
            LastPruned = lastPruned;
            CareLevel = careLevel;
            IsRipe = isRipe;
            Type = Enum.Parse<LemonType>(lemonType);

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
