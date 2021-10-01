using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBModel.Entities
{
    class BILHDR
    {
        //Bill Header Table
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BILCOD { get; set; }
        [Required(ErrorMessage = "Please add  Data.")]
        public DateTime BILDAT { get; set; }

        [Required(ErrorMessage = "Please add  Item Price.")]
        [Display(Name = "Bill Price")]
        [Column(TypeName = "decimal(10, 2)")]
        public Decimal ITMPRC { get; set; }
        public string BILIMG { get; set; }

        //navigation property
        public List<BILDTL> BILDTL { get; set; }
        //Foreign key for VNDDTL
        public int VNDCOD { get; set; }
        public VNDDTL VNDDTL { get; set; }

    }
}
