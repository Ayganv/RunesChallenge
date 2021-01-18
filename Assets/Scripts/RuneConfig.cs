using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rune/Config")]
public class RuneConfig : ScriptableObject
{
    public List<RuneType> runeTypes;
    public List<RuneData> runeDatas;
}
