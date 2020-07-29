using BusinessLogic.Managers;
using Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class UnitOfWork
    {
        readonly Model1 _context = new Model1();
        public DeviceManager Devices
        {
            get
            {
                return new DeviceManager(_context);
            }
        }
        public CategoryManager Categories
        {
            get
            {
                return new CategoryManager(_context);
            }
        }
        public PropertyManager Properties
        {
            get
            {
                return new PropertyManager(_context);
            }
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public void Dispose() // IDisposable implementation
        {
            _context.Dispose();
        }
    }

}
