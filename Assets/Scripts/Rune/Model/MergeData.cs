using System;
using System.Collections.Generic;
using Rune.View;
using UnityEngine;

namespace Rune.Model {
    [Serializable]
    public class MergeData {
        public List<Data> runes = new List<Data>();
        public bool CanMerge => this.runes.Count > 1 && this.runes.Count < 5;
        public event Action<bool> OnMergeDataChange;
        private View.Rune _resultRune;

        public bool AddRune(Data data)
        {
            if (data.Rarity.name == "Legendary" || data.Amount < 1) return false;
            if (runes.Count != 0 && runes[0] != null && data.Rarity != runes[0].Rarity) 
                CancelMerge();
            else if (this.runes.Count > 3) return false;
            
            Debug.Log($"Added: {data} wadddaup");
            this.runes.Add(data);
            this.OnMergeDataChange?.Invoke(this.CanMerge);
            data.Amount--;
            return true;
        }

        public void RemoveRune(View.Rune rune) {
            if (!runes.Contains(rune.data) || rune.transform.parent.TryGetComponent(out InventoryDropHandler handler)) return;

            this.runes.Remove(rune.data);
            this.OnMergeDataChange?.Invoke(this.CanMerge);
            rune.data.Amount++;
            rune.DestroyThis();
        }

        public void AddResult(View.Rune rune)
        {
            _resultRune = rune;
        }

        /*public void ClearResult()
        {
            if (_resultRune != null)
                _resultRune.DestroyThis();
        }*/

        public void SuccessfulMerge() {
            ClearRunes(true);
        }

        public void CancelMerge()
        {
            ClearRunes(false);
        }

        public void ClearRunes(bool successful) {
            foreach (var rune in runes)
            {
                rune.RuneMoved();
                if (!successful)
                {
                    rune.Amount++;
                }
            }
            this.runes.Clear();
            this.OnMergeDataChange?.Invoke(this.CanMerge);
        }
    }
}