using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header ("# Movement")]
    public float Speed = 5f;
    protected Vector3 _direction = new Vector3();
    public Vector3 Direction
    {
        get => _direction;
        set
        {
            _direction = value;
        }
    }

    [Header("# Info")]
    public EnemyDataSO Data;
    public float Hp = 100f;
    protected DamageInfo _damage;
    private bool _isDead = false;

    [Header("# Items")]
    public EnemyDropItemListSO DropList;
    private float _dropPercentage = 0.3f;

    [Header("# Effects")]
    public GameObject ExplosionVFXPrefab;

    [Header("# Skill")]
    protected Transform TargetPlayer;

    [Header("# Componenets")]
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        TargetPlayer = GameManager.Instance.player.gameObject.transform;
        _damage.Type = EDamageType.Enemy;
        _damage.Value = Data.Damage;
        _damage.From = gameObject;
    }

    private void OnEnable()
    {
        Hp = Data.MaxHp;
        _isDead = false;
    }

    private void Update()
    {
        Movement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().TakeDamage(_damage);
            Die(_damage);
        }
    }

    public void TakeDamage(DamageInfo damage)
    {
        Hp -= damage.Value;
        _animator.SetTrigger("Hit");
        if (Hp <= 0)
        {
            Die(damage);
        }
    }

    protected virtual void Movement()
    {
        transform.Translate(_direction * Speed * Time.deltaTime);
    }

    protected virtual void Die(DamageInfo damage)
    {
        if (_isDead) return;
        _isDead = true;

        if(damage.Type == EDamageType.Bullet)
        {
            PlayerStats.KillCount++;
        }
        // 폭발 이펙트
        GameObject effect = PoolManager.Instance.GetObject(EObjectType.EnemyExpolsionEffect);
        effect.transform.position = transform.position;

        ItemDrop();
        PlayerStats.Score += Data.Score;

        PoolManager.Instance.ReturnObject(gameObject, Data.ObjectType);
    }

    private void ItemDrop()
    {
        float percentage = Random.value;

        if(percentage < _dropPercentage)
        {
            GameObject item = PoolManager.Instance.GetObject(DropList[Random.Range(0, DropList.Count)].GetComponent<ItemRoot>().ObjectType);
            item.transform.position = transform.position;
        }
    }

    public void BossSpawnClear()
    {
        GameObject effect = PoolManager.Instance.GetObject(EObjectType.EnemyExpolsionEffect);
        effect.transform.position = transform.position;
        PoolManager.Instance.ReturnObject(gameObject, Data.ObjectType);
    }
}
