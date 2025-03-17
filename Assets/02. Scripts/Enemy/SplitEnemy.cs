using UnityEngine;

public class SplitEnemy : Enemy
{
    [Header ("# Skill")]
    public GameObject SubEnemy;

    protected override void Die()
    {
        Split();

        base.Die();
    }

    private void Split()
    {
        for (int i = 0; i < 3; i++)
        {
            Enemy sub = Instantiate(SubEnemy, new Vector3(transform.position.x + (i - 1f) * 0.5f, transform.position.y, transform.position.z), Quaternion.identity).GetComponent<Enemy>();
            sub.EnemyType = EEnemyType.Bezier;
        }
    }
}
