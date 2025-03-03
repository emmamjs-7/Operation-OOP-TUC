namespace OperationOOP.Api.Endpoints;
using OperationOOP.Core.Data;


public class GetAllBonsais : IEndpoint
{
    
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/bonsais", Handle)
        .WithSummary("Bonsai trees");

   
    public record Response(
        int Id,
        int AgeYear,
        string Name,
        DateTime LastWatered,
        DateTime LastPruned
    );


    private static List<Response> Handle(IDatabase db)
    {
        return db.Bonsais
            .Select(item => new Response(
                Id: item.Id,
                Name: item.Name,
                AgeYear: item.AgeYears,
                LastWatered: item.LastWatered,
                LastPruned: item.LastPruned
            )).ToList();
    }
}