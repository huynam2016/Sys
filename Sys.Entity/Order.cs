using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sys.Entity
{
    public class Order : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public virtual AppUser AppUser { get; set; }
    }
}
