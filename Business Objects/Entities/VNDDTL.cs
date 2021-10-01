using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DBModel.Entities
{
    class VNDDTL
    {
        //   Vendors Table
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VNDCOD { get; set; }
        [Required(ErrorMessage = "Please add Vendor Name.")]
        public string VNDNAM { get; set; }

        //navigation property

        public List<BILHDR> BILHDRs { get; set; }
    }

}
