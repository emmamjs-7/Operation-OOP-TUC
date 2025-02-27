using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models
{
    public class OliveTree : Tree, IBearFruit
    {
        private readonly FruitStatus _fruitStatus;
        private readonly TreeMaintenance _maintenance;
        public OliveType Type { get; private set; }
        public bool IsRipe => _fruitStatus.IsRipe;

        public DateTime LastWatered => _maintenance.LastWatered;
        public DateTime LastPruned => _maintenance.LastPruned;

        public OliveTree(string name, string species, int ageYears, DateTime lastWatered,
            DateTime lastPruned, CareLevel careLevel, bool isRipe, string oliveType)
        {
            Name = name;
            Species = species;
            AgeYears = ageYears;
            CareLevel = careLevel;
            _fruitStatus = new FruitStatus(isRipe);
            _maintenance = new TreeMaintenance(lastWatered, lastPruned, careLevel);
            Type = Enum.Parse<OliveType>(oliveType);
        }

        public void Water() => _maintenance.Water();
        public void Prune() => _maintenance.Prune();
        public bool NeedsWater() => _maintenance.NeedsWater();
        public bool NeedsPruning() => _maintenance.NeedsPruning();

        public bool HarvestFruit() => _fruitStatus.HarvestFruit();

        public void DisplayOliveTree()
        {
            Console.WriteLine($"Olive Tree: {Name} Species: {Species} Age: {AgeYears} years");
            Console.WriteLine($"Olive Type: {Type} is currently fruiting: {IsRipe}");
            Console.WriteLine($"Care level: {CareLevel}");
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