using Rune.Model;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Rune.View
{
    public class Rune : MonoBehaviour
    {
        public UnityEvent<string> onAmountChanged;
        public Image rarity, type, background;
        public Data data;
        public void SetUp(Data assignedData)
        {
            data = assignedData;
            onAmountChanged.Invoke(data.Amount.ToString());
            data.OnAmountChanged += delegate(int i) { onAmountChanged.Invoke(i.ToString()); };
            UpdateImages();
        }

        private void UpdateImages()
        {
            rarity.sprite = data.RarityConfig.Sprite;
            type.sprite = data.RuneType.Sprite;
            background.color = data.RuneType.Color;
        }
    }
}