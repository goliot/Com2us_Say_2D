using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float Hp = 3;

    public void TakeDamage(float damage)
    {
        Hp -= damage;
        if(Hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
