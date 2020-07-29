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
    public class PropertyManager: Repository<Model1, Property>
    {
         
        public PropertyManager(Model1 context) : base(context)
        {

        }

        public override Property GetById(object id)
        {
            return Get().FirstOrDefault(a => a.Id == (Guid)id);
        }
    }
}

