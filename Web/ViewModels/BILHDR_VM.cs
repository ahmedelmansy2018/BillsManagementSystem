using Business_Objects;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class BILHDR_VM
    {
        public int VNDCOD { get; set; }
        public string VNDNAM { get; set; }
        public int BILCOD { get; set; }
        public DateTime BILDAT { get; set; }
        public Decimal BILPRC { get; set; }
        public string BILIMG { get; set; }
        public IFormFile File { get; set; }
    
      


    }
}
