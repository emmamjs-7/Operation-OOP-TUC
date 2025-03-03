using static OperationOOP.Core.Models.LemonTree;
using static OperationOOP.Core.Models.Tree;
using static OperationOOP.Core.Models.FruitTree;
using static OperationOOP.Core.Models.TreeMaintenance;


namespace OperationOOP.Api.Endpoints.Lemon
{
    public class CreateLemon : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapPost("/api/lemontrees", Handle)
            .WithName("CreateLemonTree")
            .WithOpenApi();

        public record Request(
            string Name,           
            int AgeYears,
            DateTime LastWatered,
            DateTime LastPruned,
            CareLevel CareLevel,
            bool IsRipe,
            LemonTree.LemonType LemonType
        );

        private static IResult Handle(Request request, IDatabase db)
        {
            var newId = db.LemonTrees.Count + 1;  

            // Skapa trädet genom konstruktorn istället för att sätta properties
            var lemonTree = new LemonTree(
                id: newId,
                name: request.Name,
                ageYears: request.AgeYears,
                lastWatered: request.LastWatered,
                lastPruned: request.LastPruned,
                careLevel: request.CareLevel,
                isRipe: request.IsRipe,
                lemonType: request.LemonType
            );

            db.LemonTrees.Add(lemonTree);
            db.Trees.Add(lemonTree);

            return Results.Created($"/api/lemontrees/{lemonTree.Id}", lemonTree);
        }
    }
}

