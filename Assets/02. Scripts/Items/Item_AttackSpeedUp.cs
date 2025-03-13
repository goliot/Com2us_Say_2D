using UnityEngine;

public class Item_AttackSpeedUp : Item
{
    private void Start()
    {
        itemType = EItemType.AttackSpeedUp;
    }

    public override void Effect()
    {
        PlayerObject.GetComponent<PlayerFire>().FireCoolTime = PlayerObject.GetComponent<PlayerFire>().FireCoolTime - 0.1f;
        Debug.Log("Attack Speed Up!");
    }
}
