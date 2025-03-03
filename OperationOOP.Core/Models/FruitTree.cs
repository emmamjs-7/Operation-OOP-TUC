using OperationOOP.Core.Models;

namespace OperationOOP.Core.Models
{
    public abstract class FruitTree : Tree
    {
        public bool IsRipe { get; protected set; }  

        protected FruitTree(
            int id,
            string name,
            int ageYears,
            DateTime lastWatered,
            DateTime lastPruned,
            CareLevel careLevel)
            : base(id, name, ageYears, lastWatered, lastPruned, careLevel)
        {
            IsRipe = false;  // Alla fruktträd börjar som omogna
        }


        public string HarvestFruit()
        {
            if (!IsRipe && DateTime.Now.Month == 8 && DateTime.Now.Day >= 1)
            {
                IsRipe = true; // Sätter frukten till mogen om det är 1 augusti eller senare
            }

            if (!IsRipe)
            {
                return "No ripe fruit to harvest. The fruit will be ripe on August 1st.";
            }

            IsRipe = false; // Skörda frukten
            return "Fruit successfully harvested! It will be ripe again next August 1st.";
        }

    }
}
