using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class CategoryProperty
    {
        public Guid Id { get; set; }
        [ForeignKey("Property")]
        public Guid FK_Property { get; set; }
        public virtual Property Property { get; set; }

      [ForeignKey("Category")]
        public Guid FK_Category { get; set; }
        public virtual  Category Category { get; set; }
    }
}
