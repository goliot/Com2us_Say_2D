using UnityEngine;

public class Item_Magnetic : ItemRoot
{
    public override void Effect()
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
        foreach(GameObject item in items)
        {
            item.GetComponent<ItemRoot>().TowardPlayer();
        }
    }
}