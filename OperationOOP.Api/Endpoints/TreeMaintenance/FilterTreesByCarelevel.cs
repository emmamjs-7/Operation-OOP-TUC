using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OperationOOP.Core.Data;
using OperationOOP.Core.Models;
using OperationOOP.Api.Models;

namespace OperationOOP.Api.Endpoints.TreeMaintenance
{
    public class FilterTreesByCarelevel : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapGet("/trees/filter/byCareLevel", Handle)
            .WithName("Filter trees By Carelevel")
            .WithOpenApi();

        private static IResult Handle(IDatabase db, [FromQuery] CareLevel? careLevel)
        {
            // Hämta alla träd
            var trees = db.Trees;

            // Filtrera om careLevel är specificerat
            if (careLevel.HasValue)
            {
                trees = trees.Where(tree => tree.CareLevel == careLevel.Value).ToList();
            }

            if (!trees.Any())
            {
                return Results.NotFound(new { message = "No trees found for the given CareLevel." });
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