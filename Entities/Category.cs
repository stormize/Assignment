using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Category")]
   public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string  Name { get; set; }
        public virtual ICollection<Device> Devices { get; set; }
       public ICollection<CategoryProperty> Properties { get; set; }
    }
}
