using OperationOOP.Core.Models;

namespace OperationOOP.Api.Endpoints;
public class GetOliveTree : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/olivetrees/{id}", Handle)
        .WithSummary("Olive trees");

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
        var oliveTree = db.OliveTrees.Find(oliveTree => oliveTree.Id == request.Id);

        if (oliveTree == null)
        {
            return Results.NotFound(new { message = $"OliveTree with ID {request.Id} not found." });
        }

        var response = new Response(
            Id: oliveTree.Id,
            Name: oliveTree.Name,
            AgeYears: oliveTree.AgeYears,
            LastWatered: oliveTree.LastWatered,
            LastPruned: oliveTree.LastPruned,
            CareLevel: oliveTree.CareLevel
            );

        return Results.Ok(response);
    }
}