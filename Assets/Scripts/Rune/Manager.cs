using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rune
{
    public class Manager : MonoBehaviour, IRuneDataProvider
    {
        public Config config;
        public Purchase purchase;
        
        public void DoPurchase()
        {
            foreach (var data in purchase.PurchaseRandomRunes(4, Rarity.Common, config.runeDatas))
            {
               
            }
        }
        public IEnumerable<Data> ReceiveData()
        {
            throw new NotImplementedException();
        }
    }
}
