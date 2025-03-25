using UnityEngine;

public class Item_AttackSpeedUp : ItemRoot
{
    public override void Effect()
    {
        PlayerStats.FireCoolTime -= 0.1f;
        Debug.Log("Attack Speed Up!");
    }
}