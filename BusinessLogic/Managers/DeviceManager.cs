using Context;
using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Managers
{
   public class DeviceManager : Repository<Model1,Device>
    {
        public DeviceManager(Model1 context):base(context)
        {

        }

        public override Device GetById(object id)
        {
            return Get().FirstOrDefault(a => a.Id == (Guid)id);
        }
    }
}
