using OperationOOP.Core.Models;

namespace OperationOOP.Core.Data
{
    public interface IDatabase
    {
        List<Bonsai> Bonsais { get; set; }
        List<LemonTree> LemonTrees { get; set; }
    }

    public class Database : IDatabase
    {
        public List<Bonsai> Bonsais { get; set; } = new List<Bonsai>();
        public List<LemonTree> LemonTrees { get; set; } = new List<LemonTree>();
    }
}
