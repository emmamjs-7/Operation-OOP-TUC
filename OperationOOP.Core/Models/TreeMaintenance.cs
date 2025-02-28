namespace OperationOOP.Core.Models
{
    public class TreeMaintenance
    {

        public DateTime LastWatered { get;  private set; }
        public DateTime LastPruned { get;  private set; }
        public CareLevel CareLevel { get; private  set; }

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

            int daysUntilWatering = CareLevel switch
            {
                CareLevel.Low => 14, 
                CareLevel.Medium => 7, 
                CareLevel.High => 3,
                _ => 7 //standard tull 7 dagar
            };

            return timeSinceWatering.Days >= daysUntilWatering;
        }

        public bool NeedsPruning()
        {
            var timeSincePruning = DateTime.Now - LastPruned;

            int daysUntilPruning = CareLevel switch
            {
                CareLevel.Low => 365,
                CareLevel.Medium => 180,
                CareLevel.High => 90,
                _ => 180 //standard till 180 dagar
            };

            return timeSincePruning.Days >= daysUntilPruning;
        }
    }
}