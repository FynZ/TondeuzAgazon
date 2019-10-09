using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TondeuzAgazon.Parser
{
    public interface IParser<T>
    {
        T Parse(FileInfo fi);
    }
}
