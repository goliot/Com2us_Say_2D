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
    public float Damage;
    private bool IsDead = false;

    [Header("# Skill")]
    public GameObject SubEnemy;
    protected Transform TargetPlayer;

    [Header("# Items")]
    public GameObject[] DropItems;
    private float _dropPercentage = 0.3f;

    private void Awake()
    {
        TargetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Movement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().TakeDamage(Damage);
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        Hp -= damage;
        if(Hp <= 0)
        {
            Die();
        }
    }

    protected virtual void Movement()
    {
        transform.Translate(_direction * Speed * Time.deltaTime);
    }

    private void Split()
    {
        for(int i=0; i<3; i++)
        {
            Enemy sub = Instantiate(SubEnemy, new Vector3(transform.position.x + (i - 1f) * 0.5f, transform.position.y, transform.position.z), Quaternion.identity).GetComponent<Enemy>();
            sub.EnemyType = EEnemyType.Bezier;
        }
    }

    private void Die()
    {
        if (IsDead) return;
        IsDead = true;

        ItemDrop();

        if (EnemyType == EEnemyType.Split)
        {
            Split();
        }
        Destroy(gameObject);
    }

    private void ItemDrop()
    {
        float percentage = Random.value;

        if(percentage < _dropPercentage)
        {
            Instantiate(DropItems[Random.Range(0, DropItems.Length)], transform.position, Quaternion.identity); ;
        }
    }
}
