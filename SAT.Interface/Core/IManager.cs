using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAT.Interface.Core
{
    public interface IManager
    {
        void Initialize();

        void OnExit();
    }
}