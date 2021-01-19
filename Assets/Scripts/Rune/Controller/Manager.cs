using System.Collections.Generic;
using Rune.Model;
using UnityEngine;

namespace Rune.Controller
{
    public class Manager : MonoBehaviour, IRuneDataProvider
    {
        public Config config;
        public GameObject runePrefab;
        private Purchase _purchase;
        private Factory _factory;

        private void Awake()
        {
            _purchase = new Purchase();
            InstantiateRunes();
        }

        public void DoPurchase()
        {
            foreach (var data in _purchase.PurchaseRandomRunes(50, config.Rarity(Random.Range(0,5)), config.runeDatas))
            {
                Debug.Log(data.Rarity);
                Debug.Log(data);
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
