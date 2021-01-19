using System.Collections.Generic;
using UnityEngine;

namespace Rune.Model {
    [CreateAssetMenu(menuName = "Rune/Config")]
    public class Config : ScriptableObject {
        public List<Type> runeTypes;
        public List<Data> runeDatas;
        public List<RarityConfig> rarities;

        public RarityConfig Rarity(int num) => rarities[num];
        public RarityConfig Rarity(string rarity) => rarities.Find(config => config.name == rarity);

        public RarityConfig NextRarity(string rarityToFind) {
            for (var i = 0; i < this.rarities.Count; i++) {
                if (rarityToFind == this.rarities[i].name) {
                    return this.rarities[i + 1];
                }
            }
            return null;
        }
    }
}