using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
         Task CommitAsync();

        void Commit();

        void Dispose();
    }
}
