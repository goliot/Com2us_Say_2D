using UnityEngine;

public class Item_Magnetic : ItemRoot
{
    private void Start()
    {
        itemType = EItemType.Magnetic;
    }

    public override void Effect()
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
        foreach(GameObject item in items)
        {
            item.GetComponent<ItemRoot>().TowardPlayer();
        }
    }
}