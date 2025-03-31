using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Model
{
    [Table("Illustration", Schema = "Production")]
    public class ProductIllustration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IllustrationID { get; set; }

        public string? Diagram { get; set; } 

        [Required]
        public DateTime ModifiedDate { get; set; }
    }
}
