namespace OperationOOP.Api.Endpoints;
using OperationOOP.Core.Data;


public class GetAllOliveTrees : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/olivetrees", Handle)
        .WithSummary("Olive trees");

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
        return db.OliveTrees
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