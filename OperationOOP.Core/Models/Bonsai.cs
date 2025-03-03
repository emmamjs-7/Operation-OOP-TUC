using static OperationOOP.Core.Models.LemonTree;

namespace OperationOOP.Core.Models;


public class Bonsai :Tree
{
    public BonsaiStyle Style { get; set; }

    public Bonsai(int id, string name, int ageYears, DateTime lastWatered, DateTime lastPruned, CareLevel careLevel, BonsaiStyle style)
       : base(id, name, ageYears, lastWatered, lastPruned, careLevel)
    {  

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

