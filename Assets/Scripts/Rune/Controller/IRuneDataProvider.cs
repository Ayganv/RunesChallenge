using System.Collections.Generic;
using Rune.Model;

namespace Rune.Controller
{
    public interface IRuneDataProvider
    {
        IEnumerable<Data> ReceiveData();
    }
}