using OperationOOP.Core.Data;
using OperationOOP.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OperationOOP.Core.Models
{
    public class TreeManager
    {
        private readonly IDatabase _database;

    
        public TreeManager(IDatabase database)
        {
            _database = database;
        }

       
        public void ManageTrees()
        {
            foreach (var tree in _database.Trees)
            {
                
                if (tree is IHasFruit fruitTree)
                {
                    fruitTree.CheckRipeness();
                }

                
                if (tree is INeedWater waterTree)
                {
                    if (waterTree.NeedsWater())
                    {
                        waterTree.Water();
                    }
                }


                if (tree is INeedPrune pruneTree)
                {
                    if (pruneTree.NeedsPruning())
                    {
                        pruneTree.Prune();
                    }
                }
            }
        }

      
        private List<Tree> GetTreesByCondition<T>(Func<T, bool> condition) where T : class
        {
            return _database.Trees
                .Where(tree => tree is T typedTree && condition(typedTree))
                .ToList();
        }

        // Hämta alla träd som behöver vattnas
        public List<Tree> GetTreesThatNeedWater()
        {
            return GetTreesByCondition<INeedWater>(tree => ((INeedWater)tree).NeedsWater());
        }

        // Alla träd som behöver klippas
        public List<Tree> GetTreesThatNeedPruning()
        {
            return GetTreesByCondition<INeedPrune>(tree => ((INeedPrune)tree).NeedsPruning());
        }

        // Alla träd som har mogen frukt
        public List<Tree> GetFruitTreesThatNeedHarvest()
        {
            return GetTreesByCondition<IHasFruit>(tree => ((IHasFruit)tree).IsRipe);
        }


        public void DisplayNeeds()
        {
            // Visa träd som behöver vattnas
            var treesThatNeedWater = GetTreesThatNeedWater();
            Console.WriteLine("Träd som behöver vattnas:");
            foreach (var tree in treesThatNeedWater)
            {
                Console.WriteLine(tree.Name);
            }

            // Visa träd som behöver klippas
            var treesThatNeedPruning = GetTreesThatNeedPruning();
            Console.WriteLine("Träd som behöver klippas:");
            foreach (var tree in treesThatNeedPruning)
            {
                Console.WriteLine(tree.Name);
            }

            // Visa träd som har mogen frukt
            var fruitTreesThatNeedHarvest = GetFruitTreesThatNeedHarvest();
            Console.WriteLine("Träd som har mogen frukt:");
            foreach (var tree in fruitTreesThatNeedHarvest)
            {
                Console.WriteLine(tree.Name);
            }
        }
    }
}
