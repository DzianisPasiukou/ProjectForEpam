using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Security
{
    public interface IHashCalculator
    {
        string Calculate(string raw, byte[] saltBytes = null);
        bool Check(string raw, string hash);
    }
}
