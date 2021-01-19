using System.Collections.Generic;
using System.Linq;
using Rune.Model;
using UnityEngine;

namespace Rune.Controller
{
    public class Purchase
    {
        public IEnumerable<Data> PurchaseRandomRunes(int amount, List<Data> datas)
        {
            for (var i = 0; i < amount; i++)
            {
                var randomNum = Random.Range(0, datas.Count);
                yield return datas[randomNum];
                datas[randomNum].Amount++;
            }
        }
    }
}
