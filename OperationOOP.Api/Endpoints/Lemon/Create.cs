
using static OperationOOP.Core.Models.LemonTree;

namespace OperationOOP.Api.Endpoints.Lemon
{
    public class CreateLemon : IEndpoint
    {
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapPost("/lemontrees", Handle)
            .WithSummary("Lemon trees");

        public record Request(
            int Id,
            string Name,
            int AgeYears,
            DateTime LastWatered,
            DateTime LastPruned,
            string CareLevel, // CareLevel skickas som string
            bool IsRipe,      // Nytt fält: anger om citronträdet har mogen frukt
            string LemonType  // Nytt fält: anger vilken citrontyp
        )
        {
            public bool TryGetCareLevel(out CareLevel careLevel)
            {
                return Enum.TryParse(CareLevel, true, out careLevel);
            }

            public bool TryGetLemonType(out LemonType lemonType)
            {
                return Enum.TryParse(LemonType, true, out lemonType);
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
            if (!request.TryGetLemonType(out LemonType lemonType))
            {
                return Results.BadRequest("Invalid LemonType value.");
            }

            var lemonTree = new OperationOOP.Core.Models.LemonTree(
                request.Id,
                request.Name,
                request.AgeYears,
                request.LastWatered,
                request.LastPruned,
                careLevel,   // Nu säkerställt att det är en giltig enum
                request.IsRipe,
                lemonType    // Nu säkerställt att det är en giltig enum
            );

            // Sätt unikt ID för det nya trädet
            lemonTree.Id = db.LemonTrees.Any() ? db.LemonTrees.Max(t => t.Id) + 1 : 1;

            db.LemonTrees.Add(lemonTree);

            return TypedResults.Ok(new Response(lemonTree.Id));
        }
    }
}
