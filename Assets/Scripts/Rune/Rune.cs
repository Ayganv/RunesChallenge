using UnityEngine;
using UnityEngine.UI;

namespace Rune
{
    public class Rune : MonoBehaviour
    {
        public Text text;
        public Image rarity, type;
        public Data data;
        public void SetUp(Data data)
        {
            this.data = data;
            data.OnAmountChanged += UpdateAmount;
        }

        private void UpdateAmount(int num)
        {
            text.text = num.ToString();
        }

        private void UpdateImages()
        {
            rarity.sprite = data.RaritySprite;
            type.sprite = data.RuneType.Sprite;
        }
    }
}