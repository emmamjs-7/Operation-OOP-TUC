using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Interfaces
{
    public interface IHasFruit
    {

        bool IsRipe { get; }  
        void CheckRipeness();
        
        
    }

     
      
}
