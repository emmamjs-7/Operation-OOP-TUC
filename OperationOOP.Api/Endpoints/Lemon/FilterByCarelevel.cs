

using OperationOOP.Core.Models;

namespace OperationOOP.Api.Endpoints.Lemon
{
    public class FilterTreesByCareLevel : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapGet("/api/trees/filter", Handle)
            .WithName("FilterTrees")
            .WithOpenApi();

        private static IResult Handle(IDatabase db, CareLevel? careLevel)
        {
            var trees = db.Trees;

            {

                // Använd Tree.FilterByCareLevels metoden

                var filteredTrees = Tree.FilterByCareLevels(

                    new List<CareLevel> { careLevel.Value },

                    trees.Cast<Tree>().ToList()

                );



                // Konvertera tillbaka till LemonTrees

                return Results.Ok(filteredTrees.OfType<Tree>().ToList());

            }


        }
    }
}