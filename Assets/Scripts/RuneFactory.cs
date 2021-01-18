using UnityEngine;

public class RuneFactory
{
    public RuneFactory(IRune rune, Transform parent, GameObject prefab)
    {
        InstantiateRunes(rune, parent, prefab);
    }

    private void InstantiateRunes(IRune iRune, Transform parent, GameObject prefab)
    {
        foreach (var rune in iRune.ReceiveData())
        {
            var instance = Object.Instantiate(prefab, parent);
            instance.GetComponent<Rune>().SetUp(rune);
        }
    }
}