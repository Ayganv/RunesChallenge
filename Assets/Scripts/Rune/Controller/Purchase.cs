using System.Collections.Generic;
using System.Linq;
using Rune.Model;
using UnityEngine;

namespace Rune.Controller
{
    public class Purchase : MonoBehaviour
    {
        public IEnumerable<Data> PurchaseRandomRunes(int amount, RarityConfig rarityConfig, IEnumerable<Data> datas)
        {
            var possibleDatas = datas.Where(data => data.RarityConfig == rarityConfig).ToList();
            for (var i = 0; i < amount; i++)
            {
                var randomNum = Random.Range(0, possibleDatas.Count);
                yield return possibleDatas[randomNum];
                possibleDatas[randomNum].Amount++;
            }
        }
    }
}
