using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monty.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void CreateNew(T toCreate);
    }
}
