namespace OperationOOP.Api.Endpoints;
using OperationOOP.Core.Data;


public class GetAllLemonTrees : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/lemontrees", Handle)
        .WithSummary("Lemon trees");

    // Request and Response types
    public record Response(
        int Id,
        string Name,
        int AgeYear,
        CareLevel CareLevel,
        DateTime LastWatered,
        DateTime LastPruned
    );

    //Logic
    private static List<Response> Handle(IDatabase db)
    {
        return db.LemonTrees
            .Select(item => new Response(
                Id: item.Id,
                Name: item.Name,
                AgeYear: item.AgeYears,
                CareLevel: item.CareLevel,
                LastWatered: item.LastWatered,
                LastPruned: item.LastPruned
            )).ToList();
    }
}