using System;
using UnityEngine;

namespace Rune.Model
{
    [CreateAssetMenu(menuName = "Rune/Data")]
    public class Data : ScriptableObject
    {
        [SerializeField] private Rarity rarity;
        [SerializeField] private Type runeType;
        private int _amount;
        public event Action<int> OnAmountChanged; 
        
        public Rarity Rarity => rarity;
        public Type RuneType => runeType;

        public bool HaveAny => Amount > 0;

        public Sprite RaritySprite => RarityInterpreter.InterpretSpriteFromRarity(rarity);
        
        public int Amount
        {
            get => _amount;
            set
            {
               _amount = Mathf.Clamp(value, 0, Int32.MaxValue);
               OnAmountChanged?.Invoke(_amount);
            } 
        }
    }
}