using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Objects.Interfaces
{
  public  interface IReposCaseHeader    
    {
        void UpdateCase(int id, decimal Price);
    }
}
