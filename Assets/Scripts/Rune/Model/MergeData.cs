using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rune.Model {
    [Serializable]
    public class MergeData {
        public List<Data> runes = new List<Data>();
        public bool CanMerge => this.runes.Count > 1 && this.runes.Count < 5;
        public event Action<bool> OnMergeDataChange;

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

        public void RemoveRune(Data data) {
            data.RuneMoved(false);
            this.runes.Remove(data);
            this.OnMergeDataChange?.Invoke(this.CanMerge);
            data.Amount++;
        }
        
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
                rune.RuneMoved(false);
                if (!successful)
                {
                    rune.Amount++;
                }
            }
            this.runes.Clear();
            this.OnMergeDataChange?.Invoke(this.CanMerge);
            //TODO Change Amount
        }
    }
}