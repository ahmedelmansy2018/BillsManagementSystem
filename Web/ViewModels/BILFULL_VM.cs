using System;
using Business_Objects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class BILFULL_VM
    {
        public BILHDR BIL_HDR { get; set; }
        public List<BILDTI_VM> BILDTI_VM { get; set; }
    }
}
