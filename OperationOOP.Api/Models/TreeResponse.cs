using OperationOOP.Core.Models;
using static OperationOOP.Core.Models.Tree;

namespace OperationOOP.Api.Models
{
    public record TreeResponse(
        int Id,
        string Name,
        string Type,
        CareLevel Care,
        DateTime LastWatered,
        DateTime LastPruned,
        bool NeedsWater,
        bool NeedsPruning
    );
}