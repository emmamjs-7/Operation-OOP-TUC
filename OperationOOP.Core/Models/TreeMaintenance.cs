namespace OperationOOP.Core.Models
{
    public class TreeMaintenance
    {
        private readonly int _wateringIntervalDays;
        private readonly int _pruningIntervalDays = 180;  // 2 gånger per år

        public DateTime LastWatered { get; private set; }
        public DateTime LastPruned { get; private set; }

        public TreeMaintenance(DateTime lastWatered, DateTime lastPruned, CareLevel careLevel)
        {
            LastWatered = lastWatered;
            LastPruned = lastPruned;
            _wateringIntervalDays = (int)careLevel;
        }

        public void Water()
        {
            LastWatered = DateTime.Now;
        }

        public void Prune()
        {
            LastPruned = DateTime.Now;
        }

        public bool NeedsWater() =>
            (DateTime.Now - LastWatered).TotalDays > _wateringIntervalDays;

        public bool NeedsPruning() =>
            (DateTime.Now - LastPruned).TotalDays > _pruningIntervalDays;
    }
}