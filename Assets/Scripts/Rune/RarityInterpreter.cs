using System;
using UnityEngine;

namespace Rune
{
    [CreateAssetMenu(menuName = "Rune/RarityInterpreter")]
    public class RarityInterpreter : ScriptableObject
    {
        [SerializeField] private Sprite[] sprites;
        private static Sprite[] _sprites;

        private void OnValidate()
        {
            _sprites = sprites;
        }

        public static Sprite InterpretSpriteFromRarity(Rarity rarity)
        {
            return _sprites[(int) rarity];
        }
    }
}