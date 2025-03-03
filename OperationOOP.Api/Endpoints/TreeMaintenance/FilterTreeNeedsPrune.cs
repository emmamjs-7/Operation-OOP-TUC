using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

using OperationOOP.Core.Data;
using OperationOOP.Core.Models;
using OperationOOP.Api.Models;
namespace OperationOOP.Api.Endpoints.TreeMaintenance
{
    public class FilterTreeNeedsPrune : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapGet("/trees/filter/needsPruning", Handle)
            .WithName("Trees that Needs Prune")
            .WithOpenApi();

        private static IResult Handle(IDatabase db, [FromQuery] bool? needsPrune)
        {
            // Hämta alla träd
            var trees = db.Trees;

            // Filtrera om needsPrune är specificerat
            if (needsPrune.HasValue)
            {
                trees = trees.Where(tree => tree.NeedsPruning() == needsPrune.Value).ToList();
            }

            if (!trees.Any())
            {
                return Results.NotFound(new { message = "No trees found that needs pruning." });
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





