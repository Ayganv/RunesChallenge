using UnityEngine;

namespace Rune.Model
{
    [CreateAssetMenu(menuName = "Rune/Rarity Config")]
    public class RarityConfig : ScriptableObject
    {
        [SerializeField] private Sprite sprite;
        
        public Sprite Sprite => sprite;
    }
}