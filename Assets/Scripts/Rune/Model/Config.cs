using System.Collections.Generic;
using UnityEngine;

namespace Rune.Model
{
    [CreateAssetMenu(menuName = "Rune/Config")]
    public class Config : ScriptableObject
    {
        public List<Type> runeTypes;
        public List<Data> runeDatas;
    }
}
