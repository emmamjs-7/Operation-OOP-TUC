namespace OperationOOP.Core.Models
{
    public interface IBearFruit
    {
        bool IsRipe { get; }
        bool HarvestFruit();
    }
}