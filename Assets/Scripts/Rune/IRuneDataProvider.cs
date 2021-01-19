using System.Collections.Generic;

namespace Rune
{
    public interface IRuneDataProvider
    {
        IEnumerable<Data> ReceiveData();
    }
}