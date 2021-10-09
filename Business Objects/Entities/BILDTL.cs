using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Objects
{
    public class BILDTL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DTLCOD { get; set; }
        [Required]
        [Display(Name = "Items Price")]
        [Column(TypeName = "decimal(10, 2)")]
        public Decimal ITMPRC { get; set; }
        [Required(ErrorMessage = "Please add  Quantity.")]
        [Display(Name = "Item Quantity")]
        public int ITMQTY { get; set; }

        //navigation property
        [Required]
        [ForeignKey("BILHDR")]
        public int BILCOD { get; set; }
        public BILHDR BILHDR { get; set; }
        [Required]
        [ForeignKey("ITMDTL")]
        public int ITMCOD { get; set; }
        public ITMDTL ITMDTL { get; set; }
    }
}
