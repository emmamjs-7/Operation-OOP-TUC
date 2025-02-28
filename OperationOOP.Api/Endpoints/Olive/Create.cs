using OperationOOP.Core.Models;

using static OperationOOP.Core.Models.OliveTree;

namespace OperationOOP.Api.Endpoints.Olive
{
    public class CreateOlive : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapPost("/olivetrees", Handle)
            .WithSummary("Olive trees");

        public record Request(
            int Id,
            string Name,
            int AgeYears,
            DateTime LastWatered,
            DateTime LastPruned,
            string CareLevel, // CareLevel skickas som string
            bool IsRipe,      // Nytt fält: anger om citronträdet har mogen frukt
            string OliveType  // Nytt fält: anger vilken citrontyp
        )
        {
            public bool TryGetCareLevel(out CareLevel careLevel)
            {
                return Enum.TryParse(CareLevel, true, out careLevel);
            }

            public bool TryGetOliveType(out OliveType oliveType)
            {
                return Enum.TryParse(OliveType, true, out oliveType);
            }
        }

        public record Response(int id);

        private static IResult Handle(Request request, IDatabase db)
        {
            // Försök konvertera CareLevel från string till enum
            if (!request.TryGetCareLevel(out CareLevel careLevel))
            {
                return Results.BadRequest("Invalid CareLevel value.");
            }

            // Försök konvertera LemonType från string till enum
            if (!request.TryGetOliveType(out OliveType oliveType))
            {
                return Results.BadRequest("Invalid olive type value.");
            }

            var oliveTree = new OliveTree(
                request.Id,
                request.Name,
                request.AgeYears,
                request.LastWatered,
                request.LastPruned,
                careLevel,   // Nu säkerställt att det är en giltig enum
                request.IsRipe,
                oliveType    // Nu säkerställt att det är en giltig enum
            );

            // Sätt unikt ID för det nya trädet
            oliveTree.Id = db.OliveTrees.Any() ? db.OliveTrees.Max(t => t.Id) + 1 : 1;

            db.OliveTrees.Add(oliveTree);

            return TypedResults.Ok(new Response(oliveTree.Id));
        }
    }
}
