using System;
using OperationOOP.Core.Models;

namespace OperationOOP.Core.Models
{
    public interface IFruitBearing
    {
        bool IsRipe { get; set; }
        bool HarvestFruit();
    }
}