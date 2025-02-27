using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models
{
    public class LemonTree : Tree, IBearFruit
    {
        private readonly FruitStatus _fruitStatus;
        private readonly TreeMaintenance _maintenance;
        public LemonType Type { get; private set; }
        public bool IsRipe => _fruitStatus.IsRipe;

        public DateTime LastWatered => _maintenance.LastWatered;
        public DateTime LastPruned => _maintenance.LastPruned;

        public LemonTree(string name, string species, int ageYears, DateTime lastWatered,
            DateTime lastPruned, CareLevel careLevel, bool isRipe, string lemonType)
        {
            Name = name;
            Species = species;
            AgeYears = ageYears;
            CareLevel = careLevel;
            _fruitStatus = new FruitStatus(isRipe);
            _maintenance = new TreeMaintenance(lastWatered, lastPruned, careLevel);
            Type = Enum.Parse<LemonType>(lemonType);
        }

        public void Water() => _maintenance.Water();
        public void Prune() => _maintenance.Prune();
        public bool NeedsWater() => _maintenance.NeedsWater();
        public bool NeedsPruning() => _maintenance.NeedsPruning();

        public bool HarvestFruit() => _fruitStatus.HarvestFruit();

        public void DisplayLemonTree()
        {
            Console.WriteLine($"Lemon Tree: {Name} Species: {Species} Age: {AgeYears} years");
            Console.WriteLine($"Lemon type: {Type} is currently fruiting: {IsRipe}");
            Console.WriteLine($"Care level: {CareLevel}");
        }

        public void DisplayMaintenanceStatus()
        {
            var waterStatus = NeedsWater()
                ? "Behöver vattnas!"
                : $"Vattnades senast: {LastWatered:yyyy-MM-dd}";

            var pruneStatus = NeedsPruning()
                ? "Behöver beskäras!"
                : $"Beskars senast: {LastPruned:yyyy-MM-dd}";

            var careInfo = $"Vattnas var {(int)CareLevel}:e dag (CareLevel: {CareLevel})";

            Console.WriteLine($"""
                === Underhållsstatus för {Name} ===
                {waterStatus}
                {pruneStatus}
                {careInfo}
                """);
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
