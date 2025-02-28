namespace OperationOOP.Api.Endpoints;
public class GetBonsai : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/bonsais/{id}", Handle)
        .WithSummary("Bonsai trees");

    public record Request(int Id);

    public record Response(
        int Id,
        string Name,
        int AgeYears,
        DateTime LastWatered,
        DateTime LastPruned,
        CareLevel CareLevel
    );

    private static IResult Handle([AsParameters] Request request, IDatabase db)
    {
        var bonsai = db.Bonsais.Find(bonsai => bonsai.Id == request.Id);

        if (bonsai == null)
        {
            return Results.NotFound(new { message = $"Bonsai with ID {request.Id} not found." });
        }

        var response = new Response(
            Id: bonsai.Id,
            Name: bonsai.Name,
            AgeYears: bonsai.AgeYears,
            LastWatered: bonsai.LastWatered,
            LastPruned: bonsai.LastPruned,
            CareLevel: bonsai.CareLevel
            );

        return Results.Ok(response);
    }
}