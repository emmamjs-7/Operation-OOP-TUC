namespace OperationOOP.Core.Models
{
    public class FruitStatus
    {
        public bool IsRipe { get; set; }

        public FruitStatus(bool isRipe)
        {
            IsRipe = isRipe;
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
    }
}