using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rune.Model {
    [Serializable]
    public class MergeData {
        public List<Data> runes = new List<Data>();
        public bool CanMerge => this.runes.Count > 1 && this.runes.Count < 5;
        public event Action<bool> OnMergeDataChange;

        public bool AddRune(Data data) {
            if (data.Rarity.name == "Legendary" || this.runes.Count > 3) return false;
            Debug.Log($"Added: {data} wadddaup");
            this.runes.Add(data);
            this.OnMergeDataChange?.Invoke(this.CanMerge);
            return true;
        }

        public void RemoveRune(Data data) {
            this.runes.Remove(data);
            this.OnMergeDataChange?.Invoke(this.CanMerge);
        }

        public void ClearRunes() {
            this.runes.Clear();
            this.OnMergeDataChange?.Invoke(this.CanMerge);
        }
    }
}