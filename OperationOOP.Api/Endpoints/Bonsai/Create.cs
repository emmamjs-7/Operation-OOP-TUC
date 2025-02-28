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
        // Skapa Bonsai med rätt parametrar
        var bonsai = new Bonsai(
            db.Bonsais.Any() ? db.Bonsais.Max(b => b.Id) + 1 : 1, // Id
            request.Name,  // Name
            request.AgeYears, // AgeYears
            request.LastWatered, // LastWatered
            request.LastPruned, // LastPruned
            request.CareLevel, // CareLevel
            request.Style // BonsaiStyle
        );

        db.Bonsais.Add(bonsai);

        return TypedResults.Ok(new Response(bonsai.Id));
    }

}

