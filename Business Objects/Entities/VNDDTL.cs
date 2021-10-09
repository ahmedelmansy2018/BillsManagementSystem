using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Business_Objects
{
   public class VNDDTL
    {
        //   Vendors Table
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VNDCOD { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "Please add Vendor Name.")]
        public string VNDNAM { get; set; }

        //navigation property

        public List<BILHDR> BILHDRs { get; set; }
    }

}
