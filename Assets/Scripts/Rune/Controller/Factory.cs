using System.Collections.Generic;
using Rune.Model;
using UnityEngine;

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
    }
}