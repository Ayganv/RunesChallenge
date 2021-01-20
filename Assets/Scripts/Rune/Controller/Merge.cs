using System.Collections.Generic;
using System.Linq;
using Rune.Model;
using Random = UnityEngine.Random;
using Type = Rune.Model.Type;

namespace Rune.Controller {
    public class Merge {
        public MergeData MergeData;

        const float TwoRuneChance = 20;
        const float ThreeRuneChance = 55;
        const float FourRuneChance = 95;

        public Merge(MergeData mergeData) {
            this.MergeData = mergeData;
        }
        public Data RuneMerge(Config config) {
            Data runeData;
            var rarity = MergeData.runes[0].Rarity;
            switch (MergeData.runes.Count) {
                case 2:
                    runeData = RuneData(TwoRuneChance, config, rarity);
                    break;
                case 3:
                    runeData = RuneData(ThreeRuneChance, config, rarity);
                    break;
                case 4:
                    runeData = RuneData(FourRuneChance, config, rarity);
                    break;
                default:
                    return null;
            }

            runeData.Amount++;
            this.MergeData.SuccessfulMerge();
            return runeData;
        }

        Data RuneData(float chance, Config config, Rarity rarity) {
            var returned = GetRandomType(TypesInList());
            var result = GetRune(chance, config, rarity);
            Data rune = null;

            foreach (var runeData in config.runeDatas) {
                if (result == runeData.Rarity && returned == runeData.RuneType) {
                    rune = runeData;
                }
            }

            return rune;
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

            foreach (var rune in MergeData.runes) {
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