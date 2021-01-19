using UnityEngine;

namespace Rune.Model
{
    [CreateAssetMenu(menuName = "Rune/Rarity")]
    public class Rarity : ScriptableObject
    {
        [SerializeField] private Sprite sprite;
        
        public Sprite Sprite => sprite;
    }
}