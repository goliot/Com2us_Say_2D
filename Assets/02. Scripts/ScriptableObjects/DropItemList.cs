using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu]
public class DropItemList : ScriptableObject
{
    public List<GameObject> itemList;

    public GameObject this[int index]
    {
        get => itemList[index];
    }

    public int Count => itemList.Count;
}
