namespace OperationOOP.Api.Models
{
    public record TreeResponse(
        int Id,
        string Name,
        string Type,
        CareLevel CareLevel,
        DateTime LastWatered,
        DateTime LastPruned,
        bool NeedsWater,
        bool NeedsPruning
    );
}