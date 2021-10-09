using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Objects
{
    public class BILHDR
    {
        //Bill Header Table
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BILCOD { get; set; }
        [Required(ErrorMessage = "Please add  Data.")]
        public DateTime BILDAT { get; set; }

        [Required]
        [Display(Name = "Bill Price")]
        [Column(TypeName = "decimal(10, 2)")]
        public Decimal BILPRC { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Bill Img")]
        public string BILIMG { get; set; }

        //navigation property 
        public List<BILDTL> BILDTL { get; set; }
        //Foreign key for VNDDTL
        [Required]
        [ForeignKey("VNDDTL")]
        public int VNDCOD { get; set; }
        public VNDDTL VNDDTL { get; set; }

    }
}
