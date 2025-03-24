using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DropItemList", menuName = "Scriptable Objects/DropItemListSO")]
public class EnemyDropItemListSO : ScriptableObject
{
    public List<GameObject> itemList;

    public GameObject this[int index]
    {
        get => itemList[index];
    }

    public int Count => itemList.Count;
}