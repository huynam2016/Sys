using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Entity
{
    public class AppPermission
    {
        [Key]
        public int Id { get; set; }
        [StringLength(128)]
        public string RoleId { get; set; }
        public bool CanCreate { set; get; }
        public bool CanRead { set; get; }
        public bool CanUpdate { set; get; }
        public bool CanDelete { set; get; }
        [ForeignKey("RoleId")]
        public virtual AppRole AppRole { get; set; }
    }
}
