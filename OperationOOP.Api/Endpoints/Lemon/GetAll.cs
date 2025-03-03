namespace OperationOOP.Api.Endpoints;
using OperationOOP.Core.Data;


public class GetAllLemonTrees : IEndpoint
{
    
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/lemontrees", Handle)
        .WithSummary("Lemon trees");

  
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