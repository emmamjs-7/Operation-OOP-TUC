using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OperationOOP.Core.Data;
using OperationOOP.Core.Models;
using OperationOOP.Api.Models;
using OperationOOP.Core.Interfaces;

namespace OperationOOP.Api.Endpoints.TreeMaintenance
{
    public class FilterTreesNeedsPrune : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapGet("/trees/filter/needsPrune", Handle)
            .WithName("Filter Trees By Needing Pruning")
            .WithOpenApi();


        private static IResult Handle(IDatabase db, [FromQuery] bool? needsPruning)
        {
            
            var trees = db.Trees;

        
            var pruningTrees = trees.OfType<INeedPrune>().ToList();

        
            if (needsPruning.HasValue)
            {
                pruningTrees = pruningTrees.Where(tree => tree.NeedsPruning() == needsPruning.Value).ToList();
            }

            if (!pruningTrees.Any())
            {
                return Results.NotFound(new { message = "No trees found that need to prune." });
            }

            // Mappa till response
            var response = pruningTrees.Select(tree => new TreeResponse(
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


