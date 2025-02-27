using OperationOOP.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models
{
    public class Tree
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int AgeYears { get; set; }
        public DateTime LastWatered { get; set; }
        public DateTime LastPruned { get; set; }
        public CareLevel CareLevel { get; set; }

    }
}

public enum CareLevel
{
    Beginner = 14,    // Vattnas var 14:e dag
    Intermediate = 10, // Vattnas var 10:e dag
    Advanced = 7,      // Vattnas var 7:e dag
    Master = 5         // Vattnas var 5:e dag
}
