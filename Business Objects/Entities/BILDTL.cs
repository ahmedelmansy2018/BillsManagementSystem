using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBModel.Entities
{
    class BILDTL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DTLCOD { get; set; }
        [Required(ErrorMessage = "Please add  Data.")]
        [Display(Name = "Item Price")]
        [Column(TypeName = "decimal(10, 2)")]
        public Decimal ITMPRC { get; set; }
        [Required(ErrorMessage = "Please add  Quantity.")]
        [Display(Name = "Item Quantity")]
        public int ITMQTY { get; set; }

        //navigation property
        public int BILCOD { get; set; }
        public BILHDR BILHDR { get; set; }
        public int ITMCOD { get; set; }
        public ITMDTL ITMDTL { get; set; }
    }
}
