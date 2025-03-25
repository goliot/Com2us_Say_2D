using UnityEngine;

public class SplitEnemy : Enemy
{
    [Header ("# Skill")]
    public Enemy SubEnemy;

    protected override void Die()
    {
        Split();

        base.Die();
    }

    private void Split()
    {
        GameObject sub = null;
        for (int i = 0; i < 3; i++)
        {
            sub = PoolManager.Instance.GetObject(SubEnemy.Data.ObjectType);
            sub.transform.position = new Vector3(transform.position.x + (i - 1f) * 0.5f, transform.position.y, transform.position.z);
        }
    }
}
