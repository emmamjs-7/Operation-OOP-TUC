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
        private readonly TreeMaintenance _maintenance;

        protected Tree(int id, string name, int ageYears, DateTime lastWatered, DateTime lastPruned, CareLevel careLevel)
        {
            Id = id;
            Name = name;
            AgeYears = ageYears;
            _maintenance = new TreeMaintenance(lastWatered, lastPruned, careLevel);
        }

        public int Id { get; }
        public string Name { get; }
        public int AgeYears { get; }
        public DateTime LastWatered => _maintenance.LastWatered;
        public DateTime LastPruned => _maintenance.LastPruned;
        public CareLevel CareLevel => _maintenance.CareLevel;

        public bool NeedsWater() => _maintenance.NeedsWater();
        public bool NeedsPruning() => _maintenance.NeedsPruning();
        public void Water() => _maintenance.Water();
        public void Prune() => _maintenance.Prune();
    }
}

public enum CareLevel
{
    Low,
    Medium,
    High
}
