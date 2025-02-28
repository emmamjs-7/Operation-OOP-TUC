using OperationOOP.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models
{
    public abstract class Tree
    {

        public Tree(int id, string name, int ageYears, DateTime lastWatered, DateTime lastPruned, CareLevel careLevel)
        {
            Id = id;
            Name = name;
            AgeYears = ageYears;
            LastWatered = lastWatered;
            LastPruned = lastPruned;
            CareLevel = careLevel;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int AgeYears { get; set; }
        public DateTime LastWatered { get; set; }
        public DateTime LastPruned { get; set; }
        public CareLevel CareLevel { get; set; }

        public TreeMaintenance _maintenance;

        public static List<Tree> FilterByCareLevels(List<CareLevel> careLevels, List<Tree> trees)
        {
            if (careLevels == null || !careLevels.Any()) return trees;

            return trees.Where(tree => careLevels.Contains(tree._maintenance.CareLevel)).ToList();
        }

    }
}
//siffran är antal dagar som trädet behöver vattnas
public enum CareLevel
{
    Low,
    Medium,
    High

}
