using OperationOOP.Core.Interfaces;
using static OperationOOP.Core.Models.LemonTree;

namespace OperationOOP.Core.Models;


public class Bonsai : Tree, INeedPrune, INeedWater
{

    public BonsaiStyle Style { get; set; }

    public Bonsai(int id, string name, int ageYears, DateTime lastWatered, DateTime lastPruned, CareLevel careLevel, BonsaiStyle style)
       : base(id, name, ageYears, lastWatered, lastPruned, careLevel)
    {

    }

    public bool NeedsWater()
    {
        var timeSinceWatering = DateTime.Now - LastWatered;


        if (timeSinceWatering.TotalDays >= 3)
        {
            Console.WriteLine("Bonsai needs water");
            return true;
        }
        else
        {
            Console.WriteLine("Bonsai does not need water yet");
            return false;
        }
    }

    public bool NeedsPruning()
    {

        var timeSincePruning = DateTime.Now - LastWatered;


        if (timeSincePruning.TotalDays >= 90)
        {
            Console.WriteLine("Bonsai needs pruning");
            return true;
        }
        else
        {
            Console.WriteLine("Bonsai does not need pruning yet");
            return false;
        }
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

