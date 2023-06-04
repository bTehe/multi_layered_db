using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class DBBillboard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Category { get; set; }
        public string Tags { get; set; }
        public string User { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
