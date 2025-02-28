

namespace OperationOOP.Core.Models
{
    public class OliveTree : FruitTree
    {
        public OliveType Type { get; private set; }


        public OliveTree(int id, string name, int ageYears, DateTime lastWatered, DateTime lastPruned, CareLevel careLevel, bool isRipe, OliveType oliveType)
           : base(id, name, ageYears, lastWatered, lastPruned, careLevel)
        {
            Id = id;
            Name = name;
            AgeYears = ageYears;
            Type = oliveType;
            IsRipe = isRipe;
            _maintenance = new TreeMaintenance(lastWatered, lastPruned, careLevel);

        }


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