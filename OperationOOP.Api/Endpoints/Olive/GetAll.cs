namespace OperationOOP.Api.Endpoints;
using OperationOOP.Core.Data;


public class GetAllOliveTrees : IEndpoint
{
 
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/olivetrees", Handle)
        .WithSummary("Olive trees");

   
    public record Response(
        int Id,
        string Name,
        int AgeYear,
        CareLevel CareLevel,
        DateTime LastWatered,
        DateTime LastPruned
    );

 
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