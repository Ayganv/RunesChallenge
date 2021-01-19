using Rune.Model;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Rune.View
{
    public class Rune : MonoBehaviour
    {
        public UnityEvent<string> onAmountChangedString;
        public Image rarity, type, background;
        public Data data;
        public void SetUp(Data assignedData)
        {
            data = assignedData;
            onAmountChangedString.Invoke(data.Amount.ToString());
            data.OnAmountChanged += delegate(int i) { onAmountChangedString.Invoke(i.ToString()); };
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