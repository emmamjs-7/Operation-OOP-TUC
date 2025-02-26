namespace OperationOOP.Core.Models
{
    public abstract class FruitTree : Tree, IFruitBearing
    {
        public bool IsRipe { get; set; }

        public bool HarvestFruit()
        {
            if (IsRipe)
            {
                IsRipe = false;
                return true;
            }
            return false;
        }
    }
}