using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class DeviceProperty
    {

        public Guid Id { get; set; }
        public string Value { get; set; }
        [ForeignKey("Property")]
        public Guid FK_Property { get; set; }
        public  virtual Property Property { get; set; }

        [ForeignKey("Device")]
        public Guid FK_Device { get; set; }
        public virtual Device Device { get; set; }
    }
}
