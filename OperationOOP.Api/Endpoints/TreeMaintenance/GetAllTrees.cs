using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using OperationOOP.Core.Data;
using OperationOOP.Core.Models;
using OperationOOP.Api.Models;

namespace OperationOOP.Api.Endpoints.TreeMaintenance
{
    public class GetAllTrees : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapGet("/trees", Handle)
            .WithName("Get All Trees")
            .WithOpenApi();

        private static IResult Handle(IDatabase db)
        {
            var trees = db.Trees;

            if (!trees.Any())
            {
                return Results.NotFound(new { message = "No trees found." });
            }

            var response = trees.Select(tree => new TreeResponse(
                tree.Id,
                tree.Name,
                tree.GetType().Name,
                tree.CareLevel,
                tree.LastWatered,
                tree.LastPruned,
                tree.NeedsWater(),
                tree.NeedsPruning()
            ));

            return Results.Ok(response);
        }
    }
}