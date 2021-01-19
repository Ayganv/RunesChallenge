using UnityEngine;

namespace Rune
{
    public class Factory
    {
        private IRuneDataProvider _runeDataProvider;
        private Transform _parent;
        private GameObject _prefab;
        public Factory(IRuneDataProvider runeDataProvider, Transform parent, GameObject prefab)
        {
            _prefab = prefab;
            _parent = parent;
            _runeDataProvider = runeDataProvider;
        }

        public void InstantiateRunes()
        {
            foreach (var rune in _runeDataProvider.ReceiveData())
            {
                var instance = Object.Instantiate(_prefab, _parent);
                instance.GetComponent<Rune>().SetUp(rune);
            }
        }
    }
}