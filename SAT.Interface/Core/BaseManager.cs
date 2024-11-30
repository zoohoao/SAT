using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAT.Interface.Core
{
    public abstract class BaseManager : IManager
    {
        public virtual void Initialize()
        {
        }

        public virtual void OnExit()
        {
        }
    }
}