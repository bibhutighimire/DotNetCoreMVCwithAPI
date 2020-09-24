using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCwithAPI.Models
{
    [Table("product")]
    public partial class Product
    {
        
        //Product must have an “IsDiscontinued” boolean
        //Set to false by default


        [Key]
        [Column("ID", TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column("name",TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Required]
        [Column("quantity",TypeName = "int(10)")]
        public int? Quantity { get; set; }

        [Required]
        [Column("isDiscontinued", TypeName = "boolean")]
        public bool? IsDiscontinued { get; set; }

        
    }
}
