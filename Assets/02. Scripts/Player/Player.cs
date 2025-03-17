using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _initialMaxHp;
    [SerializeField] private GameObject _boomObject;

    [SerializeField] private int _boomCount = 0;
    [SerializeField] private int _killCount = 0;
    public int KillCount
    {
        get => _killCount;
        set
        {
            _killCount = value;
        }
    }

    private void Awake()
    {
        PlayerStats.Hp = PlayerStats.MaxHp = _initialMaxHp;
    }

    private void Update()
    {
        BoomCount();
        MakeBoom();
    }

    private void BoomCount()
    {
        if(_killCount >= 20)
        {
            _killCount -= 20;
            _boomCount++;
        }
    }

    private void MakeBoom()
    {
        if(Input.GetKeyDown(KeyCode.Alpha3) && _boomCount > 0)
        {
            _boomCount--;
            Instantiate(_boomObject, Vector3.zero, Quaternion.identity);
        }
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