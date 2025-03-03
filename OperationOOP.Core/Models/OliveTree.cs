namespace OperationOOP.Core.Models
{
    public class OliveTree : FruitTree
    {
        public OliveType Type { get; }  

        public OliveTree(
            int id,
            string name,
            int ageYears,
            DateTime lastWatered,
            DateTime lastPruned,
            CareLevel careLevel,
            bool isRipe,
            OliveType oliveType)
            : base(id, name, ageYears, lastWatered, lastPruned, careLevel)
        {
            Type = oliveType;
            IsRipe = isRipe;
        }

        public void DisplayOliveTree()
        {
            Console.WriteLine($"Olive Tree: {Name} Age: {AgeYears} years");
            Console.WriteLine($"Olive Type: {Type} is currently fruiting: {IsRipe}");
            Console.WriteLine($"Care level: {CareLevel}");
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