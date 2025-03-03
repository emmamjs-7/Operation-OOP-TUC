using OperationOOP.Core.Models; 


namespace OperationOOP.Api.Endpoints;
public class CreateBonsai : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/bonsais", Handle)
        .WithSummary("Bonsai trees");

    public record Request(
        int Id,
        string Name,
        string Species,
        int AgeYears,
        DateTime LastWatered,
        DateTime LastPruned,
        BonsaiStyle Style,
        CareLevel CareLevel
        );

    public record Response(int id);

    private static Ok<Response> Handle(Request request, IDatabase db)
    {
        var bonsai = new Bonsai(
            db.Bonsais.Any() ? db.Bonsais.Max(b => b.Id) + 1 : 1, 
            request.Name,  
            request.AgeYears, 
            request.LastWatered,
            request.LastPruned, 
            request.CareLevel, 
            request.Style 
        );

        db.Bonsais.Add(bonsai);

        return TypedResults.Ok(new Response(bonsai.Id));
    }

}

