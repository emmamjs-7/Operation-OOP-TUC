using OperationOOP.Core.Models;
using static OperationOOP.Core.Models.OliveTree;
using static OperationOOP.Core.Models.Tree;
using static OperationOOP.Core.Models.LemonTree;

namespace OperationOOP.Core.Data
{
    public interface IDatabase
    {
        List<Bonsai> Bonsais { get; set; }
        List<LemonTree> LemonTrees { get; set; }
        List<OliveTree> OliveTrees { get; set; }
        List<Tree> Trees { get; set; }
    }

    public class Database : IDatabase
    {
        public List<Bonsai> Bonsais { get; set; } = new List<Bonsai>();
        public List<LemonTree> LemonTrees { get; set; } = new List<LemonTree>();
        public List<OliveTree> OliveTrees { get; set; } = new List<OliveTree>();
        public List<Tree> Trees { get; set; } = new List<Tree>();

        public Database()
        {
            
            var lemonTree1 = new LemonTree(
                id: 1,
                name: "Meyer Lemon",
                ageYears: 3,
                lastWatered: DateTime.Now.AddDays(-2),
                lastPruned: DateTime.Now.AddDays(-30),
                lastHarvest: DateTime.Now.AddDays(-130),
                careLevel: CareLevel.High,
                isRipe: true,
                lemonType: LemonTree.LemonType.Meyer
            );

            var lemonTree2 = new LemonTree(
                id: 2,
                name: "Eureka Lemon",
                ageYears: 5,
                lastWatered: DateTime.Now.AddDays(-14),
                lastPruned: DateTime.Now.AddDays(-60),
                 lastHarvest: DateTime.Now.AddDays(-367),
                careLevel: CareLevel.Medium,
                isRipe: false,
                lemonType: LemonTree.LemonType.Eureka
            );

            var oliveTree2 = new OliveTree(
                id: 3,
                name: "Manzanilla Olive",
                ageYears: 5,
                lastWatered: DateTime.Now.AddDays(-60),
                lastPruned: DateTime.Now.AddDays(-181),
                lastHarvest: DateTime.Now.AddDays(-367),
                careLevel: CareLevel.Medium,
                isRipe: false,
                oliveType: OliveTree.OliveType.Manzanilla
                );

            var oliveTree1 = new OliveTree(
              id: 4,
              name: "Golden Olive",
              ageYears: 10,
              lastWatered: DateTime.Now.AddDays(-5),
              lastPruned: DateTime.Now.AddDays(-60),
              lastHarvest: DateTime.Now.AddDays(-37),
              careLevel: CareLevel.Low,
              isRipe: true,
              oliveType: OliveTree.OliveType.Manzanilla
              );


            OliveTrees.Add(oliveTree1);
            OliveTrees.Add(oliveTree2); 
            LemonTrees.Add(lemonTree1);
            LemonTrees.Add(lemonTree2);
            Trees.Add(lemonTree1);
            Trees.Add(lemonTree2);
            Trees.Add(oliveTree1);
            Trees.Add(oliveTree2);
        }
    }
}
