using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Devops.Adapter
{
    public interface IAdapter
    {
        public void SendMessage(string Address, string Message);
    }
}
