using UnityEngine;

public class Item_HpUp : ItemRoot
{
    private void Start()
    {
        itemType = EItemType.HpUp;
    }

    public override void Effect()
    {
        PlayerStats.MaxHp += 100;
        PlayerStats.Hp += 100;
        Debug.Log("Hp Up!");
    }
}
