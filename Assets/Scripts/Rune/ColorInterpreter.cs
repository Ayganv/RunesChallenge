using System;
using UnityEngine;

namespace Rune
{
    public class ColorInterpreter
    {
        public static Color InterpretColorFromRarity(Rarity rarity)
        {
            switch (rarity)
            {
                case Rarity.Common:
                    return Color.gray;
                case Rarity.Uncommon:
                    return Color.green;
                case Rarity.Rare:
                    return Color.blue;
                case Rarity.Epic:
                    return Color.magenta;
                case Rarity.Legendary:
                    return Color.yellow;
                default:
                    throw new ArgumentOutOfRangeException(nameof(rarity), rarity, null);
            }
        }
    }
}