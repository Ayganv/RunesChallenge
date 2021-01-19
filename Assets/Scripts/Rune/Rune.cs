using UnityEngine;

namespace Rune
{
    public class Rune : MonoBehaviour
    {
        public Data data;
        public void SetUp(Data data)
        {
            this.data = data;
            data.OnAmountChanged += UpdateAmount;
        }

        private void UpdateAmount(int num)
        {
            
        }

        private void UpdateImages()
        {
            
        }
    }
}