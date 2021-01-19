using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rune
{
    public class Manager : MonoBehaviour, IRuneDataProvider
    {
        public Config config;
        public Purchase purchase;
        public GameObject runePrefab;
        private Factory _factory;

        private void Awake()
        {
            InstantiateRunes();
            DoPurchase();
        }

        public void DoPurchase()
        {
            foreach (var data in purchase.PurchaseRandomRunes(4, Rarity.Common, config.runeDatas))
            {
                Debug.Log(data.RaritySprite);
            }
        }

        public void InstantiateRunes()
        {
            if (_factory == null)
                _factory = new Factory(this, transform, runePrefab);
            _factory.InstantiateRunes();
        }
        
        public IEnumerable<Data> ReceiveData()
        {
            return config.runeDatas;
        }
    }
}
