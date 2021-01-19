using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Rune.Model {
    [CreateAssetMenu(menuName = "Rune/Config")]
    public class Config : ScriptableObject {
        public List<Type> runeTypes;
        public List<Data> runeDatas;
        public List<Rarity> rarities;

        public List<Data> GetDatasOfRarity(Rarity rarity) => runeDatas.Where(data => data.Rarity == rarity).ToList();
        public Rarity Rarity(int num) => rarities[num];
        public Rarity Rarity(string rarity) => rarities.Find(config => config.name == rarity);

        public Rarity NextRarity(string rarityToFind) {
            for (var i = 0; i < this.rarities.Count; i++) {
                if (rarityToFind == this.rarities[i].name) {
                    return this.rarities[i + 1];
                }
            }

            return null;
        }
    }
}