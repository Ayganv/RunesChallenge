using UnityEngine;

namespace Rune
{
    [CreateAssetMenu(menuName = "Rune/Type")]
    public class Type : ScriptableObject
    {
        [SerializeField] private Sprite sprite;
        [SerializeField] private Color color;

        public Color Color => color;
        public Sprite Sprite => sprite;
    }
}