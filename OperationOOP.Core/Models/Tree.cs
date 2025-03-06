using OperationOOP.Core.Data;
using OperationOOP.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using OperationOOP.Core.Models;

namespace OperationOOP.Core.Models
{
    public abstract class Tree
    {
        public DateTime LastWatered { get; private set; }
        public DateTime LastPruned { get; private set; }
  
        public CareLevel Care { get; private set; }

        protected Tree(int id, string name, int ageYears, DateTime lastWatered, DateTime lastPruned, CareLevel care)
        {
            Id = id;
            Name = name;
            LastWatered = lastWatered;
            LastPruned = lastPruned; 
            Care = care;
            AgeYears = ageYears;
            
        }

        public int Id { get; }
        public string Name { get; }
        public int AgeYears { get; }



        public void Prune()
        {
            LastPruned = DateTime.Now;
            Console.WriteLine($"Tree is watered");
        }

        public void Water()
        {
            LastWatered = DateTime.Now;
            Console.WriteLine($"Tree is watered");
        }

        public enum CareLevel
        {
            Low,
            Medium,
            High
        }
    }
}
