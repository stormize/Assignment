using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class Device
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AcquisitionDate { get; set; }
        public string  Memo { get; set; }
        [ForeignKey("Category")]
        public Guid FK_Category { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<DeviceProperty> DeviceProperties { get; set; }
    }
}
