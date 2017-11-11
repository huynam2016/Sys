using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Entity
{
    public class Comment : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public int OrderId { get; set; }
        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public virtual AppUser AppUser { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
    }
}
