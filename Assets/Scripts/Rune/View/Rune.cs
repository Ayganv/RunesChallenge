using Rune.Model;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Rune.View
{
    public class Rune : MonoBehaviour
    {
        public UnityEvent<string> onAmountChanged;
        public Image rarity, type;
        public Data data;
        public void SetUp(Data data)
        {
            this.data = data;
            data.OnAmountChanged += delegate(int i) { onAmountChanged.Invoke(i.ToString()); };
            UpdateImages();
        }

        private void UpdateImages()
        {
            rarity.sprite = data.RarityConfig.Sprite;
            type.sprite = data.RuneType.Sprite;
        }
    }
}