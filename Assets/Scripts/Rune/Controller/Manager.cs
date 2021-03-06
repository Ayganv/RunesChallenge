﻿using System;
using Rune.Model;
using UnityEngine;

namespace Rune.Controller {
    public class Manager : MonoBehaviour {
        public Config config;
        public GameObject runePrefab;
        public Transform mergeArea, mergeResult;
        private Merge _merge;
        public event Action OnDrop;
        private Purchase _purchase;
        private Factory _factory;

        private void Awake() {
            _purchase = new Purchase();
            _merge = new Merge(new MergeData());

            InstantiateRunes();
        }

        public void DoPurchase() {
            foreach (var data in _purchase.PurchaseRandomRunes(4, config.GetDatasOfRarity(config.Rarity("Common")))) { }
        }

        public void InstantiateRunes() {
            if (_factory == null)
                _factory = new Factory(runePrefab);
            _factory.InstantiateRunes(transform, config.runeDatas);
        }

        public void AddToMergeArea(View.Rune rune)
        {
            if (this._merge.MergeData.AddRune(rune.data))
            {
                var instance = this._factory.InstantiateMergeRune(this.mergeArea, rune.data);
                instance.GetComponent<View.Rune>().QuantityDisplayTextToggle(false);
            }
            OnDrop?.Invoke();
            OnDrop = null;
            //TODO
        }

        public void SubscribeToMergeDataEvent(Action<bool> action)
        {
            _merge.MergeData.OnMergeDataChange += action;
        }

        public void RemoveFromMergeArea(View.Rune rune) {
            this._merge.MergeData.RemoveRune(rune);
            OnDrop?.Invoke();
            OnDrop = null;
            //TODO
        }

        public void ClearMergeArea() {
            //TODO
        }

        public void Merge() {
            var result = _factory.InstantiateResult(mergeResult, _merge.RuneMerge(config));
            _merge.MergeData.AddResult(result.GetComponent<View.Rune>());
            result.GetComponent<View.Rune>().QuantityDisplayTextToggle(false);
            result.GetComponent<View.Rune>().SubscribeToDrag(ref OnDrop);
        }
    }
}