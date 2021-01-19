using Rune.Model;
using UnityEngine;

namespace Rune.Controller {
    public class Manager : MonoBehaviour {
        public Config config;
        public GameObject runePrefab;
        public Transform mergeArea;
        Merge _merge;
        private Purchase _purchase;
        private Factory _factory;

        private void Awake() {
            _purchase = new Purchase();
            _merge = new Merge(new MergeData());

            InstantiateRunes();
        }


        public void DoPurchase() {
            foreach (var data in _purchase.PurchaseRandomRunes(50, config.GetDatasOfRarity(config.Rarity(Random.Range(0, 5))))) {
                Debug.Log(data.Rarity);
                Debug.Log(data);
            }
        }

        public void InstantiateRunes() {
            if (_factory == null)
                _factory = new Factory(runePrefab);
            _factory.InstantiateRunes(transform, config.runeDatas);
        }

        public void AddToMergeArea(View.Rune rune) {
            if (this._merge.mergeData.AddRune(rune.data))
                this._factory.InstantiateRunes(this.mergeArea, new[] {rune.data});
            //TODO
        }

        public void RemoveFromMergeArea(View.Rune rune) {
            //TODO
        }

        public void ClearMergeArea() {
            //TODO
        }

        public void Merge() {
            _factory.InstantiateRunes(transform, new[] {_merge.RuneMerge(config)});
        }
    }
}