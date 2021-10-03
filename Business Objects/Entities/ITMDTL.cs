using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Business_Objects
{
    public class ITMDTL
    {
        //  Items Table
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ITMCOD { get; set; }

        [Required(ErrorMessage = "Please add  Item name.")]
        [Display(Name = "Item name")]
        [Column(TypeName = "nvarchar(100)")]
        public string ITMNAM { get; set; }

        [Required(ErrorMessage = "Please add  Item Price.")]
        [Display(Name = "Item Price")]
        [Column(TypeName = "decimal(10, 2)")]
        public Decimal ITMPRC { get; set; }

        //navigation property
        public List<BILDTL> BILDTL { get; set; }
    }
}
