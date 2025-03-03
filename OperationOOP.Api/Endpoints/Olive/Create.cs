using OperationOOP.Core.Models;

using static OperationOOP.Core.Models.OliveTree;

namespace OperationOOP.Api.Endpoints.Olive
{
    public class CreateOlive : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapPost("/api/olivetrees", Handle)
            .WithName("CreateOliveTree")
            .WithOpenApi();

        public record Request(
            string Name,
            int AgeYears,
            DateTime LastWatered,
            DateTime LastPruned,
            CareLevel CareLevel,
            bool IsRipe,
            OliveTree.OliveType OliveType
        );

        private static IResult Handle(Request request, IDatabase db)
        {
            var newId = db.OliveTrees.Count + 1;  


            var oliveTree = new OliveTree(
                id: newId,
                name: request.Name,
                ageYears: request.AgeYears,
                lastWatered: request.LastWatered,
                lastPruned: request.LastPruned,
                careLevel: request.CareLevel,
                isRipe: request.IsRipe,
                oliveType: request.OliveType
            );


            db.OliveTrees.Add(oliveTree);
            db.Trees.Add(oliveTree);

            return Results.Created($"/api/olivetrees/{oliveTree.Id}", oliveTree);
        }
    }
}


