using System;
using System.Collections.Generic;
using System.Linq;
using Rune.Model;
using UnityEngine;
using Random = UnityEngine.Random;
using Rune.View;
using Type = Rune.Model.Type;

namespace Rune.Controller {
    public class Merge : MonoBehaviour {
        public MergeData mergeData;
        const float TwoRuneChance = 20;
        const float ThreeRuneChance = 55;
        const float FourRuneChance = 95;
        public bool MergeButtonIsActive => mergeData.runes.Count > 1 && mergeData.runes.Count < 5;
        public event Action<bool> CanMerge; 

        #region Testing

        [SerializeField]
        private Data[] sdk;

        private void Start() {
            foreach (var VARIABLE in sdk) {
                mergeData.runes.Add(VARIABLE);
            }

            //RuneMerge();
        }

        #endregion

        public Data RuneMerge(Config config) {
            //example cases:
            //
            //case 1: insert 3 x str = 1str of same rarity / 1str of higher rarity //55% chance
            //case 2: insert 2 x int = 1int of same rarity / 1str of higher rarity //20% chance
            //case 3: insert 1 x str, 1 x agi, 1 x intel = 1 of 3 Randomly
            //
            //ONLY SAME RARITY
            //Legendary can not be merged
            //Can only return a rune of the same type as one in the list
            //
            //
            //if mergeData is <2 or >4
            //return

            var rarity = mergeData.runes[0].Rarity; //current rarity of all runes in list of runes to merge
            var returned = GetRandomType(TypesInList());
            Data data;
            switch (mergeData.runes.Count) {
                case 2:
                    GetRune(TwoRuneChance, config, rarity);
                    // TODO Add RuneData Generation data = GeneratedData
                    Debug.Log($"2 Runes inserted : 20% chance");
                    Debug.Log($"Generated = {rarity} {returned} Rune");
                    break;

                case 3:
                    Debug.Log("3 Runes inserted : 55% chance of better rarity");
                    Debug.Log($"Generated = {rarity} {returned} Rune");
                    break;

                case 4:
                    Debug.Log("4 Runes inserted : 95% chance of better rarity");
                    Debug.Log($"Generated = {rarity} {returned} Rune");
                    break;

                default:
                    Debug.Log("Invalid amount of runes attempted to be merged.");
                    break;
            }

            // TODO return data;
            return null;
        }

        public void AddRune(Data data)
        {
            mergeData.runes.Add(data);
            CanMerge?.Invoke(MergeButtonIsActive);
        }
        
        public void RemoveRune(Data data)
        {
            mergeData.runes.Remove(data);
            CanMerge?.Invoke(MergeButtonIsActive);
        }
        
        public void ClearRunes()
        {
            mergeData.runes.Clear();
            CanMerge?.Invoke(MergeButtonIsActive);
        }

        bool ShouldUpgradeRune(float chance)
            => Random.Range(0, 101) <= chance;

        Rarity GetRune(float chance, Config rarityConfig, Rarity rarity) {
            if (ShouldUpgradeRune(chance)) {
                return rarityConfig.NextRarity(rarity.name);
            }

            return rarity;
        }

        private HashSet<Type> TypesInList() {
            var typesInMergeList = new HashSet<Type>();

            foreach (var rune in mergeData.runes) {
                typesInMergeList.Add(rune.RuneType);
            }

            return typesInMergeList;
        }

        private Type GetRandomType(ICollection<Type> tmp) {
            var random = Random.Range(0, tmp.Count);
            return tmp.ToArray()[random];
        }
    }
}