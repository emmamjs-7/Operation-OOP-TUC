using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OperationOOP.Core.Data;
using OperationOOP.Core.Models;
using OperationOOP.Api.Models;
using OperationOOP.Core.Interfaces;

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

            // Filtrera endast träd som implementerar INeedWater
            var waterableTrees = trees.OfType<INeedWater>().ToList();

            // Filtrera baserat på needsWater om det har ett värde
            if (needsWater.HasValue)
            {
                waterableTrees = waterableTrees.Where(tree => tree.NeedsWater() == needsWater.Value).ToList();
            }

            if (!waterableTrees.Any())
            {
                return Results.NotFound(new { message = "No trees found that need water." });
            }

            // Mappa till response
            var response = waterableTrees.Select(tree => new TreeResponse(
                (tree as Tree)!.Id,  
                (tree as Tree)!.Name,
                tree.GetType().Name,
                (tree as Tree)!.Care,
                (tree as Tree)!.LastWatered,
                (tree as Tree)!.LastPruned,
                tree.NeedsWater(),
                (tree as INeedPrune)?.NeedsPruning() ?? false 
            ));

            return Results.Ok(response);
        }

    }
}


