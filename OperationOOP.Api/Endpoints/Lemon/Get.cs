namespace OperationOOP.Api.Endpoints;
public class GetLemonTree : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/lemontrees/{id}", Handle)
        .WithSummary("Lemon trees");

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
        var lemonTree = db.LemonTrees.Find(lemonTree => lemonTree.Id == request.Id);

        if (lemonTree == null)
        {
            return Results.NotFound(new { message = $"LemonTree with ID {request.Id} not found." });
        }

        var response = new Response(
            Id: lemonTree.Id,
            Name: lemonTree.Name,
            AgeYears: lemonTree.AgeYears,
            LastWatered: lemonTree.LastWatered,
            LastPruned: lemonTree.LastPruned,  
            CareLevel: lemonTree.CareLevel
            );

        return Results.Ok(response);
    }
}