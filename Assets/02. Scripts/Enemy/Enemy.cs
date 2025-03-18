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
    public EEnemyType EnemyType;
    public float Hp = 100f;
    [SerializeField] protected Damage _damage;
    private bool IsDead = false;

    [Header("# Skill")]
    protected Transform TargetPlayer;

    [Header("# Items")]
    public DropItemList DropList;
    private float _dropPercentage = 0.3f;

    [Header("# Effects")]
    public GameObject ExplosionVFXPrefab;

    [Header("# Componenets")]
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        TargetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        _damage.From = gameObject;
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

    public void TakeDamage(Damage damage)
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

    protected virtual void Die(Damage damage)
    {
        if (IsDead) return;
        IsDead = true;

        if(damage.Type == DamageType.Bullet)
        {
            PlayerStats.KillCount++;
        }
        // 폭발 이펙트
        Instantiate(ExplosionVFXPrefab, transform.position, Quaternion.identity);

        ItemDrop();
        Destroy(gameObject);
    }

    private void ItemDrop()
    {
        float percentage = Random.value;

        if(percentage < _dropPercentage)
        {
            Instantiate(DropList[Random.Range(0, DropList.Count)], transform.position, Quaternion.identity); ;
        }
    }
}
