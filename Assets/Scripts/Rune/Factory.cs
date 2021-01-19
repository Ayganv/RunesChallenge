using UnityEngine;

namespace Rune
{
    public class Factory
    {
        public Factory(IRuneDataProvider runeDataProvider, Transform parent, GameObject prefab)
        {
            InstantiateRunes(runeDataProvider, parent, prefab);
        }

        private void InstantiateRunes(IRuneDataProvider iRuneDataProvider, Transform parent, GameObject prefab)
        {
            foreach (var rune in iRuneDataProvider.ReceiveData())
            {
                var instance = Object.Instantiate(prefab, parent);
                instance.GetComponent<Rune>().SetUp(rune);
            }
        }
    }
}