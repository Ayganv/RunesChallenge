using System;
using System.Collections.Generic;
using Rune.Model;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Rune.Controller
{
    public class Factory
    {
        private GameObject _prefab;
        public Factory(GameObject prefab)
        {
            _prefab = prefab;
        }
        
        public void InstantiateRunes(Transform parent, IEnumerable<Data> datas)
        {
            foreach (var data in datas)
            {
                var instance = Object.Instantiate(_prefab, parent);
                instance.GetComponent<View.Rune>().SetUp(data); 
            }
        }
        
        public GameObject InstantiateResult(Transform parent, Data data)
        {
            var instance = Object.Instantiate(_prefab, parent);
            instance.GetComponent<View.Rune>().SetUp(data);
            return instance;
        }
        
        public GameObject InstantiateMergeRune(Transform parent, Data data)
        {
            var instance = Object.Instantiate(_prefab, parent);
            instance.GetComponent<View.Rune>().SetUp(data);
            instance.GetComponent<View.Rune>().ListenToRuneMove();
            return instance;
        }
    }
}