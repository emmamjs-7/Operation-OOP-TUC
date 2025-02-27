﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models
{
    public class OliveTree : FruitTree
    {
        public OliveType Type { get; private set; }
       

        public OliveTree(string name, string species, int ageYears, DateTime lastWatered,
            DateTime lastPruned, CareLevel careLevel, bool isRipe, string oliveType)
            : base(lastWatered, lastPruned, careLevel)
        {
            Name = name;
            Species = species;
            AgeYears = ageYears;
            CareLevel = careLevel;
            IsRipe = isRipe;
            Type = Enum.Parse<OliveType>(oliveType);
        }


        public void DisplayOliveTree()
        {
            Console.WriteLine($"Olive Tree: {Name} Species: {Species} Age: {AgeYears} years");
            Console.WriteLine($"Olive Type: {Type} is currently fruiting: {IsRipe}");
            Console.WriteLine($"Care level: {CareLevel}");
        }

        public enum OliveType
        {
            Arbequina,
            Picual,
            Manzanilla,
            Picholine
        }
    }
}