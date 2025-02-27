namespace OperationOOP.Core.Models
{
    public class FruitTree :Tree
    {
        public bool IsRipe { get; protected set; } //Protected set g�r att IsRipe kan s�ttas i subklasser
        private readonly TreeMaintenance _maintenance;

        //Underh�ll
        public DateTime LastWatered => _maintenance.LastWatered;
        public DateTime LastPruned => _maintenance.LastPruned;

        public FruitTree(DateTime lastwatered, DateTime lastPruned, CareLevel carelevel)
        {
            _maintenance = new TreeMaintenance(lastwatered, lastPruned, carelevel);
        }

        public bool HarvestFruit()
        {
            if (IsRipe)
            {
                IsRipe = false;
                return true;
            }
            return false;
        }

        public void Water() => _maintenance.Water();
        public void Prune() => _maintenance.Prune();
        public bool NeedsWater() => _maintenance.NeedsWater();
        public bool NeedsPruning() => _maintenance.NeedsPruning();
    }
}