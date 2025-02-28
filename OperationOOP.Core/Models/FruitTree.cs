using OperationOOP.Core.Models;

public class FruitTree : Tree
{
    public bool IsRipe { get; protected set; }  //protectd gör att det kan ändras i ärvda klasser 

    public string Name { get; protected set; }
    public int AgeYears { get; protected set; }

    public DateTime LastWatered => _maintenance.LastWatered;
    public DateTime LastPruned => _maintenance.LastPruned;
    public CareLevel CareLevel => _maintenance.CareLevel;

    private readonly TreeMaintenance _maintenance;


    public FruitTree(int id, string name, int ageYears, DateTime lastWatered, DateTime lastPruned, CareLevel careLevel)
        : base(id, name, ageYears, lastWatered, lastPruned, careLevel)
    {
        _maintenance = new TreeMaintenance(lastWatered, lastPruned, careLevel);
        IsRipe = false;
    }



}
