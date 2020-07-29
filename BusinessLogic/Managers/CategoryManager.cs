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
   public  class CategoryManager: Repository<Model1, Category>
    {
        public CategoryManager(Model1 context) : base(context)
        {

        }

        public override Category GetById(object id)
        {
            return Get().FirstOrDefault(a => a.Id == (Guid)id);
        }
    }
}
