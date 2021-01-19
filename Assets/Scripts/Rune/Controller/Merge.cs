using System.Collections.Generic;
using System.Linq;
using Rune.Model;
using UnityEngine;
using Random = UnityEngine.Random;
using Type = Rune.Model.Type;

namespace Rune.Controller {
    public class Merge : MonoBehaviour {
        public MergeData mergeData;
        public bool MergeButtonIsActive => mergeData.runes.Count > 1 && mergeData.runes.Count < 5;

        #region Testing

        [SerializeField]
        private Data[] sdk;

        private void Start() {
            foreach (var VARIABLE in sdk) {
                mergeData.runes.Add(VARIABLE);
            }

            RuneMerge();
        }

        #endregion

        public View.Rune RuneMerge() {
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

            switch (mergeData.runes.Count) {
                case 2:

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

            return null;
        }

        bool ShouldUpgradeRune(float chance)
            => Random.Range(0, 101) <= chance;


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