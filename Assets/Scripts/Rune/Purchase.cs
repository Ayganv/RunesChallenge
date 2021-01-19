using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rune
{
    public class Purchase : MonoBehaviour
    {
        public IEnumerable<Data> PurchaseRandomRunes(int amount, Rarity rarity, IEnumerable<Data> datas)
        {
            var possibleDatas = datas.Where(data => data.Rarity == rarity).ToList();
            for (var i = 0; i < amount; i++)
            {
                var randomNum = Random.Range(0, possibleDatas.Count);
                yield return possibleDatas[randomNum];
                possibleDatas[randomNum].Amount++;
            }
        }
    }
}
