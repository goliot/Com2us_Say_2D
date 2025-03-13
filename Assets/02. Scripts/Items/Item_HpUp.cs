using UnityEngine;

public class Item_HpUp : Item
{
    private void Start()
    {
        itemType = EItemType.HpUp;
    }

    public override void Effect()
    {
        PlayerObject.GetComponent<PlayerStats>().MaxHp += 100;
        PlayerObject.GetComponent<PlayerStats>().Hp += 100;

        Debug.Log("Max HP Up!");
    }
}
