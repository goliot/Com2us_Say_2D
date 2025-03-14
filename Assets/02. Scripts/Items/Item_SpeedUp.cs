using UnityEngine;

public class Item_SpeedUp : ItemRoot
{
    private void Start()
    {
        itemType = EItemType.SpeedUp;
    }

    public override void Effect()
    {
        PlayerStats.Speed *= 1.2f;
        Debug.Log("Speed Up!");
    }
}
