using System.Collections.Generic;
using UnityEngine;

namespace Rune.Model
{
    [CreateAssetMenu(menuName = "Rune/Config")]
    public class Config : ScriptableObject
    {
        public List<Type> runeTypes;
        public List<Data> runeDatas;
        public List<RarityConfig> rarities;

        public RarityConfig Rarity(int num) => rarities[num];
        public RarityConfig Rarity(string rarity) => rarities.Find(config => config.name == rarity);
    }
}
