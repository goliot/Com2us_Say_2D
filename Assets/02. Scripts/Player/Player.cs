using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _initialMaxHp;

    private void Awake()
    {
        PlayerStats.Hp = PlayerStats.MaxHp = _initialMaxHp;
    }

    public void TakeDamage(float damage)
    {
        PlayerStats.Hp -= damage;
        if(PlayerStats.Hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}