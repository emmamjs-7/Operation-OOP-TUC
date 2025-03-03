using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OperationOOP.Core.Data;
using OperationOOP.Core.Models;
using OperationOOP.Api.Models;

namespace OperationOOP.Api.Endpoints.TreeMaintenance
{
    public class FilterTreesNeedsWater : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapGet("/trees/filter/needsWater", Handle)
            .WithName("Filter Trees By Needing water")
            .WithOpenApi();

        private static IResult Handle(IDatabase db, [FromQuery] bool? needsWater)
        {
            // Hämta alla träd
            var trees = db.Trees;

            // Filtrera om needsWater är specificerat
            if (needsWater.HasValue)
            {
                trees = trees.Where(tree => tree.NeedsWater() == needsWater.Value).ToList();
            }

            if (!trees.Any())
            {
                return Results.NotFound(new { message = "No trees found that needs water." });
            }

            // Mappa till response
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


