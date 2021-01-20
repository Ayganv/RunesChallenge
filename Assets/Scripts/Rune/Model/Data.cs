using System;
using UnityEngine;

namespace Rune.Model
{
    [CreateAssetMenu(menuName = "Rune/Data")]
    public class Data : ScriptableObject
    {
        [SerializeField] private Rarity rarity;
        [SerializeField] private Type runeType;
        public event Action<int> OnAmountChanged;
        public event Action OnRuneMoved;

        public void RuneMoved()
        {
            OnRuneMoved?.Invoke();
        }

        public Rarity Rarity => rarity;
        public Type RuneType => runeType;

        public bool HaveAny => Amount > 0;
        
        public int Amount
        {
            get => PlayerPrefs.GetInt(name, 0);
            set
            {
               PlayerPrefs.SetInt(name, Mathf.Clamp(value, 0, Int32.MaxValue));
               OnAmountChanged?.Invoke(Amount);
            } 
        }
    }
}