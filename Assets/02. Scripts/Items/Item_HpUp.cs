using UnityEngine;

public class Item_HpUp : ItemRoot
{
    private void Start()
    {
        itemType = EItemType.HpUp;
    }

    public override void Effect()
    {
        PlayerObject.GetComponent<Player>().MaxHp += 100;
        PlayerObject.GetComponent<Player>().Hp += 100;
        Debug.Log("Hp Up!");
    }
}
