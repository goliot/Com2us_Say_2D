using UnityEngine;

public class Player : MonoBehaviour
{
    private float _maxHp = 100;
    public float MaxHp
    {
        get => _maxHp;
        set
        {
            _maxHp = value;
        }
    }

    private float _hp = 100;
    public float Hp
    {
        get => _hp;
        set
        {
            _hp = value;
            if (_hp <= 0)
                Die();
        }
    }

    public void TakeDamage(float damage)
    {
        _hp -= damage;
        if(_hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}