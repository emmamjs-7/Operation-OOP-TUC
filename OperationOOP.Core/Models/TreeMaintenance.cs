namespace OperationOOP.Core.Models
{
    public class TreeMaintenance
    {

        public DateTime LastWatered { get; private set; }
        public DateTime LastPruned { get; private set; }
        public CareLevel CareLevel { get; private set; }

        public TreeMaintenance(DateTime lastWatered, DateTime lastPruned, CareLevel careLevel)
        {
            LastWatered = lastWatered;
            LastPruned = lastPruned;
            CareLevel = careLevel;
        }

        public void Water()
        {
            LastWatered = DateTime.Now;
            Console.WriteLine($"Tree is watered");
        }

        public void Prune()
        {
            LastPruned = DateTime.Now;
            Console.WriteLine("Tree is pruned");
        }

        public bool NeedsWater()
        {

            var timeSinceWatering = DateTime.Now - LastWatered;
            return timeSinceWatering.Days >= (int)CareLevel;
        }

        public bool NeedsPruning()
        {
            var timeSincePruning = DateTime.Now - LastPruned;
            return timeSincePruning.Days >= 365;
        }
    }
}