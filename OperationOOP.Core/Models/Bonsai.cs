namespace OperationOOP.Core.Models;
public class Bonsai :Plant
{
    public BonsaiStyle Style { get; set; }
   
}

public enum BonsaiStyle
{
    Chokkan,    // Formal Upright
    Moyogi,     // Informal Upright
    Shakan,     // Slanting
    Kengai,     // Cascade
    HanKengai   // Semi-cascade
}

public enum CareLevel
{
    Beginner,
    Intermediate,
    Advanced,
    Master
} 