using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rune
{
    public class Manager : MonoBehaviour, IRuneDataProvider
    {
        public IEnumerable<Data> ReceiveData()
        {
            throw new NotImplementedException();
        }
    }
}
