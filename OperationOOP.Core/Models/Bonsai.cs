namespace OperationOOP.Core.Models;


public class Bonsai :Tree
{
    public BonsaiStyle Style { get; set; }

    public Bonsai()
    {
    }


    public Bonsai(string name, string species, int ageYears, DateTime lastWatered, DateTime lastPruned, CareLevel careLevel, string bonsaiStyle)
    {
        Name = name;
        Species = species;
        AgeYears = ageYears;
        LastWatered = lastWatered;
        LastPruned = lastPruned;
        CareLevel = careLevel;
        Style = Enum.Parse<BonsaiStyle>(bonsaiStyle);

    }

}

public enum BonsaiStyle
{
    Chokkan,    // Formal Upright
    Moyogi,     // Informal Upright
    Shakan,     // Slanting
    Kengai,     // Cascade
    HanKengai   // Semi-cascade
}

